using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#pragma warning disable 0168
#pragma warning disable 0219

namespace Build
{
    public static class Engine
    {
        public const int CLIPMASK0 = (((1) << 16) + 1);
        public const int CLIPMASK1 = (((256) << 16) + 64);

        public static bool editstatus = false;

        public const int MAXTILES = 9216;
        public const int STATUS2DSIZ = 144;
        public static byte[] pow2char = new byte[]{1,2,4,8,16,32,64,128};
        public static int[] pow2long = new int[]
        {
	        1,2,4,8,
	        16,32,64,128,
	        256,512,1024,2048,
	        4096,8192,16384,32768,
	        65536,131072,262144,524288,
	        1048576,2097152,4194304,8388608,
	        16777216,33554432,67108864,134217728,
	        268435456,536870912,1073741824,2147483647,
        };

        public class tilecontainer
        {
            public byte[] memory;
        }

        public static int randomseed = 17;

        public static int myconnectindex = 0;


        public static short[] tilesizx = new short[MAXTILES];
        public static short[] tilesizy = new short[MAXTILES];
        public static int[] picanm = new int[MAXTILES];
        internal static int[] lookups;
        internal static int[] lookups2;
        public static int horizlookup;
        public static int horizlookup2;
       
        public static tilecontainer[] waloff = new tilecontainer[MAXTILES];
        private static short[] uplc = new short[VgaDevice.MAXXDIM];
        private static short[] dplc = new short[VgaDevice.MAXYDIM];

        private static kFile artfil;
        private static int artfilplc = -1;
        private static int artfilnum = -1;
        private static string artfilename;

        private static int totalclocklock = 0;

        public static short[] tilefilenum = new short[MAXTILES];
        private static int[] tilefileoffs = new int[MAXTILES];
        private static int artsize = 0;
        private static short numtilefiles = 0;
        public static byte[] picsiz = new byte[MAXTILES];

        public static int horizycent, oxyaspect, oxdimen, oviewingrange;

        public static VgaDevice _device = new VgaDevice();

        public static kFileSystem filesystem = new kFileSystem();
        public static bTable table;
        public static bPalette palette;

        public static bool beforedrawrooms = false;

        public static int qsetmode = 0;
        public static int pageoffset = 0;
        public static int ydim16 = 0;

        public static int xdim2d = 0;
        public static int ydim2d = 0;

        public static int[] ylookup = new int[VgaDevice.MAXYDIM+1];
        public static int[] tiletovox = new int[MAXTILES];
        public static int[] voxscale = new int[MAXTILES];


        public static int frameplace;
        public static int searchx = 0, searchy=0;
        public static int searchit = 0;
        public static int searchsector, searchwall, searchstat;

        public static bMap board;
        public static bool novoxmips = false;

        private static int curbrightness = 0;

        public const int MAXVOXMIPS = 5;

        public static void copybufint(int[] S, int base_s, int max, int val)
        {
            for( int i = base_s; i < max; i++ )
            {
                S[i] = val;
            }
        }

        public static void copybufreverse<T>(int base_s, T[] S, int base_d, T[] D, long c)
        {
            while ((c--) > 0)
            {

                D[base_d++] = S[base_s--];
            }
        }
#region voxformatdoc
/*
 * Each KVX file uses this structure for each of its mip-map levels:
   long xsiz, ysiz, zsiz, xpivot, ypivot, zpivot;
   long xoffset[xsiz+1];
   short xyoffset[xsiz][ysiz+1];
   char rawslabdata[?];

The file can be loaded like this:
   if ((fil = open("?.kvx",O_BINARY|O_RDWR,S_IREAD)) == -1) return(0);
   nummipmaplevels = 1;  //nummipmaplevels = 5 for unstripped KVX files
   for(i=0;i<nummipmaplevels;i++)
   {
      read(fil,&numbytes,4);
      read(fil,&xsiz,4);
      read(fil,&ysiz,4);
      read(fil,&zsiz,4);
      read(fil,&xpivot,4);
      read(fil,&ypivot,4);
      read(fil,&zpivot,4);
      read(fil,xoffset,(xsiz+1)*4);
      read(fil,xyoffset,xsiz*(ysiz+1)*2);
      read(fil,voxdata,numbytes-24-(xsiz+1)*4-xsiz*(ysiz+1)*2);
   }
   read(fil,palette,768);

numbytes: Total # of bytes (not including numbytes) in each mip-map level

xsiz, ysiz, zsiz: Dimensions of voxel. (zsiz is height)

xpivot, ypivot, zpivot: Centroid of voxel.  For extra precision, this
   location has been shifted up by 8 bits.

xoffset, xyoffset: For compression purposes, I store the column pointers
   in a way that offers quick access to the data, but with slightly more
   overhead in calculating the positions.  See example of usage in voxdata.
   NOTE: xoffset[0] = (xsiz+1)*4 + xsiz*(ysiz+1)*2 (ALWAYS)

voxdata: stored in sequential format.  Here's how you can get pointers to
   the start and end of any (x, y) column:

      //pointer to start of slabs on column (x, y):
   startptr = &voxdata[xoffset[x] + xyoffset[x][y]];

      //pointer to end of slabs on column (x, y):
   endptr = &voxdata[xoffset[x] + xyoffset[x][y+1]];

   Note: endptr is actually the first piece of data in the next column

   Once you get these pointers, you can run through all of the "slabs" in
   the column.  Each slab has 3 bytes of header, then an array of colors.
   Here's the format:

   char slabztop;             //Starting z coordinate of top of slab
   char slabzleng;            //# of bytes in the color array - slab height
   char slabbackfacecullinfo; //Low 6 bits tell which of 6 faces are exposed
   char col[slabzleng];       //The array of colors from top to bottom

palette:
   The last 768 bytes of the KVX file is a standard 256-color VGA palette.
   The palette is in (Red:0, Green:1, Blue:2) order and intensities range
   from 0-63.

   Note: To keep this ZIP size small, I have stripped out the lower mip-map
   levels.  KVX files from Shadow Warrior or Blood include this data.  To
   get the palette data, I recommend seeking 768 bytes before the end of the
   KVX file.
 */
#endregion
        internal class bVoxelMipmap
        {
            public byte[] data;
            public System.IO.BinaryReader _reader;

            public bVoxelMipmap(byte[] buffer)
            {
                data = buffer;
                _reader = new System.IO.BinaryReader(new System.IO.MemoryStream(data));
            }

            public int GetInt(int p)
            {
                int ret;
                int oldpos = (int)_reader.BaseStream.Position;

                _reader.BaseStream.Position += p * sizeof(int);
                ret =  _reader.ReadInt32();
                _reader.BaseStream.Position = oldpos;

                return ret;
            }

            public short GetShort(int p)
            {
                short ret;
                int oldpos = (int)_reader.BaseStream.Position;

                _reader.BaseStream.Position += p * sizeof(short);
                ret = _reader.ReadInt16();
                _reader.BaseStream.Position = oldpos;
                return ret;
            }
        }

        internal class bVoxel
        {
            private bVoxelMipmap mipmaplvl1;
            private bVoxelMipmap mipmaplvl2;
            private bVoxelMipmap mipmaplvl3;
            private bVoxelMipmap mipmaplvl4;
            private bVoxelMipmap mipmaplvl5;

            public bVoxel(kFile fil)
            {
                long lengcnt = 0;
                long lengtot = fil.Length;

                for (int i = 0; i < MAXVOXMIPS; i++)
                {
                    int dasiz = fil.kreadint();

                    byte[] buffer = fil.kread( dasiz );

                    switch (i)
                    {
                        case 0:
                            mipmaplvl1 = new bVoxelMipmap(buffer);
                            break;

                        case 1:
                            mipmaplvl2 = new bVoxelMipmap(buffer);
                            break;

                        case 2:
                            mipmaplvl3 = new bVoxelMipmap(buffer);
                            break;

                        case 3:
                            mipmaplvl4 = new bVoxelMipmap(buffer);
                            break;

                        case 4:
                            mipmaplvl5 = new bVoxelMipmap(buffer);
                            break;
                    }

                    lengcnt += dasiz + 4;
                    if (lengcnt >= lengtot - 768) break;
                }
            }

            public bVoxelMipmap this[ int index ]
            {
                get
                {
                    switch (index)
                    {
                        case 0:
                            return mipmaplvl1;
                            

                        case 1:
                            return mipmaplvl2;

                        case 2:
                            return mipmaplvl3;

                        case 3:
                            return mipmaplvl4;

                        case 4:
                            return mipmaplvl5;

                        default:
                            throw new Exception("Out of bounds mipmap");
                    }
                }
            }
        }
        internal static bVoxel[] voxoff = new bVoxel[MAXTILES];

        public static int[] ggxinc = new int[256+1];
        public static int[] ggyinc = new int[256 + 1];
        public static int[] lowrecip = new int[1024];
        public static int nytooclose, nytoofar;

      

        public static void BeginDrawing()
        {
            _device.BeginDrawing();
        }

        public static void EndDrawing()
        {
            _device.EndDrawing();
        }

        public static void initgroupfile(string filename)
        {
            filesystem.InitGrpFile(filename);
        }

        public static int getangle(int xvect, int yvect)
        {
            int xvectshift = 0, yvectshift = 0;
            int index;

            if (xvect < 0)
                xvectshift = 1 << 10;

            if (yvect < 0)
                yvectshift = 1 << 10;

            if ((xvect | yvect) == 0) return (0);
            if (xvect == 0) return (512 + (yvectshift));
            if (yvect == 0) return ((xvectshift));
            if (xvect == yvect) return (256 + (xvectshift));
            if (xvect == -yvect) return (768 + (xvectshift));
            if (pragmas.klabs(xvect) > pragmas.klabs(yvect))
            {
                index = 640 + (int)pragmas.scale(160, yvect, xvect);
                return (((table.radarang[index] >> 6) + (xvectshift)) & 2047);
            }

            index = 640 - (int)pragmas.scale(160, xvect, yvect);
            return (((table.radarang[index] >> 6) + 512 + (yvectshift)) & 2047);
        }

        //
        // animateoffs (internal)
        //
        public static int animateoffs(short tilenum, short fakevar)
        {
            int i, k, offs;

            offs = 0;
            i = (totalclocklock >> (((int)picanm[tilenum] >> 24) & 15));
            if (((int)picanm[tilenum] & 63) > 0)
            {
                switch ((int)picanm[tilenum] & 192)
                {
                    case 64:
                        k = (i % (((int)picanm[tilenum] & 63) << 1));
                        if (k < ((int)picanm[tilenum] & 63))
                            offs = k;
                        else
                            offs = ((((int)picanm[tilenum] & 63) << 1) - k);
                        break;
                    case 128:
                        offs = (i % (((int)picanm[tilenum] & 63) + 1));
                        break;
                    case 192:
                        offs = -(i % (((int)picanm[tilenum] & 63) + 1));
                        break;
                }
            }
            return (offs);
        }

        public static void setbrightness(int dabrightness, bPalette dapal)
        {
	        int i, j, k;

	        curbrightness = Math.Min(Math.Max((int)dabrightness,0),15);

	        k = 0;

            _device.SetPalette(dapal);
        }

        public static void setbrightness(int dabrightness, byte[] dapal)
        {
            int i, j, k;

            curbrightness = Math.Min(Math.Max((int)dabrightness, 0), 15);

            k = 0;

            Engine._device._palette.palette = Engine._device._palette.scratchpal;
            for (i = 0; i < dapal.Length; i++)
            {                
                Engine._device._palette.palette[i] = Engine.table.britable[curbrightness].data[dapal[i]];
            }
            Engine._device._palette.UpdatePalette();
        }

        public static void SetPalette(bPalette palette)
        {
            _device.SetPalette(palette);
        }

        public static void RestorePalette()
        {
            _device.RestorePalette();
        }

        public static void newboard()
        {
            board = null;
            GC.Collect();

            board = new bMap();
            board.initspritelists();
        }

        //
        // loadboard
        //
        public static int loadboard(string filename, ref int daposx, ref int daposy, ref int daposz, ref short daang, ref short dacursectnum)
        {
            kFile fil;
            board = null;
            GC.Collect();

            if (filename.Length <= 0)
                return 0;

            board = new bMap();
            Engine.Printf("bMap::LoadBoard: Loading " + filename);

            
            if ((fil = Engine.filesystem.kopen4load(filename)) == null)
            {
                return (-1);
            }

            if (board.loadboard(fil, ref daposx, ref daposy, ref daposz, ref daang, ref dacursectnum) == -1)
            {
                throw new Exception("loadboard: failed to load board " + filename);
            }

            return 0;
        }

        //
        // plotpixel
        //
        public static void plotpixel(int x, int y, byte col)
        {
            Engine.BeginDrawing();
	        pragmas.drawpixel(ylookup[y]+x+frameplace,col);
            Engine.EndDrawing();
        }

        //
        // plotpixel
        //
        public static void plotpixelpal(int x, int y, int col)
        {
            Engine.BeginDrawing();
            pragmas.drawpixelpal(ylookup[y] + x + frameplace, col);
            Engine.EndDrawing();
        }

        // return vertical screen coordinate displacement for BUILD z coord
        public static Int32 getscreenvdisp(Int32 bz, Int32 zoome)
        {
            return pragmas.mulscale32(bz,zoome*table.sintable[(256+512)&2047]);
        }

        public static void screencoords(ref Int32 xres, ref Int32 yres, Int32 x, Int32 y, Int32 zoome)
        {
          //  if (m32_sideview)
            //    rotatepoint(0, 0, x, y, m32_sideang, &x, &y);

            xres = pragmas.mulscale14(x, zoome);
            yres = pragmas.mulscale14(y, zoome);
        }

        //
        // krand
        //
        public static uint krand()
        {
	        randomseed = (randomseed*27584621)+1;
	        return(((uint)randomseed)>>16);
        }

        //
        // Setgamemode
        //
        public static int setgamemode(byte davidoption, int daxdim, int daydim, int dabpp)
        {
            _device.Init((int)daxdim, (int)daydim);

            // jv - was * sizeof(int)
            int j = _device.ydim*4;  //Leave room for horizlookup&horizlookup2

	        if (lookups != null)
	        {
		        //lookups.Free();
		        lookups = null;
	        }
	        
            lookups = new int[ j << 1 ];
            lookups2 = new int[j << 1];

            horizlookup = 0;
	        horizlookup2 = 0;
	        horizycent = ((_device.ydim*4)>>1);

	        //Force drawrooms to call dosetaspect & recalculate stuff
	        oxyaspect = oxdimen = oviewingrange = -1;

	        A.setvlinebpl(_device.bytesperline);
	        j = 0;
            for (int i = 0; i <= _device.ydim; i++)
            {
                ylookup[i] = j;
                j += _device.bytesperline;
            }

            _device.setview(0, 0, _device.xdim - 1, _device.ydim - 1);
	        //_device.clearallviews(0L);
            setbrightness((byte)curbrightness, palette);

	        if (searchx < 0) 
            { 
                searchx = _device.halfxdimen; 
                searchy = (_device.ydimen>>1); 
            }

            return 0;
        }

        public static void LoadTables()
        {
            table = new bTable();
            palette = new bPalette();

            Engine._device._palette = Engine.palette;

            A.setpalookupaddress(palette.globalpalwritten, 0);
        }

        public static string GetStreamingAssetsPath()
        {
            string path;
            #if UNITY_EDITOR
            path = GameEngine.AppPath + "/StreamingAssets/";
            #elif UNITY_ANDROID
            path = "jar:file://"+ GameEngine.AppPath + "!/assets/";
            #elif UNITY_IOS
            path = "file:" + GameEngine.AppPath + "/Raw/";
            #else
            //Desktop (Mac OS or Windows)
            path = GameEngine.AppPath + "/StreamingAssets/";
            #endif
            
            return path;
        }

        //
        // Init
        //
        public static void Init()
        {
            int i, j;

            pragmas.InitPragmas();


            for (i = 1; i < 1024; i++) lowrecip[i] = ((1 << 24) - 1) / i;
            
            for (i = 0; i < MAXTILES; i++)
                tiletovox[i] = -1;

            for (i = 0; i < voxscale.Length >> 2; i++)
            {
                voxscale[i] = 65536;
            }
            qsetmode = 200;
        }

        public static void clearview()
        {
            Array.Clear(Engine._device._screenbuffer.Pixels, 0, Engine._device._screenbuffer.Pixels.Length);
        }


        public static void loadtile(short tilenume)
        {
            //PointerObject<byte> ptr;
            int i, dasiz;

            if (tilenume >= MAXTILES) 
                return;

            dasiz = tilesizx[tilenume] * tilesizy[tilenume];
            if (dasiz <= 0) return;

            i = tilefilenum[tilenume];
            if (i != artfilnum)
            {
                if (artfil != null)
                    artfil.Close();

                artfilnum = i;
                artfilplc = 0;

                artfilename = artfilename.Remove(5, 3);
                artfilename = artfilename.Insert(5, "" + (char)(((i / 100) % 10) + 48) + "" + (char)(((i / 10) % 10) + 48) + "" + (char)((i % 10) + 48));

                
                artfil = filesystem.kopen4load(artfilename);
                //faketimerhandler();
            }

            if (artfilplc != tilefileoffs[tilenume])
            {
                artfil.SetPosition((int)(tilefileoffs[tilenume] - artfilplc));
                //faketimerhandler();
            }
            waloff[tilenume] = new tilecontainer();
            byte[] tempbuf = artfil.kread((int)dasiz);

            waloff[tilenume].memory =  new byte[tempbuf.Length * 2];
            Array.Copy(tempbuf, 0, waloff[tilenume].memory, 0, tempbuf.Length);
            Array.Copy(tempbuf, 0, waloff[tilenume].memory, tempbuf.Length, tempbuf.Length);

            //faketimerhandler();
            artfilplc = tilefileoffs[tilenume] + dasiz;
        }


        //
        // rotatepoint
        //
        public static void rotatepoint(Int32 xpivot, Int32 ypivot, Int32 x, Int32 y, short daang, ref Int32 x2, ref Int32 y2)
        {
            Int32 dacos, dasin;

            dacos = table.sintable[(daang + 2560) & 2047];
            dasin = table.sintable[(daang + 2048) & 2047];
            x -= xpivot;
            y -= ypivot;
            x2 = pragmas.dmulscale14(x, dacos, -y, dasin) + xpivot;
            y2 = pragmas.dmulscale14(y, dacos, x, dasin) + ypivot;
        }


        //
        // printext16
        //
        public static void printext16(int xpos, int ypos, short col, short backcol, string name, byte fontsize)
        {
	        int stx, i, x, y, charxsiz;
	        byte[] fontptr;
            int letptr, ptr;

	        stx = xpos;

            if (fontsize != 0) { fontptr = table.smalltextfont; charxsiz = 4; }
	        else { fontptr = table.textfont; charxsiz = 8; }

            Engine.BeginDrawing();
	        for(i=0;i < name.Length;i++)
	        {
		        letptr = name[i]<<3;
		        ptr = _device.bytesperline*(ypos+7)+(stx-fontsize)+frameplace;
		        for(y=7;y>=0;y--)
		        {
			        for(x=charxsiz-1;x>=0;x--)
			        {
                        if ((fontptr[letptr + y] & pow2char[7 - fontsize - x]) != 0)
                            pragmas.drawpixel( x + ptr, col );
				        else if (backcol >= 0)
                            pragmas.drawpixel(x + ptr, backcol);
			        }
			        ptr -= _device.bytesperline;
		        }
		        stx += charxsiz;
	        }
            _device.EndDrawing();
        }

        //
        // printext256
        //
        public static void printext256(int xpos, int ypos, short col, short backcol, string name, byte fontsize)
        {
            int stx, i, x, y, charxsiz;
            byte[] fontptr;
            int letptr, ptr;

            stx = xpos;

            if (fontsize != 0) { fontptr = table.smalltextfont; charxsiz = 4; }
            else { fontptr = table.textfont; charxsiz = 8; }

            Engine.BeginDrawing();
            for (i = 0; i < name.Length; i++)
            {
                letptr = name[i] << 3;
                ptr = _device.bytesperline * (ypos + 7) + (stx - fontsize) + frameplace;
                for (y = 7; y >= 0; y--)
                {
                    for (x = charxsiz - 1; x >= 0; x--)
                    {
                        if ((fontptr[letptr + y] & pow2char[7 - fontsize - x]) != 0)
                            pragmas.drawpixel(x + ptr, col);
                        else if (backcol >= 0)
                            pragmas.drawpixel(x + ptr, backcol);
                    }
                    ptr -= _device.bytesperline;
                }
                stx += charxsiz;
            }
            _device.EndDrawing();
        }

        //
        // clear2dscreen
        //
        public static void clear2dscreen()
        {
	        int clearsz;

            _device.BeginDrawing();
	        if (qsetmode == 350) clearsz = 350;
	        else {
		        if (ydim16 <= _device.yres-STATUS2DSIZ)
                    clearsz = _device.yres - STATUS2DSIZ;
		        else
                    clearsz = _device.yres;
	        }
	        //clearbuf((char *)frameplace, (bytesperline*clearsz) >> 2, 0);
            Array.Clear(_device._screenbuffer.Pixels, frameplace, (_device.bytesperline * clearsz) >> 2);

            _device.EndDrawing();
        }


        //
        // draw2dgrid
        //
        public static void draw2dgrid(int posxe, int posye, short ange, int zoome, short gride)
        {
            int i, xp1, yp1, xp2 = 0, yp2, tempy;

            if (gride > 0)
            {
                Engine._device.BeginDrawing();

                yp1 = Engine._device.midydim16 - pragmas.mulscale14(posye + 131072, zoome);
                if (yp1 < 0) yp1 = 0;
                yp2 = Engine._device.midydim16 - pragmas.mulscale14(posye - 131072, zoome);
                if (yp2 >= ydim16) yp2 = ydim16 - 1;

                if ((yp1 < ydim16) && (yp2 >= 0) && (yp2 >= yp1))
                {
                    xp1 = Engine._device.halfxdim16 - pragmas.mulscale14(posxe + 131072, zoome);

                    for (i = -131072; i <= 131072; i += (2048 >> gride))
                    {
                        xp2 = xp1;
                        xp1 = Engine._device.halfxdim16 - pragmas.mulscale14(posxe - i, zoome);

                        if (xp1 >= xdim) break;
                        if (xp1 >= 0)
                        {
                            if (xp1 != xp2)
                            {
                                drawline16(xp1, yp1, xp1, yp2, 8);
                            }
                        }
                    }
                    if ((i >= 131072) && (xp1 < xdim))
                        xp2 = xp1;
                    if ((xp2 >= 0) && (xp2 < xdim))
                    {
                        drawline16(xp2, yp1, xp2, yp2, 8);
                    }
                }

                xp1 = pragmas.mulscale14(posxe + 131072, zoome);
                xp2 = pragmas.mulscale14(posxe - 131072, zoome);
                tempy = -2147483648; //0x80000000;
                for (i = -131072; i <= 131072; i += (2048 >> gride))
                {
                    yp1 = (((posye - i) * zoome) >> 14);
                    if (yp1 != tempy)
                    {
                        if ((yp1 > Engine._device.midydim16 - ydim16) && (yp1 <= Engine._device.midydim16))
                        {
                            drawline16(Engine._device.halfxdim16 - xp1, Engine._device.midydim16 - yp1, Engine._device.halfxdim16 - xp2, Engine._device.midydim16 - yp1, 8);
                            tempy = yp1;
                        }
                    }
                }

                Engine._device.EndDrawing();	//}}}
            }
        }


        //
        // drawline16
        //
        // JBF: Had to add extra tests to make sure x-coordinates weren't winding up -'ve
        //   after clipping or crashes would ensue
        private static uint drawlinepat = 0xffffffff;

        public static void drawline16(int x1, int y1, int x2, int y2, byte col)
        {
	        int i, dx, dy, p, pinc, d;
	        uint patc=0;

	        dx = x2-x1; dy = y2-y1;
	        if (dx >= 0)
	        {
		        if ((x1 >= _device.xres) || (x2 < 0)) return;
                if (x1 < 0) { if (dy != 0) y1 += pragmas.scale(0 - x1, dy, dx); x1 = 0; }
                if (x2 >= _device.xres) { if (dy != 0) y2 += pragmas.scale(_device.xres - 1 - x2, dy, dx); x2 = _device.xres - 1; }
	        }
	        else
	        {
		        if ((x2 >= _device.xres) || (x1 < 0)) return;
		        if (x2 < 0) { if (dy != 0) y2 += pragmas.scale(0-x2,dy,dx); x2 = 0; }
                if (x1 >= _device.xres) { if (dy != 0) y1 += pragmas.scale(_device.xres - 1 - x1, dy, dx); x1 = _device.xres - 1; }
	        }
	        if (dy >= 0)
	        {
		        if ((y1 >= ydim16) || (y2 < 0)) return;
		        if (y1 < 0) { if (dx != 0) x1 += pragmas.scale(0-y1,dx,dy); y1 = 0; if (x1 < 0) x1 = 0; }
                if (y2 >= ydim16) { if (dx != 0) x2 += pragmas.scale(ydim16 - 1 - y2, dx, dy); y2 = ydim16 - 1; if (x2 < 0) x2 = 0; }
	        }
	        else
	        {
		        if ((y2 >= ydim16) || (y1 < 0)) return;
                if (y2 < 0) { if (dx != 0) x2 += pragmas.scale(0 - y2, dx, dy); y2 = 0; if (x2 < 0) x2 = 0; }
                if (y1 >= ydim16) { if (dx != 0) x1 += pragmas.scale(ydim16 - 1 - y1, dx, dy); y1 = ydim16 - 1; if (x1 < 0) x1 = 0; }
	        }

            dx = pragmas.klabs(x2 - x1) + 1; dy = pragmas.klabs(y2 - y1) + 1;
	        if (dx >= dy)
	        {
		        if (x2 < x1)
		        {
			        i = x1; x1 = x2; x2 = i;
			        i = y1; y1 = y2; y2 = i;
		        }
		        d = 0;
                if (y2 > y1) pinc = _device.bytesperline; else pinc = -_device.bytesperline;

                _device.BeginDrawing();
		        p = (y1*_device.bytesperline)+x1+frameplace;
		        if (dy == 0 && drawlinepat == 0xffffffff) {
			        i = ((int)col<<24)|((int)col<<16)|((int)col<<8)|col;
			        //clearbufbyte((void *)p, dx, i);
                    Array.Clear(_device._screenbuffer.Pixels, dx, i);
		        } else
		        for(i=dx;i>0;i--)
		        {
			        if ((drawlinepat & pow2long[(patc++)&31]) != 0)
                        pragmas.drawpixel(p, col);
			        d += dy;
			        if (d >= dx) { d -= dx; p += pinc; }
			        p++;
		        }
                _device.EndDrawing();
		        return;
	        }

	        if (y2 < y1)
	        {
		        i = x1; x1 = x2; x2 = i;
		        i = y1; y1 = y2; y2 = i;
	        }
	        d = 0;
	        if (x2 > x1) pinc = 1; else pinc = -1;

            _device.BeginDrawing();
	        p = (y1*_device.bytesperline)+x1+frameplace;
	        for(i=dy;i>0;i--)
	        {
		        if ((drawlinepat & pow2long[(patc++)&31]) != 0)
                    pragmas.drawpixel(p, col);
		        d += dx;
		        if (d >= dy) { d -= dy; p += pinc; }
		        p += _device.bytesperline;
	        }
            _device.EndDrawing();
        }


        //
        // drawline256
        //
        public static void drawline256(int x1, int y1, int x2, int y2, byte colbyte)
        {
	        int dx, dy, i, j, p, inc, plc, daend;

	        int col = Engine._device._palette._palettebuffer[colbyte];

	        dx = x2-x1; dy = y2-y1;
	        if (dx >= 0)
	        {
		        if ((x1 >= _device.wx2) || (x2 < _device.wx1)) 
                    return;
		        if (x1 < _device.wx1) {
                    y1 += pragmas.scale(_device.wx1-x1,dy,dx);
                    x1 = _device.wx1;
                }
		        if (x2 > _device.wx2) 
                {
                    y2 += pragmas.scale(_device.wx2-x2,dy,dx);
                    x2 = _device.wx2;
                }
	        }
	        else
	        {
		        if ((x2 >= _device.wx2) || (x1 < _device.wx1)) return;
		        if (x2 < _device.wx1) {
                    y2 += pragmas.scale(_device.wx1-x2,dy,dx);
                    x2 = _device.wx1;
                }
		        if (x1 > _device.wx2) {
                    y1 += pragmas.scale(_device.wx2-x1,dy,dx);
                    x1 = _device.wx2;
                }
	        }
	        if (dy >= 0)
	        {
		        if ((y1 >= _device.wy2) || (y2 < _device.wy1)) return;
		        if (y1 < _device.wy1) 
                {
                    x1 += pragmas.scale(_device.wy1-y1,dx,dy);
                    y1 = _device.wy1;
                }
		        if (y2 > _device.wy2) {
                    x2 += pragmas.scale(_device.wy2-y2,dx,dy);
                    y2 = _device.wy2;
                }
	        }
	        else
	        {
		        if ((y2 >= _device.wy2) || (y1 < _device.wy1)) 
                    return;
		        if (y2 < _device.wy1) {
                    x2 += pragmas.scale(_device.wy1-y2,dx,dy);
                    y2 = _device.wy1;
                }
		        if (y1 > _device.wy2)
                {
                    x1 += pragmas.scale(_device.wy2-y1,dx,dy);
                    y1 = _device.wy2;
                }
	        }

            if (pragmas.klabs(dx) >= pragmas.klabs(dy))
            {
                if (dx == 0) return;
                if (dx < 0)
                {
                    i = x1; x1 = x2; x2 = i;
                    i = y1; y1 = y2; y2 = i;
                }

                inc = pragmas.divscale12(dy, dx);
                plc = y1 + pragmas.mulscale12((2047 - x1) & 4095, inc);
                i = ((x1 + 2048) >> 12); daend = ((x2 + 2048) >> 12);

                _device.BeginDrawing();
                for (; i < daend; i++)
                {
                    j = (plc >> 12);
                    if ((j >= _device.startumost[i]) && (j < _device.startdmost[i]))
                        pragmas.drawpixel(frameplace + ylookup[j] + i, col);
                    plc += inc;
                }
                _device.EndDrawing();
            }
            else
            {
                if (dy < 0)
                {
                    i = x1; x1 = x2; x2 = i;
                    i = y1; y1 = y2; y2 = i;
                }

                inc = pragmas.divscale12(dx, dy);
                plc = x1 + pragmas.mulscale12((2047 - y1) & 4095, inc);
                i = ((y1 + 2048) >> 12); daend = ((y2 + 2048) >> 12);

                _device.BeginDrawing();
                p = ylookup[i] + frameplace;
                for (; i < daend; i++)
                {
                    j = (plc >> 12);
                    if ((i >= _device.startumost[j]) && (i < _device.startdmost[j]))
                        pragmas.drawpixel(j + p, col);
                    plc += inc; p += ylookup[1];
                }
                _device.EndDrawing();
            }
	    }


        private static int clippoly4(int cx1, int cy1, int cx2, int cy2)
        {
	        int n, nn, z, zz, x, x1, x2, y, y1, y2, t;

	        nn = 0; z = 0;
	        do
	        {
		        zz = ((z+1)&3);
		        x1 = nrx1[z]; x2 = nrx1[zz]-x1;

		        if ((cx1 <= x1) && (x1 <= cx2))
                {
			        nrx2[nn] = x1; nry2[nn] = nry1[z]; nn++;
                }

		        if (x2 <= 0) x = cx2; else x = cx1;
		        t = x-x1;
		        if (((t-x2)^t) < 0)
                {
			        nrx2[nn] = x; nry2[nn] = nry1[z]+pragmas.scale(t,nry1[zz]-nry1[z],x2); nn++;
                }

		        if (x2 <= 0) x = cx1; else x = cx2;
		        t = x-x1;
		        if (((t-x2)^t) < 0)
                {
			        nrx2[nn] = x; nry2[nn] = nry1[z]+pragmas.scale(t,nry1[zz]-nry1[z],x2); nn++;
                }

		        z = zz;
	        } while (z != 0);
	        if (nn < 3) return(0);

	        n = 0; z = 0;
	        do
	        {
		        zz = z+1; if (zz == nn) zz = 0;
		        y1 = nry2[z]; y2 = nry2[zz]-y1;

		        if ((cy1 <= y1) && (y1 <= cy2))
                {
			        nry1[n] = y1; nrx1[n] = nrx2[z]; n++;
                }

		        if (y2 <= 0) y = cy2; else y = cy1;
		        t = y-y1;
		        if (((t-y2)^t) < 0)
                {
			        nry1[n] = y; nrx1[n] = nrx2[z]+pragmas.scale(t,nrx2[zz]-nrx2[z],y2); n++;
                }

		        if (y2 <= 0) y = cy1; else y = cy2;
		        t = y-y1;
		        if (((t-y2)^t) < 0)
                {
                    nry1[n] = y; nrx1[n] = nrx2[z] + pragmas.scale(t, nrx2[zz] - nrx2[z], y2); n++;
                }
		        z = zz;
	        } while (z != 0);
	        return(n);
        }

        public static bool clipinsideboxline(int x, int y, int x1, int y1, int x2, int y2, int walldist)
        {
            int r;

            r = (walldist << 1);

            x1 += walldist - x; x2 += walldist - x;
            if ((x1 < 0) && (x2 < 0)) return false;
            if ((x1 >= r) && (x2 >= r)) return false;

            y1 += walldist - y; y2 += walldist - y;
            if ((y1 < 0) && (y2 < 0)) return false;
            if ((y1 >= r) && (y2 >= r)) return false;

            x2 -= x1; y2 -= y1;
            if (x2 * (walldist - y1) >= y2 * (walldist - x1))  //Front
            {
                if (x2 > 0) x2 *= (0 - y1); else x2 *= (r - y1);
                if (y2 > 0) y2 *= (r - x1); else y2 *= (0 - x1);

                if (x2 < y2)
                    return true;

                return false;
            }
            if (x2 > 0) x2 *= (r - y1); else x2 *= (0 - y1);
            if (y2 > 0) y2 *= (0 - x1); else y2 *= (r - x1);

            if (x2 >= y2)
                return true;

            return false;
            //return((x2 >= y2)<<1);
        }

        //
        // rintersect (internal)
        //
        public static int rintersect(int x1, int y1, int z1, int vx, int vy, int vz, int x3, int y3, int x4, int y4, ref int intx, ref int inty, ref int intz)
        {     //p1 towards p2 is a ray
            int x34, y34, x31, y31, bot, topt, topu, t;

            x34 = x3 - x4; y34 = y3 - y4;
            bot = vx * y34 - vy * x34;
            if (bot >= 0)
            {
                if (bot == 0) return (0);
                x31 = x3 - x1; y31 = y3 - y1;
                topt = x31 * y34 - y31 * x34; if (topt < 0) return (0);
                topu = vx * y31 - vy * x31; if ((topu < 0) || (topu >= bot)) return (0);
            }
            else
            {
                x31 = x3 - x1; y31 = y3 - y1;
                topt = x31 * y34 - y31 * x34; if (topt > 0) return (0);
                topu = vx * y31 - vy * x31; if ((topu > 0) || (topu <= bot)) return (0);
            }
            t = pragmas.divscale16( topt, bot);
            intx = x1 + pragmas.mulscale16( vx, t);
            inty = y1 + pragmas.mulscale16( vy, t);
            intz = z1 + pragmas.mulscale16( vz, t);
            return (1);
        }

        public static int qloadkvx(int voxindex, string filename)
        {
	        int i;
            kFile fil;

	        if ((fil = filesystem.kopen4load(filename)) == null) return -1;

            voxoff[voxindex] = new bVoxel(fil);

            fil.Close();

	        return 0;
        }

        //1. Lock a picture in the cache system.
        //2. Mark it as used in the bitvector tracker.
        public static void setgotpic(int tilenume)
        {
            if (board == null)
                return;
            board.gotpic[tilenume >> 3] |= Engine.pow2char[tilenume & 7];
        }


        public static int globalpal
        {
            get
            {
                if (board != null)
                    return board.globalpal;

                return 0;
            }
        }


        //
        // dorotatesprite (internal)
        //
        //JBF 20031206: Thanks to Ken's hunting, s/(rx1|ry1|rx2|ry2)/n\1/ in this function
        private static int[] y1ve = new int[4];
        private static int[] y2ve = new int[4];
        private static int[] nrx1 = new int[8];
        private static int[] nry1 = new int[8];
        private static int[] nrx2 = new int[8];
        private static int[] nry2 = new int[8];
        private static void dorotatesprite(int sx, int sy, int z, short a, short picnum, sbyte dashade, byte dapalnum, byte dastat, int cx1, int cy1, int cx2, int cy2, int uniqid)
        {
	        int cosang, sinang, v, nextv, dax1, dax2, oy, bx, by, ny1, ny2;
	        int i, x, y, x1, y1, x2, y2, gx1, gy1;
	        int xsiz, ysiz, xoff, yoff, npoints, yplc, yinc, lx, rx, xx, xend;
	        int xv, yv, xv2, yv2, obuffermode, qlinemode=0, u4, d4;
	        byte bad;
            int palookupoffs;
            int p;

            int bufplc = 0;

	        if (cx1 < 0) cx1 = 0;
	        if (cy1 < 0) cy1 = 0;
	        if (cx2 > _device.xres-1) cx2 = _device.xres-1;
	        if (cy2 > _device.yres-1) cy2 = _device.yres-1;

	        xsiz = tilesizx[picnum]; ysiz = tilesizy[picnum];
	        if ((dastat&16) != 0) { xoff = 0; yoff = 0; }
	        else
	        {
		        xoff = (int)((sbyte)((picanm[picnum]>>8)&255))+(xsiz>>1);
		        yoff = (int)((sbyte)((picanm[picnum]>>16)&255))+(ysiz>>1);
	        }

	        if ((dastat&4) != 0) yoff = ysiz-yoff;

	        cosang = table.sintable[(a+512)&2047]; sinang = table.sintable[a&2047];

	        if ((dastat&2) != 0)  //Auto window size scaling
	        {
		        if ((dastat&8) == 0)
		        {
			        x = _device.xdimenscale;   //= scale(xdimen,yxaspect,320);
                    sx = ((cx1 + cx2 + 2) << 15) + pragmas.scale(sx - (320 << 15), _device.xdimen, 320);
			        sy = ((cy1+cy2+2)<<15)+pragmas.mulscale16( sy-(200<<15),x);
		        }
		        else
		        {
			          //If not clipping to startmosts, & auto-scaling on, as a
			          //hard-coded bonus, scale to full screen instead
                    x = pragmas.scale(_device.xdim, _device.yxaspect, 320);
                    sx = (_device.xdim << 15) + 32768 + pragmas.scale(sx - (320 << 15), _device.xdim, 320);
                    sy = (_device.ydim << 15) + 32768 + pragmas.mulscale16(sy - (200 << 15), x);
		        }
		        z = pragmas.mulscale16( z,x);
	        }

            Engine.setgotpic(picnum);

            xv = pragmas.mulscale14( cosang,z);
	        yv = pragmas.mulscale14( sinang,z);
	        if (((dastat&2) != 0) || ((dastat&8) == 0)) //Don't aspect unscaled perms
	        {
		        xv2 = pragmas.mulscale16( xv,_device.xyaspect);
                yv2 = pragmas.mulscale16( yv, _device.xyaspect);
	        }
	        else
	        {
		        xv2 = xv;
		        yv2 = yv;
	        }

	        nry1[0] = sy - (yv*xoff + xv*yoff);
	        nry1[1] = nry1[0] + yv*xsiz;
	        nry1[3] = nry1[0] + xv*ysiz;
	        nry1[2] = nry1[1]+nry1[3]-nry1[0];
	        i = (cy1<<16); if ((nry1[0]<i) && (nry1[1]<i) && (nry1[2]<i) && (nry1[3]<i)) return;
	        i = (cy2<<16); if ((nry1[0]>i) && (nry1[1]>i) && (nry1[2]>i) && (nry1[3]>i)) return;

	        nrx1[0] = sx - (xv2*xoff - yv2*yoff);
	        nrx1[1] = nrx1[0] + xv2*xsiz;
	        nrx1[3] = nrx1[0] - yv2*ysiz;
	        nrx1[2] = nrx1[1]+nrx1[3]-nrx1[0];
	        i = (cx1<<16); if ((nrx1[0]<i) && (nrx1[1]<i) && (nrx1[2]<i) && (nrx1[3]<i)) return;
	        i = (cx2<<16); if ((nrx1[0]>i) && (nrx1[1]>i) && (nrx1[2]>i) && (nrx1[3]>i)) return;

	        gx1 = nrx1[0]; gy1 = nry1[0];   //back up these before clipping

	        if ((npoints = clippoly4(cx1<<16,cy1<<16,(cx2+1)<<16,(cy2+1)<<16)) < 3) return;

	        lx = nrx1[0]; rx = nrx1[0];

	        nextv = 0;
	        for(v=npoints-1;v>=0;v--)
	        {
		        x1 = nrx1[v]; x2 = nrx1[nextv];
		        dax1 = (x1>>16); if (x1 < lx) lx = x1;
		        dax2 = (x2>>16); if (x1 > rx) rx = x1;
		        if (dax1 != dax2)
		        {
			        y1 = nry1[v]; y2 = nry1[nextv];
			        yinc = pragmas.divscale16( y2-y1,x2-x1);
			        if (dax2 > dax1)
			        {
                        yplc = y1 + pragmas.mulscale16( (dax1 << 16) + 65535 - x1, yinc);
                        pragmas.qinterpolatedown16short(dax1, ref uplc, dax2 - dax1, yplc, yinc);
			        }
			        else
			        {
                        yplc = y2 + pragmas.mulscale16( (dax2 << 16) + 65535 - x2, yinc);
                        pragmas.qinterpolatedown16short(dax2, ref dplc, dax1 - dax2, yplc, yinc);
			        }
		        }
		        nextv = v;
	        }

	        if (waloff[picnum] == null) loadtile(picnum);
            //setgotpic(picnum);
// jmarshall - If the tile is invalid, this can by null, should this be a silient return?
            if (waloff[picnum] == null || waloff[picnum].memory == null)
                return;
// jmarshall end

            byte[] buf = waloff[picnum].memory;
	        bufplc = 0;

	        palookupoffs = palette.palookup[dapalnum] + (palette.getpalookup(0,(int)dashade)<<8);

	        i = pragmas.divscale32( 1,z);
            xv = pragmas.mulscale14( sinang, i);
            yv = pragmas.mulscale14( cosang, i);
	        if (((dastat&2) != 0) || ((dastat&8) == 0)) //Don't aspect unscaled perms
	        {
		        yv2 = pragmas.mulscale16( -xv,_device.yxaspect);
                xv2 = pragmas.mulscale16( yv, _device.yxaspect);
	        }
	        else
	        {
		        yv2 = -xv;
		        xv2 = yv;
	        }

	        x1 = (lx>>16); x2 = (rx>>16);

	        oy = 0;
	        x = (x1<<16)-1-gx1; y = (oy<<16)+65535-gy1;
	        bx = pragmas.dmulscale16( x,xv2,y,xv);
            by = pragmas.dmulscale16( x, yv2, y, yv);
	        if ((dastat&4) != 0) { yv = -yv; yv2 = -yv2; by = (ysiz<<16)-1-by; }

        /*	if (origbuffermode == 0)
	        {
		        if (dastat&128)
		        {
			        obuffermode = buffermode;
			        buffermode = 0;
			        setactivepage(activepage);
		        }
	        }
	        else if (dastat&8)
		         permanentupdate = 1; */

	        if ((dastat&1) == 0)
	        {
		        if ((dastat&64) != 0)
			        A.setupspritevline(palette.palookup, palookupoffs,xv,yv,ysiz);
		        else
                    A.msetupspritevline(palette.palookup, palookupoffs, xv, yv, ysiz);
	        }
	        else
	        {
                A.tsetupspritevline(palette.palookup, palookupoffs, xv, yv, ysiz);
		        if ((dastat&32)!=0) 
                    A.settransreverse(); 
                else 
                    A.settransnormal();
	        }
	        for(x=x1;x<x2;x++)
	        {
		        bx += xv2; by += yv2;

		        y1 = uplc[x]; y2 = dplc[x];
		        if ((dastat&8) == 0)
		        {
                    if (_device.startumost[x] > y1) y1 = _device.startumost[x];
                    if (_device.startdmost[x] < y2) y2 = _device.startdmost[x];
		        }
		        if (y2 <= y1) continue;

		        switch(y1-oy)
		        {
			        case -1: bx -= xv; by -= yv; oy = y1; break;
			        case 0: break;
			        case 1: bx += xv; by += yv; oy = y1; break;
			        default: bx += xv*(y1-oy); by += yv*(y1-oy); oy = y1; break;
		        }

                p = frameplace + (ylookup[y1] + x);

		        if ((dastat&1) == 0)
		        {
			        if ((dastat&64) != 0)
				        A.spritevline(bx&65535,by&65535,y2-y1+1,buf, ((bx>>16)*ysiz+(by>>16))+bufplc,p);
			        else
                        A.mspritevline(bx & 65535, by & 65535, y2 - y1 + 1, buf, (bx >> 16) * ysiz + (by >> 16) + bufplc, p);
		        }
		        else
		        {
			        A.tspritevline(bx&65535,by&65535,y2-y1+1,buf, (bx>>16)*ysiz+(by>>16)+bufplc,p);
			        //transarea += (y2-y1);
		        }
		    //    faketimerhandler();
	        }
        }

        public static int xdim
        {
            get
            {
                return _device.xdim;
            }
        }

        public static int ydim
        {
            get
            {
                return _device.ydim;
            }
        }

        public static void rotatesprite(int sx, int sy, int z, short a, int picnum, sbyte dashade, byte dapalnum, byte dastat, int cx1, int cy1, int cx2, int cy2)
        {
            _device.BeginDrawing();
            dorotatesprite(sx, sy, z, a, (short)picnum, dashade, dapalnum, dastat, cx1, cy1, cx2, cy2, 0);
            _device.EndDrawing();
        }
        public static int loadpics(string filename)
        {
	        int offscount, siz, localtilestart, localtileend, dasiz;
	        int i, j, k;
            kFile fil;
            int artversion, mapversion;
            int numtiles;

	        for(i=0;i<MAXTILES;i++)
	        {
		        tilesizx[i] = 0;
		        tilesizy[i] = 0;
		        picanm[i] = 0;
	        }

	        artsize = 0;

	        numtilefiles = 0;
	        do
	        {
                artfilename = filename;
		        k = numtilefiles;

                artfilename = artfilename.Remove(5, 3);
                artfilename = artfilename.Insert(5, "" + (char)(((k / 100) % 10) + 48) + "" + (char)(((k / 10) % 10) + 48) + "" + (char)((k % 10) + 48));

		        if ((fil = filesystem.kopen4load(artfilename)) != null)
		        {
                    fil.kreadint(out artversion);
			        if (artversion != 1) return(-1);
                    fil.kreadint(out numtiles);
                    fil.kreadint(out localtilestart);
                    fil.kreadint(out localtileend);
                    fil.kread<short>(ref tilesizx, localtilestart, (localtileend - localtilestart + 1) << 1);
                    fil.kread<short>(ref tilesizy, localtilestart, (localtileend - localtilestart + 1) << 1);
                    fil.kread<int, int>(ref picanm, localtilestart, (localtileend - localtilestart + 1) << 2);

			        offscount = 4+4+4+4+((localtileend-localtilestart+1)<<3);
			        for(i=localtilestart;i<=localtileend;i++)
			        {
				        tilefilenum[i] = (short)k;
				        tilefileoffs[i] = offscount;
                        dasiz = (int)((int)tilesizx[i] * (int)tilesizy[i]);
				        offscount += dasiz;
                        artsize += (int)(((dasiz + 15) & 0xfffffff0));
			        }
                    fil.Close();

			        numtilefiles++;
		        }
	        }
	        while (k != numtilefiles);

	        for(i=0;i<MAXTILES;i++)
	        {
		        j = 15;
		        while ((j > 1) && (pow2long[j] > tilesizx[i])) j--;
		        picsiz[i] = ((byte)j);
		        j = 15;
		        while ((j > 1) && (pow2long[j] > tilesizy[i])) j--;
                picsiz[i] += ((byte)(j << 4));
	        }

	        return(0);
        }

        //
        // NextPage
        //
        public static void NextPage()
        {
            totalclocklock+=10;
            _device.Present();
        }

        public static void Printf(string msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
        }


        public static int FindDistance2D(int ix, int iy)
        {
            int t;

            ix = Mathf.Abs(ix);        /* absolute values */
            iy = Mathf.Abs(iy);

            if (ix < iy)
            {
                int tmp = ix;
                ix = iy;
                iy = tmp;
            }

            t = iy + (iy >> 1);

            return (ix - (ix >> 5) - (ix >> 7) + (t >> 2) + (t >> 6));
        }

        public static int FindDistance3D(int ix, int iy, int iz)
        {
            int t;

            ix = Mathf.Abs(ix);           /* absolute values */
            iy = Mathf.Abs(iy);
            iz = Mathf.Abs(iz);

            if (ix < iy)
            {
                int tmp = ix;
                ix = iy;
                iy = tmp;
            }

            if (ix < iz)
            {
                int tmp = ix;
                ix = iz;
                iz = tmp;
            }

            t = iy + iz;

            return (ix - (ix >> 4) + (t >> 2) + (t >> 3));
        }
    }
}
