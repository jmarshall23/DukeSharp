using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#pragma warning disable 0168

namespace Build
{
    //
    // bMap
    //
    public class bMap
    {
        private int mapversion;

        public bMap()
        {
            unchecked
            {
                m = new int[] { 0xff, 0xff00, 0xff0000, (int)0xff000000 };
            }

            for(int i = 0; i < sprite.Length; i++)
            {
                sprite[i] = new spritetype();                
            }

            for (int i = 0; i < tsprite.Length; i++)
            {
                tsprite[i] = new spritetype2();
            } 
        }

        public const int MAXSECTORS = 1024;
        public const int MAXWALLS = 8192;
        public const int MAXSPRITES = 4096;

        public const int MAXTILES = 9216;
        public const int MAXSTATUS = 1024;
        // jv?
        private const uint MAXYSAVES = ((VgaDevice.MAXXDIM * MAXSPRITES) >> 7);
        // jv end
        public const int MAXWALLSB = 2048;
        public const int MAXSPRITESONSCREEN = 1024;

        public int numsectors = 0;
        public int numwalls = 0;
        public int numsprites = 0;

        private bool showinvisibility = false;

        public int[] headspritesect = new int[MAXSECTORS + 1];
        public int[] headspritestat = new int[MAXSTATUS + 1];
        public int[] nextspritesect = new int[MAXSPRITES];
        public int[] nextspritestat = new int[MAXSPRITES];
        public int[] prevspritesect = new int[MAXSPRITES];
        public int[] prevspritestat = new int[MAXSPRITES];

        private int[] lastx = new int[VgaDevice.MAXYDIM];

        public spritetype2[] tsprite = new spritetype2[MAXSPRITESONSCREEN];

        private short[] sectorborder = new short[256];
        private short sectorbordercnt;
        public sectortype[] sector = new sectortype[MAXSECTORS * 2 + 1];
        public walltype[] wall = new walltype[MAXWALLS];
        public spritetype[] sprite = new spritetype[MAXSPRITES];

        private short[] uwall = new short[VgaDevice.MAXXDIM];
        private short[] dwall = new short[VgaDevice.MAXXDIM];

        private int clipnum;

        private const int MAXCLIPDIST = 1024;
        private const int MAXCLIPNUM = 512;

        private int clipsectnum;
        private byte[] show2dsprite = new byte[(MAXSPRITES + 7) >> 3];
        private int[] rxi = new int[8];
        private int[] ryi = new int[8];
        private int[] rzi = new int[8];

        private int[] xsi = new int[8];
        private int[] ysi = new int[8];
        private int[] zsi = new int[8];
        private int[] rxi2 = new int[8];
        private int[] ryi2 = new int[8];
        private int[] rzi2 = new int[8];
        private int clipmoveboxtracenum = 3;

        private int hitscangoalx = (1 << 29) - 1, hitscangoaly = (1 << 29) - 1;

        private int[] hitwalls = new int[MAXCLIPNUM];
        private linetype[] clipit = new linetype[MAXCLIPNUM];
        private int[] clipobjectval = new int[MAXCLIPNUM];
        private int[] clipsectorlist = new int[MAXCLIPNUM];

        public int globalposx, globalposy, globalposz, globalhoriz;
        public short globalang, globalcursectnum;
        public int globalpal, cosglobalang, singlobalang;
        private int cosviewingrangeglobalang, sinviewingrangeglobalang;
        private int globaluclip, globaldclip, globvis;
        private int globalvisibility, globalhisibility, globalpisibility, globalcisibility;
        private bool globparaceilclip, globparaflorclip;

        public int parallaxvisibility = 512;
        public int visibility = 512;

        private int[] swall = new int[VgaDevice.MAXXDIM];
        private int[] lwall = new int[VgaDevice.MAXXDIM + 4];

        private short[] radarang2 = new short[4096 * 2];
        private uint[] distrecip = new uint[65536];

        private byte[] gotsector = new byte[((MAXSECTORS + 7) >> 3)];
        private byte[] globalbuf;
        private int globalbufplc = 0;

        private short[] smoststart = new short[MAXWALLSB];
        private short[] smost = new short[MAXYSAVES];
        private short[] umost = new short[MAXYSAVES];
        private short[] dmost = new short[MAXYSAVES];
        private int nytooclose, nytoofar;

        private int[] xb1 = new int[MAXWALLSB];
        private int[] yb1 = new int[MAXWALLSB];
        private int[] xb2 = new int[MAXWALLSB];
        private int[] yb2 = new int[MAXWALLSB];
        public int pskybits = 0;

        private int globalxshift, globalyshift;
        private int[] smostwall = new int[MAXWALLSB];
        private byte[] smostwalltype = new byte[MAXWALLSB];

        private short[] thesector = new short[MAXWALLSB];
        private short[] thewall = new short[MAXWALLSB];

        private short[] bunchfirst = new short[MAXWALLSB];
        private short[] bunchlast = new short[MAXWALLSB];

        private byte[] tempbuf = new byte[4096];
        private int[] tempbufint = new int[4096];

        private const int MAXPSKYTILES = 256;
        public short[] pskyoff = new short[MAXPSKYTILES];

        private int numhits = 0, numscans = 0, numbunches = 0;
        public int maskwallcnt, smostwallcnt, smostcnt, spritesortcnt;
        public int framesortcnt;
        private int[] maskwall = new int[MAXWALLSB];

        private int palookupoffse = 0;
        private int[] vplce = new int[4];
        private int[] vince = new int[4];
        private int[] bufplce = new int[4];

        public int linehighlight = -1;

        private int mirrorsx1, mirrorsx2, mirrorsy1, mirrorsy2;

        public int[] gotpic = new int[MAXTILES];

        private int B_LITTLE32(int val)
        {
            return val;
        }

        private short B_LITTLE16(short val)
        {
            return val;
        }

        //private int[] spritesx = new int[MAXSPRITESONSCREEN];
        //private int[] spritesy = new int[MAXSPRITESONSCREEN];
        //private int[] spritesz = new int[MAXSPRITESONSCREEN];

        private struct VisSprite_t
        {
            public int x;
            public int y;
            public int z;
        }

        private VisSprite_t[] vissprites = new VisSprite_t[MAXSPRITESONSCREEN];

        private int[] nrx1 = new int[8];
        private int[] nry1 = new int[8];
        private int[] nrx2 = new int[8];
        private int[] nry2 = new int[8];

        private int[] rx1 = new int[MAXWALLSB];
        private int[] ry1 = new int[MAXWALLSB];
        private int[] rx2 = new int[MAXWALLSB];
        private int[] ry2 = new int[MAXWALLSB];
        private short[] p2 = new short[MAXWALLSB];

        private short[] uplc = new short[VgaDevice.MAXXDIM];
        private short[] dplc = new short[VgaDevice.MAXXDIM];

        private int[] swplc = new int[VgaDevice.MAXXDIM];
        private int[] lplc = new int[VgaDevice.MAXXDIM];

        private bool inpreparemirror = false;
        private bool inrendermirror = false;

        private int[] slopalookup = new int[16384];

        private int globalxpanning, globalypanning;
        private int globalshiftval, globalyscale;

        private int frameoffset;
        private int globalorientation, globalpicnum, globalshade;
        private int globalx, globaly, globalx1, globaly1, globalx2, globaly2, globalzd, globalzx, globalz;
        public int parallaxtype = 2, parallaxyoffs = 0, parallaxyscale = 65536;

		public int lintersect(int x1, int y1, int z1, int x2, int y2, int z2, int x3, int y3, int x4, int y4, ref int intx, ref int inty, ref int intz)
		{     //p1 to p2 is a line segment
			int x21, y21, x34, y34, x31, y31, bot, topt, topu, t;

			x21 = x2-x1; x34 = x3-x4;
			y21 = y2-y1; y34 = y3-y4;
			bot = x21*y34 - y21*x34;
			if (bot >= 0)
			{
				if (bot == 0) return(0);
				x31 = x3-x1; y31 = y3-y1;
				topt = x31*y34 - y31*x34; if ((topt < 0) || (topt >= bot)) return(0);
				topu = x21*y31 - y21*x31; if ((topu < 0) || (topu >= bot)) return(0);
			}
			else
			{
				x31 = x3-x1; y31 = y3-y1;
				topt = x31*y34 - y31*x34; if ((topt > 0) || (topt <= bot)) return(0);
				topu = x21*y31 - y21*x31; if ((topu > 0) || (topu <= bot)) return(0);
			}
			t = pragmas.divscale24(topt,bot);
			intx = x1 + pragmas.mulscale24(x21,t);
			inty = y1 + pragmas.mulscale24(y21,t);
			intz = z1 + pragmas.mulscale24(z2-z1,t);
			return(1);
		}

        public bool wallvisible(int x, int y, int wallnum)
        {
            // 1 if wall is in front of player 0 otherwise
            walltype w1 = wall[wallnum];
            walltype w2 = wall[w1.point2];
        
                int a1 = Engine.getangle(w1.x - x, w1.y - y);
                int a2 = Engine.getangle(w2.x - x, w2.y - y);
        
            return (((a2 + (2048 - a1)) & 2047) <= 1024);
        }

    public int neartag (int xs, int ys, int zs, short sectnum, short ange, ref short neartagsector, ref short neartagwall, ref short neartagsprite, ref int neartaghitdist, int neartagrange, int tagsearch)
		{
			walltype wal, wal2;
			spritetype spr;
			int i, z, zz, xe, ye, ze, x1, y1, z1, x2, y2, z2, intx, inty, intz;
			int topt, topu, bot, dist, offx, offy, vx, vy, vz;
			int tempshortcnt, tempshortnum, dasector, startwall, endwall;
			int nextsector, good;

			intx = 0;
			inty = 0;
			intz = 0;

			neartagsector = -1; neartagwall = -1; neartagsprite = -1;
			neartaghitdist = 0;

			if (sectnum < 0) return(0);
			if ((tagsearch < 1) || (tagsearch > 3)) return(0);

			vx = pragmas.mulscale14(Engine.table.sintable[(ange+2560)&2047],neartagrange); xe = xs+vx;
			vy = pragmas.mulscale14(Engine.table.sintable[(ange+2048)&2047],neartagrange); ye = ys+vy;
			vz = 0; ze = 0;

			clipsectorlist[0] = sectnum;
			tempshortcnt = 0; tempshortnum = 1;

			do
			{
				dasector = clipsectorlist[tempshortcnt];

				startwall = sector[dasector].wallptr;
				endwall = startwall + sector[dasector].wallnum - 1;
				for(z=startwall;z<=endwall;z++)
				{
					wal=wall[z];
					wal2 = wall[wal.point2];
					x1 = wal.x; y1 = wal.y; x2 = wal2.x; y2 = wal2.y;

					nextsector = wal.nextsector;

					good = 0;
					if (nextsector >= 0)
					{
						if ((tagsearch&1) != 0 && sector[nextsector].lotag != 0) good |= 1;
						if ((tagsearch&2) != 0 && sector[nextsector].hitag != 0) good |= 1;
					}
					if ((tagsearch&1) != 0 && wal.lotag != 0) good |= 2;
					if ((tagsearch&2) != 0 && wal.hitag != 0) good |= 2;

					if ((good == 0) && (nextsector < 0)) continue;
					if ((x1-xs)*(y2-ys) < (x2-xs)*(y1-ys)) continue;

					if (lintersect(xs,ys,zs,xe,ye,ze,x1,y1,x2,y2,ref intx,ref inty,ref intz) == 1)
					{
						if (good != 0)
						{
							if ((good&1) != 0) neartagsector = (short)nextsector;
							if ((good&2) != 0) neartagwall = (short)z;
							neartaghitdist = pragmas.dmulscale14(intx-xs,Engine.table.sintable[(ange+2560)&2047],inty-ys,Engine.table.sintable[(ange+2048)&2047]);
							xe = intx; ye = inty; ze = intz;
						}
						if (nextsector >= 0)
						{
							for(zz=tempshortnum-1;zz>=0;zz--)
								if (clipsectorlist[zz] == nextsector) break;
							if (zz < 0) clipsectorlist[tempshortnum++] = nextsector;
						}
					}
				}

				for(z=headspritesect[dasector];z>=0;z=nextspritesect[z])
				{
					spr = sprite[z];

					good = 0;
					if ((tagsearch&1) != 0 && spr.lotag != 0) good |= 1;
					if ((tagsearch&2) != 0 && spr.hitag != 0) good |= 1;
					if (good != 0)
					{
						x1 = spr.x; y1 = spr.y; z1 = spr.z;

						topt = vx*(x1-xs) + vy*(y1-ys);
						if (topt > 0)
						{
							bot = vx*vx + vy*vy;
							if (bot != 0)
							{
								intz = zs+pragmas.scale(vz,topt,bot);
								i = Engine.tilesizy[spr.picnum]*spr.yrepeat;
								if ((spr.cstat&128) != 0) z1 += (i<<1);
								if ((Engine.picanm[spr.picnum]&0x00ff0000) != 0) z1 -= (int)((long)((char)((Engine.picanm[spr.picnum]>>16)&255))*spr.yrepeat<<2);
								if ((intz <= z1) && (intz >= z1-(i<<2)))
								{
									topu = vx*(y1-ys) - vy*(x1-xs);

									offx = pragmas.scale(vx,topu,bot);
									offy = pragmas.scale(vy,topu,bot);
									dist = offx*offx + offy*offy;
									i = (Engine.tilesizx[spr.picnum]*spr.xrepeat); i *= i;
									if (dist <= (i>>7))
									{
										intx = xs + pragmas.scale(vx,topt,bot);
										inty = ys + pragmas.scale(vy,topt,bot);
										if (pragmas.klabs(intx-xs)+pragmas.klabs(inty-ys) < pragmas.klabs(xe-xs)+pragmas.klabs(ye-ys))
										{
											neartagsprite = (short)z;
											neartaghitdist = pragmas.dmulscale14(intx-xs,Engine.table.sintable[(ange+2560)&2047],inty-ys,Engine.table.sintable[(ange+2048)&2047]);
											xe = intx;
											ye = inty;
											ze = intz;
										}
									}
								}
							}
						}
					}
				}

				tempshortcnt++;
			} 
			while (tempshortcnt < tempshortnum);
			return 0;
		}

        public short nextsectorneighborz(short sectnum, long thez, short topbottom, short direction)
        {
            walltype wal;
            int i, testz;
            int nextz;
            short sectortouse;

            if (direction == 1) nextz = 0x7fffffff; else nextz = unchecked((int)0x80000000);

            sectortouse = -1;

			int wallPtrNum = sector[sectnum].wallptr;
            wal = wall[wallPtrNum];
            i = sector[sectnum].wallnum;
            do
            {
                if (wal.nextsector >= 0)
                {
                    if (topbottom == 1)
                    {
                        testz = sector[wal.nextsector].floorz;
                        if (direction == 1)
                        {
                            if ((testz > thez) && (testz < nextz))
                            {
                                nextz = testz;
                                sectortouse = wal.nextsector;
                            }
                        }
                        else
                        {
                            if ((testz < thez) && (testz > nextz))
                            {
                                nextz = testz;
                                sectortouse = wal.nextsector;
                            }
                        }
                    }
                    else
                    {
                        testz = sector[wal.nextsector].ceilingz;
                        if (direction == 1)
                        {
                            if ((testz > thez) && (testz < nextz))
                            {
                                nextz = testz;
                                sectortouse = wal.nextsector;
                            }
                        }
                        else
                        {
                            if ((testz < thez) && (testz > nextz))
                            {
                                nextz = testz;
                                sectortouse = wal.nextsector;
                            }
                        }
                    }
                }
				wallPtrNum++;
                wal = wall[wallPtrNum];
                i--;
            } while (i != 0);

            return (sectortouse);
        }

        public int insertsprite(short sectnum, short statnum)
        {
            insertspritestat(statnum);
            return (insertspritesect(sectnum));
        }

        private void clearbuf(int startpos, ref byte[] D, int c, int a)
        {
            int p = startpos;
            while ((c--) > 0) D[p++] = (byte)a;
        }


        private void clearbuf(int startpos, ref short[] D, int c, int a)
        {
            int p = startpos;
            while ((c--) > 0) D[p++] = (short)a;
        }

        private void clearbuf(int startpos, ref int[] D, int c, int a)
        {
            int p = startpos;
            while ((c--) > 0) D[p++] = a;
        }



        private void clearbufbyte(int startpos, ref short[] D, int c, int a)
        { // Cringe City
            int p = startpos;
            int z = 0;
            while ((c--) > 0)
            {
                D[p++] = (short)((a & m[z]) >> n[z]);
                z = (z + 1) & 3;
            }
        }

        private void copybufbyte(int sstart, ref short[] S, int dstart, ref short[] D, int c)
        {
            Array.Copy(S, sstart, D, dstart, c);
            /*
            int p = sstart, q = dstart;
            while ((c--) > 0)
            {
                D[q++] = S[p++];
            }

            return;
            */
        }

        int[] m;
        int[] n = new int[] { 0, 8, 16, 24 };

        private void clearbufbyte(int startpos, ref int[] D, int c, int a)
        { // Cringe City
            int p = startpos;



            int z = 0;
            while ((c--) > 0)
            {
                D[p++] = ((a & m[z]) >> n[z]);
                z = (z + 1) & 3;
            }
        }


        private int insertspritesect(short sectnum)
        {
            short blanktouse;

            if ((sectnum >= MAXSECTORS) || (headspritesect[MAXSECTORS] == -1))
                return (-1);  //list full

            blanktouse = (short)headspritesect[MAXSECTORS];

            headspritesect[MAXSECTORS] = nextspritesect[blanktouse];
            if (headspritesect[MAXSECTORS] >= 0)
                prevspritesect[headspritesect[MAXSECTORS]] = -1;

            prevspritesect[blanktouse] = -1;
            nextspritesect[blanktouse] = headspritesect[sectnum];
            if (headspritesect[sectnum] >= 0)
                prevspritesect[headspritesect[sectnum]] = blanktouse;
            headspritesect[sectnum] = blanktouse;

            sprite[blanktouse].sectnum = sectnum;

            return (blanktouse);
        }

        private int insertspritestat(short statnum)
        {
            short blanktouse;

            if ((statnum >= MAXSTATUS) || (headspritestat[MAXSTATUS] == -1))
                return (-1);  //list full

            blanktouse = (short)headspritestat[MAXSTATUS];

            headspritestat[MAXSTATUS] = nextspritestat[blanktouse];
            if (headspritestat[MAXSTATUS] >= 0)
                prevspritestat[headspritestat[MAXSTATUS]] = -1;

            prevspritestat[blanktouse] = -1;
            nextspritestat[blanktouse] = headspritestat[statnum];
            if (headspritestat[statnum] >= 0)
                prevspritestat[headspritestat[statnum]] = blanktouse;
            headspritestat[statnum] = blanktouse;
            sprite[blanktouse].statnum = statnum;

            return (blanktouse);
        }

        public void initspritelists()
        {
            int i;

            for (i = 0; i < MAXSECTORS; i++)     //Init doubly-linked sprite sector lists
                headspritesect[i] = -1;
            headspritesect[MAXSECTORS] = 0;
            for (i = 0; i < MAXSPRITES; i++)
            {
                prevspritesect[i] = i - 1;
                nextspritesect[i] = i + 1;
            }
            prevspritesect[0] = -1;
            nextspritesect[MAXSPRITES - 1] = -1;


            for (i = 0; i < MAXSTATUS; i++)      //Init doubly-linked sprite status lists
                headspritestat[i] = -1;
            headspritestat[MAXSTATUS] = 0;
            for (i = 0; i < MAXSPRITES; i++)
            {
                prevspritestat[i] = i - 1;
                nextspritestat[i] = i + 1;
            }
            prevspritestat[0] = -1;
            nextspritestat[MAXSPRITES - 1] = -1;
        }

        public int lastwall(short point)
        {
            int i, j, cnt;

            if ((point > 0) && (wall[point - 1].point2 == point)) return (point - 1);
            i = point;
            cnt = MAXWALLS;
            do
            {
                j = wall[i].point2;
                if (j == point) return (i);
                i = j;
                cnt--;
            } while (cnt > 0);
            return (point);
        }

        public int deletespritesect(short deleteme)
        {
            if (sprite[deleteme].sectnum == MAXSECTORS)
                return (-1);

            if (headspritesect[sprite[deleteme].sectnum] == deleteme)
                headspritesect[sprite[deleteme].sectnum] = nextspritesect[deleteme];

            if (prevspritesect[deleteme] >= 0) nextspritesect[prevspritesect[deleteme]] = nextspritesect[deleteme];
            if (nextspritesect[deleteme] >= 0) prevspritesect[nextspritesect[deleteme]] = prevspritesect[deleteme];

            if (headspritesect[MAXSECTORS] >= 0) prevspritesect[headspritesect[MAXSECTORS]] = deleteme;
            prevspritesect[deleteme] = -1;
            nextspritesect[deleteme] = headspritesect[MAXSECTORS];
            headspritesect[MAXSECTORS] = deleteme;

            sprite[deleteme].sectnum = MAXSECTORS;
            return (0);
        }

        public int deletesprite(short spritenum)
        {
            deletespritestat(spritenum);
            return (deletespritesect(spritenum));
        }

        public int deletesprite(int spritenum)
        {
            deletespritestat((short)spritenum);
            return (deletespritesect((short)spritenum));
        }

        public int setsprite(short spritenum, int newx, int newy, int newz)
        {
            short bad, j, tempsectnum;

            sprite[spritenum].x = newx;
            sprite[spritenum].y = newy;
            sprite[spritenum].z = newz;

            tempsectnum = sprite[spritenum].sectnum;
            updatesector(newx, newy, ref tempsectnum);
            if (tempsectnum < 0)
                return (-1);
            if (tempsectnum != sprite[spritenum].sectnum)
                changespritesect(spritenum, tempsectnum);

            return (0);
        }


        public int sectorofwall(short theline)
        {
            int i, j, gap;

            if ((theline < 0) || (theline >= numwalls)) return (-1);
            i = wall[theline].nextwall; if (i >= 0) return (wall[i].nextsector);

            gap = (numsectors >> 1); i = gap;
            while (gap > 1)
            {
                gap >>= 1;
                if (sector[i].wallptr < theline) i += gap; else i -= gap;
            }
            while (sector[i].wallptr > theline) i--;
            while (sector[i].wallptr + sector[i].wallnum <= theline) i++;
            return (i);
        }

        public int clockdir(short wallstart)   //Returns: 0 is CW, 1 is CCW
        {
            short i, themin;
            int minx, templong, x0, x1, x2, y0, y1, y2;

            minx = 0x7fffffff;
            themin = -1;
            i = (short)(wallstart - 1);
            do
            {
                i++;
                if (wall[wall[i].point2].x < minx)
                {
                    minx = wall[wall[i].point2].x;
                    themin = i;
                }
            }
            while ((wall[i].point2 != wallstart) && (i < MAXWALLS));

            x0 = wall[themin].x;
            y0 = wall[themin].y;
            x1 = wall[wall[themin].point2].x;
            y1 = wall[wall[themin].point2].y;
            x2 = wall[wall[wall[themin].point2].point2].x;
            y2 = wall[wall[wall[themin].point2].point2].y;

            if ((y1 >= y2) && (y1 <= y0)) return (0);
            if ((y1 >= y0) && (y1 <= y2)) return (1);

            templong = (x0 - x1) * (y2 - y1) - (x2 - x1) * (y0 - y1);
            if (templong < 0)
                return (0);
            else
                return (1);
        }

        public int loopinside(int x, int y, short startwall)
        {
            int x1, y1, x2, y2, templong;
            short i, cnt;

            cnt = (short)clockdir(startwall);
            i = startwall;
            do
            {
                x1 = wall[i].x; x2 = wall[wall[i].point2].x;
                if ((x1 >= x) || (x2 >= x))
                {
                    y1 = wall[i].y; y2 = wall[wall[i].point2].y;
                    if (y1 > y2)
                    {
                        templong = x1; x1 = x2; x2 = templong;
                        templong = y1; y1 = y2; y2 = templong;
                    }
                    if ((y1 <= y) && (y2 > y))
                        if (x1 * (y - y2) + x2 * (y1 - y) <= x * (y1 - y2))
                            cnt ^= 1;
                }
                i = wall[i].point2;
            }
            while (i != startwall);
            return (cnt);
        }

        public int numloopsofsector(short sectnum)
        {
            int i, numloops, startwall, endwall;

            numloops = 0;
            startwall = sector[sectnum].wallptr;
            endwall = startwall + sector[sectnum].wallnum;
            for (i = startwall; i < endwall; i++)
                if (wall[i].point2 < i) numloops++;
            return (numloops);
        }


        public int loopnumofsector(short sectnum, short wallnum)
        {
            int i, numloops, startwall, endwall;

            numloops = 0;
            startwall = sector[sectnum].wallptr;
            endwall = startwall + sector[sectnum].wallnum;
            for (i = startwall; i < endwall; i++)
            {
                if (i == wallnum) return (numloops);
                if (wall[i].point2 < i) numloops++;
            }
            return (-1);
        }


        public int deletespritestat(short deleteme)
        {
            if (sprite[deleteme].statnum == MAXSTATUS)
                return (-1);

            if (headspritestat[sprite[deleteme].statnum] == deleteme)
                headspritestat[sprite[deleteme].statnum] = nextspritestat[deleteme];

            if (prevspritestat[deleteme] >= 0) nextspritestat[prevspritestat[deleteme]] = nextspritestat[deleteme];
            if (nextspritestat[deleteme] >= 0) prevspritestat[nextspritestat[deleteme]] = prevspritestat[deleteme];

            if (headspritestat[MAXSTATUS] >= 0) prevspritestat[headspritestat[MAXSTATUS]] = deleteme;
            prevspritestat[deleteme] = -1;
            nextspritestat[deleteme] = headspritestat[MAXSTATUS];
            headspritestat[MAXSTATUS] = deleteme;

            sprite[deleteme].statnum = MAXSTATUS;
            return (0);
        }

        public int changespritesect(short spritenum, short newsectnum)
        {
            if ((newsectnum < 0) || (newsectnum > MAXSECTORS)) return (-1);
            if (sprite[spritenum].sectnum == newsectnum) return (0);
            if (sprite[spritenum].sectnum == MAXSECTORS) return (-1);
            if (deletespritesect(spritenum) < 0) return (-1);
            insertspritesect(newsectnum);
            return (0);
        }

        public int changespritestat(short spritenum, short newstatnum)
        {
            if ((newstatnum < 0) || (newstatnum > MAXSTATUS)) return (-1);
            if (sprite[spritenum].statnum == newstatnum) return (0);
            if (sprite[spritenum].statnum == MAXSTATUS) return (-1);
            if (deletespritestat(spritenum) < 0) return (-1);
            insertspritestat(newstatnum);
            return (0);
        }

        //
        // inside
        //
        public int inside(int x, int y, short sectnum)
        {
            walltype wal;
            int i;
            int x1, y1, x2, y2;
            uint cnt;
            int wallnum = 0;

            if ((sectnum < 0) || (sectnum >= numsectors))
                return (-1);

            cnt = 0;
            i = sector[sectnum].wallnum;
            do
            {
                wal = wall[sector[sectnum].wallptr + wallnum];
                y1 = (wal.y - y); y2 = (wall[wal.point2].y - y);
                if ((y1 ^ y2) < 0)
                {
                    x1 = (wal.x - x); x2 = (wall[wal.point2].x - x);
                    if ((x1 ^ x2) >= 0)
                    {
                        cnt ^= (uint)x1;
                    }
                    else
                    {
                        cnt ^= (uint)((x1 * y2 - x2 * y1) ^ y2);
                    }
                }
                wallnum++; i--;
            } while (i != 0);

            return (int)(cnt >> 31);
        }

        public int hitscan(int xs, int ys, int zs, short sectnum, int vx, int vy, int vz,
                ref int hitsect, ref short hitwall, ref short hitsprite,
                ref int hitx, ref int hity, ref int hitz, uint cliptype)
        {
            sectortype sec;
            walltype wal, wal2;
            spritetype spr;
            int z, zz, x1, y1 = 0, z1 = 0, x2, y2, z2, x3, y3, x4, y4, intx = 0, inty = 0, intz = 0;
            int topt, topu, bot, dist, offx, offy, cstat;
            int i, j, k, l, tilenum, xoff, yoff, dax, day, daz = 0, daz2 = 0;
            int ang, cosang, sinang, xspan, yspan, xrepeat, yrepeat;
            int dawalclipmask, dasprclipmask;
            short tempshortcnt, tempshortnum, dasector, startwall, endwall;
            short nextsector;
            bool clipyou;

            hitsect = -1; hitwall = -1; hitsprite = -1;
            if (sectnum < 0) return (-1);

            hitx = hitscangoalx; hity = hitscangoaly;

            dawalclipmask = (int)(cliptype & 65535);
            dasprclipmask = (int)(cliptype >> 16);

            clipsectorlist[0] = sectnum;
            tempshortcnt = 0; tempshortnum = 1;
            do
            {
                dasector = (short)clipsectorlist[tempshortcnt]; sec = sector[dasector];

                x1 = 0x7fffffff;
                if ((sec.ceilingstat & 2) != 0)
                {
                    wal = wall[sec.wallptr]; wal2 = wall[wal.point2];
                    dax = wal2.x - wal.x; day = wal2.y - wal.y;
                    i = (int)pragmas.nsqrtasm((uint)(dax * dax + day * day)); if (i == 0) continue;
                    i = pragmas.divscale15(sec.ceilingheinum, i);
                    dax *= i; day *= i;

                    j = (vz << 8) - pragmas.dmulscale15(dax, vy, -day, vx);
                    if (j != 0)
                    {
                        i = ((sec.ceilingz - zs) << 8) + pragmas.dmulscale15(dax, ys - wal.y, -day, xs - wal.x);
                        if (((i ^ j) >= 0) && ((pragmas.klabs(i) >> 1) < pragmas.klabs(j)))
                        {
                            i = pragmas.divscale30(i, j);
                            x1 = xs + pragmas.mulscale30(vx, i);
                            y1 = ys + pragmas.mulscale30(vy, i);
                            z1 = zs + pragmas.mulscale30(vz, i);
                        }
                    }
                }
                else if ((vz < 0) && (zs >= sec.ceilingz))
                {
                    z1 = sec.ceilingz; i = z1 - zs;
                    if ((pragmas.klabs(i) >> 1) < -vz)
                    {
                        i = pragmas.divscale30(i, vz);
                        x1 = xs + pragmas.mulscale30(vx, i);
                        y1 = ys + pragmas.mulscale30(vy, i);
                    }
                }
                if ((x1 != 0x7fffffff) && (pragmas.klabs(x1 - xs) + pragmas.klabs(y1 - ys) < pragmas.klabs((hitx) - xs) + pragmas.klabs((hity) - ys)))
                    if (inside(x1, y1, dasector) != 0)
                    {
                        hitsect = dasector; hitwall = -1; hitsprite = -1;
                        hitx = x1; hity = y1; hitz = z1;
                    }

                x1 = 0x7fffffff;
                if ((sec.floorstat & 2) != 0)
                {
                    wal = wall[sec.wallptr]; wal2 = wall[wal.point2];
                    dax = wal2.x - wal.x; day = wal2.y - wal.y;
                    i = (int)pragmas.nsqrtasm((uint)(dax * dax + day * day)); if (i == 0) continue;
                    i = pragmas.divscale15(sec.floorheinum, i);
                    dax *= i; day *= i;

                    j = (vz << 8) - pragmas.dmulscale15(dax, vy, -day, vx);
                    if (j != 0)
                    {
                        i = ((sec.floorz - zs) << 8) + pragmas.dmulscale15(dax, ys - wal.y, -day, xs - wal.x);
                        if (((i ^ j) >= 0) && ((pragmas.klabs(i) >> 1) < pragmas.klabs(j)))
                        {
                            i = pragmas.divscale30(i, j);
                            x1 = xs + pragmas.mulscale30(vx, i);
                            y1 = ys + pragmas.mulscale30(vy, i);
                            z1 = zs + pragmas.mulscale30(vz, i);
                        }
                    }
                }
                else if ((vz > 0) && (zs <= sec.floorz))
                {
                    z1 = sec.floorz; i = z1 - zs;
                    if ((pragmas.klabs(i) >> 1) < vz)
                    {
                        i = pragmas.divscale30(i, vz);
                        x1 = xs + pragmas.mulscale30(vx, i);
                        y1 = ys + pragmas.mulscale30(vy, i);
                    }
                }
                if ((x1 != 0x7fffffff) && (pragmas.klabs(x1 - xs) + pragmas.klabs(y1 - ys) < pragmas.klabs((hitx) - xs) + pragmas.klabs((hity) - ys)))
                    if (inside(x1, y1, dasector) != 0)
                    {
                        hitsect = dasector; hitwall = -1; hitsprite = -1;
                        hitx = x1; hity = y1; hitz = z1;
                    }

                startwall = sec.wallptr; endwall = (short)(startwall + sec.wallnum);

                for (z = startwall; z < endwall; z++)
                {
                    wal = wall[z];
                    wal2 = wall[wal.point2];
                    x1 = wal.x; y1 = wal.y; x2 = wal2.x; y2 = wal2.y;

                    if ((x1 - xs) * (y2 - ys) < (x2 - xs) * (y1 - ys)) continue;
                    if (Engine.rintersect(xs, ys, zs, vx, vy, vz, x1, y1, x2, y2, ref intx, ref inty, ref intz) == 0) continue;

                    if (pragmas.klabs(intx - xs) + pragmas.klabs(inty - ys) >= pragmas.klabs((hitx) - xs) + pragmas.klabs((hity) - ys)) continue;

                    nextsector = wal.nextsector;
                    if ((nextsector < 0) || (wal.cstat & dawalclipmask) != 0)
                    {
                        hitsect = dasector; hitwall = (short)z; hitsprite = -1;
                        hitx = intx; hity = inty; hitz = intz;
                        continue;
                    }
                    getzsofslope(nextsector, intx, inty, ref daz, ref daz2);
                    if ((intz <= daz) || (intz >= daz2))
                    {
                        hitsect = dasector; hitwall = (short)z; hitsprite = -1;
                        hitx = intx; hity = inty; hitz = intz;
                        continue;
                    }

                    for (zz = tempshortnum - 1; zz >= 0; zz--)
                        if (clipsectorlist[zz] == nextsector) break;
                    if (zz < 0) clipsectorlist[tempshortnum++] = nextsector;
                }

                for (z = headspritesect[dasector]; z >= 0; z = nextspritesect[z])
                {
                    spr = sprite[z];
                    if (spr == null)
                        continue;

                    cstat = spr.cstat;
                    if ((cstat & dasprclipmask) == 0 && Engine.editstatus == false) continue;

                    x1 = spr.x; y1 = spr.y; z1 = spr.z;
                    switch (cstat & 48)
                    {
                        case 0:
                            topt = vx * (x1 - xs) + vy * (y1 - ys); if (topt <= 0) continue;
                            bot = vx * vx + vy * vy; if (bot == 0) continue;

                            intz = zs + pragmas.scale(vz, topt, bot);

                            i = (Engine.tilesizy[spr.picnum] * spr.yrepeat << 2);
                            if ((cstat & 128) != 0) z1 += (i >> 1);
                            if ((Engine.picanm[spr.picnum] & 0x00ff0000) != 0) z1 -= ((int)((sbyte)((Engine.picanm[spr.picnum] >> 16) & 255)) * spr.yrepeat << 2);
                            if ((intz > z1) || (intz < z1 - i)) continue;
                            topu = vx * (y1 - ys) - vy * (x1 - xs);

                            offx = pragmas.scale(vx, topu, bot);
                            offy = pragmas.scale(vy, topu, bot);
                            dist = offx * offx + offy * offy;
                            i = Engine.tilesizx[spr.picnum] * spr.xrepeat; i *= i;
                            if (dist > (i >> 7)) continue;
                            intx = xs + pragmas.scale(vx, topt, bot);
                            inty = ys + pragmas.scale(vy, topt, bot);

                            if (pragmas.klabs(intx - xs) + pragmas.klabs(inty - ys) > pragmas.klabs((hitx) - xs) + pragmas.klabs((hity) - ys)) continue;

                            hitsect = dasector; hitwall = -1; hitsprite = (short)z;
                            hitx = intx; hity = inty; hitz = intz;
                            break;
                        case 16:
                            //These lines get the 2 points of the rotated sprite
                            //Given: (x1, y1) starts out as the center point
                            tilenum = spr.picnum;
                            xoff = (int)((sbyte)((Engine.picanm[tilenum] >> 8) & 255)) + ((int)spr.xoffset);
                            if ((cstat & 4) > 0) xoff = -xoff;
                            k = spr.ang; l = spr.xrepeat;
                            dax = Engine.table.sintable[k & 2047] * l; day = Engine.table.sintable[(k + 1536) & 2047] * l;
                            l = Engine.tilesizx[tilenum]; k = (l >> 1) + xoff;
                            x1 -= pragmas.mulscale16(dax, k); x2 = x1 + pragmas.mulscale16(dax, l);
                            y1 -= pragmas.mulscale16(day, k); y2 = y1 + pragmas.mulscale16(day, l);

                            if ((cstat & 64) != 0)   //back side of 1-way sprite
                                if ((x1 - xs) * (y2 - ys) < (x2 - xs) * (y1 - ys)) continue;

                            if (Engine.rintersect(xs, ys, zs, vx, vy, vz, x1, y1, x2, y2, ref intx, ref inty, ref intz) == 0) continue;

                            if (pragmas.klabs(intx - xs) + pragmas.klabs(inty - ys) > pragmas.klabs((hitx) - xs) + pragmas.klabs((hity) - ys)) continue;

                            k = ((Engine.tilesizy[spr.picnum] * spr.yrepeat) << 2);
                            if ((cstat & 128) != 0) daz = spr.z + (k >> 1); else daz = spr.z;
                            if ((Engine.picanm[spr.picnum] & 0x00ff0000) != 0) daz -= ((int)((sbyte)((Engine.picanm[spr.picnum] >> 16) & 255)) * spr.yrepeat << 2);
                            if ((intz < daz) && (intz > daz - k))
                            {
                                hitsect = dasector; hitwall = -1; hitsprite = (short)z;
                                hitx = intx; hity = inty; hitz = intz;
                            }
                            break;
                        case 32:
                            if (vz == 0) continue;
                            intz = z1;
                            if (((intz - zs) ^ vz) < 0) continue;
                            if ((cstat & 64) != 0)
                                if ((zs > intz) == ((cstat & 8) == 0)) continue;

                            intx = xs + pragmas.scale(intz - zs, vx, vz);
                            inty = ys + pragmas.scale(intz - zs, vy, vz);

                            if (pragmas.klabs(intx - xs) + pragmas.klabs(inty - ys) > pragmas.klabs((hitx) - xs) + pragmas.klabs((hity) - ys)) continue;

                            tilenum = spr.picnum;
                            xoff = (int)((sbyte)((Engine.picanm[tilenum] >> 8) & 255)) + ((int)spr.xoffset);
                            yoff = (int)((sbyte)((Engine.picanm[tilenum] >> 16) & 255)) + ((int)spr.yoffset);
                            if ((cstat & 4) > 0) xoff = -xoff;
                            if ((cstat & 8) > 0) yoff = -yoff;

                            ang = spr.ang;
                            cosang = Engine.table.sintable[(ang + 512) & 2047]; sinang = Engine.table.sintable[ang];
                            xspan = Engine.tilesizx[tilenum]; xrepeat = spr.xrepeat;
                            yspan = Engine.tilesizy[tilenum]; yrepeat = spr.yrepeat;

                            dax = ((xspan >> 1) + xoff) * xrepeat; day = ((yspan >> 1) + yoff) * yrepeat;
                            x1 += pragmas.dmulscale16(sinang, dax, cosang, day) - intx;
                            y1 += pragmas.dmulscale16(sinang, day, -cosang, dax) - inty;
                            l = xspan * xrepeat;
                            x2 = x1 - pragmas.mulscale16(sinang, l);
                            y2 = y1 + pragmas.mulscale16(cosang, l);
                            l = yspan * yrepeat;
                            k = -pragmas.mulscale16(cosang, l); x3 = x2 + k; x4 = x1 + k;
                            k = -pragmas.mulscale16(sinang, l); y3 = y2 + k; y4 = y1 + k;

                            clipyou = false;
                            if ((y1 ^ y2) < 0)
                            {
                                if ((x1 ^ x2) < 0) clipyou ^= (x1 * y2 < x2 * y1) ^ (y1 < y2);
                                else if (x1 >= 0) clipyou ^= true;
                            }
                            if ((y2 ^ y3) < 0)
                            {
                                if ((x2 ^ x3) < 0) clipyou ^= (x2 * y3 < x3 * y2) ^ (y2 < y3);
                                else if (x2 >= 0) clipyou ^= true;
                            }
                            if ((y3 ^ y4) < 0)
                            {
                                if ((x3 ^ x4) < 0) clipyou ^= (x3 * y4 < x4 * y3) ^ (y3 < y4);
                                else if (x3 >= 0) clipyou ^= true;
                            }
                            if ((y4 ^ y1) < 0)
                            {
                                if ((x4 ^ x1) < 0) clipyou ^= (x4 * y1 < x1 * y4) ^ (y4 < y1);
                                else if (x4 >= 0) clipyou ^= true;
                            }

                            if (clipyou != false)
                            {
                                hitsect = dasector; hitwall = -1; hitsprite = (short)z;
                                hitx = intx; hity = inty; hitz = intz;
                            }
                            break;
                    }
                }
                tempshortcnt++;
            } while (tempshortcnt < tempshortnum);
            return (0);
        }

        public void updatesector(int x, int y, ref short sectnum)
        {
            walltype wal;
            int j, wallnum;
            short i;

            if (inside(x, y, sectnum) == 1) return;

            if ((sectnum >= 0) && (sectnum < numsectors))
            {
                wallnum = sector[sectnum].wallptr;
                j = sector[sectnum].wallnum;
                do
                {
                    wal = wall[wallnum];
                    i = wal.nextsector;
                    if (i >= 0)
                    {
                        if (inside(x, y, i) == 1)
                        {
                            sectnum = i;
                            return;
                        }
                    }
                    wallnum++;
                    j--;
                } while (j != 0);
            }

            for (i = (short)(numsectors - 1); i >= 0; i--)
                if (inside(x, y, i) == 1)
                {
                    sectnum = i;
                    return;
                }

            sectnum = -1;
        }

        private void dosetaspect(bool force)
        {
            int i, j, k, x, y, xinc;

            if (Engine._device.xyaspect != Engine.oxyaspect || force)
            {
                Engine.oxyaspect = Engine._device.xyaspect;
                j = Engine._device.xyaspect * 320;
                Engine.lookups2[Engine.horizlookup2 + (Engine.horizycent - 1)] = pragmas.divscale26(131072, j);
                for (i = Engine.ydim * 4 - 1; i >= 0; i--)
                    if (i != (Engine.horizycent - 1))
                    {
                        Engine.lookups[Engine.horizlookup + i] = pragmas.divscale28(1, i - (Engine.horizycent - 1));
                        Engine.lookups2[Engine.horizlookup2 + i] = pragmas.divscale14(pragmas.klabs(Engine.lookups[Engine.horizlookup + i]), j);
                    }
            }
            if ((Engine._device.xdimen != Engine.oxdimen) || (Engine._device.viewingrange != Engine.oviewingrange) || force)
            {
                Engine.oxdimen = Engine._device.xdimen;
                Engine.oviewingrange = Engine._device.viewingrange;
                xinc = pragmas.mulscale32(Engine._device.viewingrange * 320, Engine._device.xdimenrecip);
                x = (640 << 16) - pragmas.mulscale1(xinc, Engine._device.xdimen);
                for (i = 0; i < Engine._device.xdimen; i++)
                {
                    j = (x & 65535); k = (x >> 16); x += xinc;
                    if (j != 0) j = pragmas.mulscale16((int)Engine.table.radarang[k + 1] - (int)Engine.table.radarang[k], j);
                    radarang2[i] = (short)(((int)Engine.table.radarang[k] + j) >> 6);
                }

                for (i = 1; i < 16384; i++) distrecip[i] = (uint)pragmas.divscale20(Engine._device.xdimen, i);
                nytooclose = Engine._device.xdimen * 2100;
                nytoofar = 16384 * 16384 - 1048576;
            }
        }

        //
        // draw2dscreen
        //
        public void draw2dscreen(int posxe, int posye, short ange, int zoome, short gride)
        {
            walltype wal;
            int i, j, k, xp1, yp1, xp2, yp2, tempy, templong;
            byte col, mask;

            //if (qsetmode == 200) return;

            Engine.BeginDrawing();

            //  faketimerhandler();
            for (i = numwalls - 1; i >= 0; i--)
            {
                wal = wall[i];
                //  if (editstatus == 0)
                //    {
                //      if ((show2dwall[i >> 3] & pow2char[i & 7]) == 0) continue;
                //    j = wal.nextwall;
                //  if ((j >= 0) && (i > j))
                //    if ((show2dwall[j >> 3] & pow2char[j & 7]) > 0) continue;
                //}
                //else
                //{
                j = wal.nextwall;
                if ((j >= 0) && (i > j)) continue;
                //}

                if (j < 0)
                {
                    col = 7;
                    //   if (i == linehighlight) if (totalclock & 8) col += (2 << 2);
                }
                else
                {
                    col = 4;
                    if ((wal.cstat & 1) != 0) col = 5;
                    //  if ((i == linehighlight) || ((linehighlight >= 0) && (i == wall[linehighlight].nextwall)))
                    //  if (totalclock & 8) col += (2 << 2);
                }

                xp1 = pragmas.mulscale14(wal.x - posxe, zoome);
                yp1 = pragmas.mulscale14(wal.y - posye, zoome);
                xp2 = pragmas.mulscale14(wall[wal.point2].x - posxe, zoome);
                yp2 = pragmas.mulscale14(wall[wal.point2].y - posye, zoome);

                if ((wal.cstat & 64) > 0)
                {
                    if (pragmas.klabs(xp2 - xp1) >= pragmas.klabs(yp2 - yp1))
                    {
                        Engine.drawline16(Engine._device.halfxdim16 + xp1, Engine._device.midydim16 + yp1 + 1, Engine._device.halfxdim16 + xp2, Engine._device.midydim16 + yp2 + 1, col);
                        Engine.drawline16(Engine._device.halfxdim16 + xp1, Engine._device.midydim16 + yp1 - 1, Engine._device.halfxdim16 + xp2, Engine._device.midydim16 + yp2 - 1, col);
                    }
                    else
                    {
                        Engine.drawline16(Engine._device.halfxdim16 + xp1 + 1, Engine._device.midydim16 + yp1, Engine._device.halfxdim16 + xp2 + 1, Engine._device.midydim16 + yp2, col);
                        Engine.drawline16(Engine._device.halfxdim16 + xp1 - 1, Engine._device.midydim16 + yp1, Engine._device.halfxdim16 + xp2 - 1, Engine._device.midydim16 + yp2, col);
                    }
                    col += 8;
                }
                Engine.drawline16(Engine._device.halfxdim16 + xp1, Engine._device.midydim16 + yp1, Engine._device.halfxdim16 + xp2, Engine._device.midydim16 + yp2, col);

                if ((zoome >= 256) && (Engine.editstatus == true))
                    if (((Engine._device.halfxdim16 + xp1) >= 2) && ((Engine._device.halfxdim16 + xp1) <= Engine._device.xdim - 3))
                        if (((Engine._device.midydim16 + yp1) >= 2) && ((Engine._device.midydim16 + yp1) <= Engine.ydim16 - 3))
                        {
                            col = 2;
                            //if (i == pointhighlight)
                            // {
                            // if (totalclock & 8) col += (2 << 2);	// JBF 20040116: two braces is all this needed. man I'm a fool sometimes.
                            // }
                            // else if ((highlightcnt > 0) && (editstatus == 1))
                            //  {
                            //      if (show2dwall[i >> 3] & pow2char[i & 7])
                            //          if (totalclock & 8) col += (2 << 2);
                            //  }

                            templong = ((Engine._device.midydim16 + yp1) * Engine._device.bytesperline) + (Engine._device.halfxdim16 + xp1) + Engine.frameplace;
                            pragmas.drawpixel(templong - 2 - (Engine._device.bytesperline << 1), col);
                            pragmas.drawpixel(templong - 1 - (Engine._device.bytesperline << 1), col);
                            pragmas.drawpixel(templong + 0 - (Engine._device.bytesperline << 1), col);
                            pragmas.drawpixel(templong + 1 - (Engine._device.bytesperline << 1), col);
                            pragmas.drawpixel(templong + 2 - (Engine._device.bytesperline << 1), col);

                            pragmas.drawpixel(templong - 2 + (Engine._device.bytesperline << 1), col);
                            pragmas.drawpixel(templong - 1 + (Engine._device.bytesperline << 1), col);
                            pragmas.drawpixel(templong + 0 + (Engine._device.bytesperline << 1), col);
                            pragmas.drawpixel(templong + 1 + (Engine._device.bytesperline << 1), col);
                            pragmas.drawpixel(templong + 2 + (Engine._device.bytesperline << 1), col);

                            pragmas.drawpixel(templong - 2 - Engine._device.bytesperline, col);
                            pragmas.drawpixel(templong - 2 + 0, col);
                            pragmas.drawpixel(templong - 2 + Engine._device.bytesperline, col);

                            pragmas.drawpixel(templong + 2 - Engine._device.bytesperline, col);
                            pragmas.drawpixel(templong + 2 + 0, col);
                            pragmas.drawpixel(templong + 2 + Engine._device.bytesperline, col);
                        }
            }
            //  faketimerhandler();

            if ((zoome >= 256) || (Engine.editstatus == false))
                for (i = 0; i < numsectors; i++)
                    for (j = headspritesect[i]; j >= 0; j = nextspritesect[j])
                        if ((Engine.editstatus == true) || (show2dsprite[j >> 3] & Engine.pow2char[j & 7]) != 0)
                        {
                            col = 3;
                            if ((sprite[j].cstat & 1) > 0) col = 5;
                            if (Engine.editstatus == true)
                            {
                                /*
                                if (j + 16384 == pointhighlight)
                                {
                                    if (totalclock & 8) col += (2 << 2);
                                }
                                else if ((highlightcnt > 0) && (editstatus == 1))
                                {
                                    if (show2dsprite[j >> 3] & pow2char[j & 7])
                                        if (totalclock & 8) col += (2 << 2);
                                }
                                 * */
                            }

                            xp1 = pragmas.mulscale14(sprite[j].x - posxe, zoome);
                            yp1 = pragmas.mulscale14(sprite[j].y - posye, zoome);
                            if (((Engine._device.halfxdim16 + xp1) >= 2) && ((Engine._device.halfxdim16 + xp1) <= Engine._device.xdim - 3))
                                if (((Engine._device.midydim16 + yp1) >= 2) && ((Engine._device.midydim16 + yp1) <= Engine.ydim16 - 3))
                                {
                                    templong = ((Engine._device.midydim16 + yp1) * Engine._device.bytesperline) + (Engine._device.halfxdim16 + xp1) + Engine.frameplace;
                                    pragmas.drawpixel(templong - 1 - (Engine._device.bytesperline << 1), col);
                                    pragmas.drawpixel(templong + 0 - (Engine._device.bytesperline << 1), col);
                                    pragmas.drawpixel(templong + 1 - (Engine._device.bytesperline << 1), col);

                                    pragmas.drawpixel(templong - 1 + (Engine._device.bytesperline << 1), col);
                                    pragmas.drawpixel(templong + 0 + (Engine._device.bytesperline << 1), col);
                                    pragmas.drawpixel(templong + 1 + (Engine._device.bytesperline << 1), col);

                                    pragmas.drawpixel(templong - 2 - Engine._device.bytesperline, col);
                                    pragmas.drawpixel(templong - 2 + 0, col);
                                    pragmas.drawpixel(templong - 2 + Engine._device.bytesperline, col);

                                    pragmas.drawpixel(templong + 2 - Engine._device.bytesperline, col);
                                    pragmas.drawpixel(templong + 2 + 0, col);
                                    pragmas.drawpixel(templong + 2 + Engine._device.bytesperline, col);

                                    pragmas.drawpixel(templong + 1 + Engine._device.bytesperline, col);
                                    pragmas.drawpixel(templong - 1 + Engine._device.bytesperline, col);
                                    pragmas.drawpixel(templong + 1 - Engine._device.bytesperline, col);
                                    pragmas.drawpixel(templong - 1 - Engine._device.bytesperline, col);

                                    /*
                                     * JBF 20050103: A little something intended for TerminX. It draws a box
                                     * indicating the extents of a floor-aligned sprite in the 2D view of the editor.
                                     *
                                    if ((sprite[j].cstat&32) > 0) {
                                        long fx = mulscale6(tilesizx[sprite[j].picnum], sprite[j].xrepeat);
                                        long fy = mulscale6(tilesizy[sprite[j].picnum], sprite[j].yrepeat);
                                        long co[4][2], ii;
                                        long sinang = sintable[(sprite[j].ang+512+1024)&2047];
                                        long cosang = sintable[(sprite[j].ang+1024)&2047];
                                        long r,s;

                                        fx = mulscale10(fx,zoome) >> 1;
                                        fy = mulscale10(fy,zoome) >> 1;

                                        co[0][0] = -fx;
                                        co[0][1] = -fy;
                                        co[1][0] =  fx;
                                        co[1][1] = -fy;
                                        co[2][0] =  fx;
                                        co[2][1] =  fy;
                                        co[3][0] = -fx;
                                        co[3][1] =  fy;

                                        for (ii=0;ii<4;ii++) {
                                            r = mulscale14(cosang,co[ii][0]) - mulscale14(sinang,co[ii][1]);
                                            s = mulscale14(sinang,co[ii][0]) + mulscale14(cosang,co[ii][1]);
                                            co[ii][0] = r;
                                            co[ii][1] = s;
                                        }

                                        drawlinepat = 0xcccccccc;
                                        for (ii=0;ii<4;ii++) {
                                            drawline16(halfxdim16 + xp1 + co[ii][0], midydim16 + yp1 - co[ii][1],
                                                halfxdim16 + xp1 + co[(ii+1)&3][0], midydim16 + yp1 - co[(ii+1)&3][1],
                                                col);
                                        }
                                        drawlinepat = 0xffffffff;
                                    }
                                    */

                                    xp2 = pragmas.mulscale11(Engine.table.sintable[(sprite[j].ang + 2560) & 2047], zoome) / 768;
                                    yp2 = pragmas.mulscale11(Engine.table.sintable[(sprite[j].ang + 2048) & 2047], zoome) / 768;

                                    if ((sprite[j].cstat & 256) > 0)
                                    {
                                        if (((sprite[j].ang + 256) & 512) == 0)
                                        {
                                            Engine.drawline16(Engine._device.halfxdim16 + xp1, Engine._device.midydim16 + yp1 - 1, Engine._device.halfxdim16 + xp1 + xp2, Engine._device.midydim16 + yp1 + yp2 - 1, col);
                                            Engine.drawline16(Engine._device.halfxdim16 + xp1, Engine._device.midydim16 + yp1 + 1, Engine._device.halfxdim16 + xp1 + xp2, Engine._device.midydim16 + yp1 + yp2 + 1, col);
                                        }
                                        else
                                        {
                                            Engine.drawline16(Engine._device.halfxdim16 + xp1 - 1, Engine._device.midydim16 + yp1, Engine._device.halfxdim16 + xp1 + xp2 - 1, Engine._device.midydim16 + yp1 + yp2, col);
                                            Engine.drawline16(Engine._device.halfxdim16 + xp1 + 1, Engine._device.midydim16 + yp1, Engine._device.halfxdim16 + xp1 + xp2 + 1, Engine._device.midydim16 + yp1 + yp2, col);
                                        }
                                        col += 8;
                                    }
                                    Engine.drawline16(Engine._device.halfxdim16 + xp1, Engine._device.midydim16 + yp1, Engine._device.halfxdim16 + xp1 + xp2, Engine._device.midydim16 + yp1 + yp2, col);
                                }
                        }

            //faketimerhandler();
            xp1 = pragmas.mulscale11(Engine.table.sintable[(ange + 2560) & 2047], zoome) / 768; //Draw white arrow
            yp1 = pragmas.mulscale11(Engine.table.sintable[(ange + 2048) & 2047], zoome) / 768;
            Engine.drawline16(Engine._device.halfxdim16 + xp1, Engine._device.midydim16 + yp1, Engine._device.halfxdim16 - xp1, Engine._device.midydim16 - yp1, 15);
            Engine.drawline16(Engine._device.halfxdim16 + xp1, Engine._device.midydim16 + yp1, Engine._device.halfxdim16 + yp1, Engine._device.midydim16 - xp1, 15);
            Engine.drawline16(Engine._device.halfxdim16 + xp1, Engine._device.midydim16 + yp1, Engine._device.halfxdim16 - yp1, Engine._device.midydim16 + xp1, 15);

            //enddrawing();	//}}}
            Engine._device.EndDrawing();
        }



        public int getceilzofslope(short sectnum, int dax, int day)
        {
            int dx, dy, i, j;
            walltype wal;

            if (!((sector[sectnum].ceilingstat & 2) != 0)) return (sector[sectnum].ceilingz);
            wal = wall[sector[sectnum].wallptr];
            dx = wall[wal.point2].x - wal.x; dy = wall[wal.point2].y - wal.y;
            i = ((int)pragmas.nsqrtasm((uint)(dx * dx + dy * dy)) << 5); if (i == 0) return (sector[sectnum].ceilingz);
            j = pragmas.dmulscale3(dx, day - wal.y, -dy, dax - wal.x);
            return (sector[sectnum].ceilingz + pragmas.scale(sector[sectnum].ceilingheinum, j, i));
        }

        public int getflorzofslope(short sectnum, int dax, int day)
        {
            int dx, dy, i, j;
            walltype wal;

            if (!((sector[sectnum].floorstat & 2) != 0)) return (sector[sectnum].floorz);
            wal = wall[sector[sectnum].wallptr];
            dx = wall[wal.point2].x - wal.x; dy = wall[wal.point2].y - wal.y;
            i = ((int)pragmas.nsqrtasm((uint)(dx * dx + dy * dy)) << 5); if (i == 0) return (sector[sectnum].floorz);
            j = pragmas.dmulscale3(dx, day - wal.y, -dy, dax - wal.x);
            return (sector[sectnum].floorz + pragmas.scale(sector[sectnum].floorheinum, j, i));
        }

        public void getzsofslope(short sectnum, int dax, int day, ref int ceilz, ref int florz)
        {
            int dx, dy, i, j;
            walltype wal, wal2;
            sectortype sec;

            sec = sector[sectnum];
            ceilz = sec.ceilingz;
            florz = sec.floorz;
            if (((sec.ceilingstat | sec.floorstat) & 2) != 0)
            {
                wal = wall[sec.wallptr];
                wal2 = wall[wal.point2];
                dx = wal2.x - wal.x; dy = wal2.y - wal.y;
                i = ((int)pragmas.nsqrtasm((uint)(dx * dx + dy * dy)) << 5); if (i == 0) return;
                j = pragmas.dmulscale3(dx, day - wal.y, -dy, dax - wal.x);
                if ((sec.ceilingstat & 2) != 0) ceilz = (ceilz) + pragmas.scale(sec.ceilingheinum, j, i);
                if ((sec.floorstat & 2) != 0) florz = (florz) + pragmas.scale(sec.floorheinum, j, i);
            }
        }

        public void dragpoint(short pointhighlight, int dax, int day)
        {
            short cnt, tempshort;

            wall[pointhighlight].x = dax;
            wall[pointhighlight].y = day;

            cnt = MAXWALLS;
            tempshort = pointhighlight;    /* search points CCW */
            do
            {
                if (wall[tempshort].nextwall >= 0)
                {
                    tempshort = wall[wall[tempshort].nextwall].point2;
                    wall[tempshort].x = dax;
                    wall[tempshort].y = day;
                }
                else
                {
                    tempshort = pointhighlight;    /* search points CW if not searched all the way around */
                    do
                    {
                        if (wall[lastwall(tempshort)].nextwall >= 0)
                        {
                            tempshort = wall[lastwall(tempshort)].nextwall;
                            wall[tempshort].x = dax;
                            wall[tempshort].y = day;
                        }
                        else
                        {
                            break;
                        }
                        cnt--;
                    }
                    while ((tempshort != pointhighlight) && (cnt > 0));
                    break;
                }
                cnt--;
            }
            while ((tempshort != pointhighlight) && (cnt > 0));
        }

        public bool cansee(int x1, int y1, int z1, short sect1, int x2, int y2, int z2, short sect2)
        {
            sectortype sec;
            walltype wal, wal2;
            int i, cnt, nexts, x, y, z, cz = 0, fz = 0, dasectnum, dacnt, danum;
            int x21, y21, z21, x31, y31, x34, y34, bot, t;

            if ((x1 == x2) && (y1 == y2))
                return (sect1 == sect2);

            x21 = x2 - x1;
            y21 = y2 - y1;
            z21 = z2 - z1;

            clipsectorlist[0] = sect1;
            danum = 1;
            for (dacnt = 0; dacnt < danum; dacnt++)
            {
                dasectnum = clipsectorlist[dacnt];
                sec = sector[dasectnum];
                int ff = 0;
                for (cnt = sec.wallnum; cnt > 0; cnt--, ff++)
                {
                    wal = wall[sec.wallptr + ff];

                    wal2 = wall[wal.point2];
                    x31 = wal.x - x1;
                    x34 = wal.x - wal2.x;
                    y31 = wal.y - y1;
                    y34 = wal.y - wal2.y;

                    bot = y21 * x34 - x21 * y34;
                    if (bot <= 0)
                        continue;

                    t = y21 * x31 - x21 * y31;
                    if ((uint)t >= (uint)bot)
                        continue;
                    t = y31 * x34 - x31 * y34;
                    if ((uint)t >= (uint)bot)
                        continue;

                    nexts = wal.nextsector;
                    if ((nexts < 0) || (wal.cstat & 32) != 0) return false;

                    t = pragmas.divscale24(t, bot);
                    x = x1 + pragmas.mulscale24(x21, t);
                    y = y1 + pragmas.mulscale24(y21, t);
                    z = z1 + pragmas.mulscale24(z21, t);

                    getzsofslope((short)dasectnum, x, y, ref cz, ref fz);
                    if ((z <= cz) || (z >= fz))
                        return false;
                    getzsofslope((short)nexts, x, y, ref cz, ref fz);
                    if ((z <= cz) || (z >= fz))
                        return (false);

                    for (i = danum - 1; i >= 0; i--)
                        if (clipsectorlist[i] == nexts)
                            break;
                    if (i < 0)
                        clipsectorlist[danum++] = nexts;
                }
            }
            for (i = danum - 1; i >= 0; i--)
                if (clipsectorlist[i] == sect2)
                    return true;
            return false;
        }
        public void alignflorslope(short dasect, int x, int y, int z)
        {
            int i, dax, day;
            walltype wal;

            wal = wall[sector[dasect].wallptr];
            dax = wall[wal.point2].x - wal.x;
            day = wall[wal.point2].y - wal.y;

            i = (y - wal.y) * dax - (x - wal.x) * day;
            if (i == 0) return;
            sector[dasect].floorheinum = (short)pragmas.scale((z - sector[dasect].floorz) << 8,
                                               pragmas.nsqrtasm((uint)(dax * dax + day * day)), i);

            if (sector[dasect].floorheinum == 0) sector[dasect].floorstat &= ~2;
            else sector[dasect].floorstat |= 2;
        }

        private void scansector(short sectnum)
        {
            walltype wal, wal2;
            spritetype spr;
            int i, xs, ys, xp, yp, x1, y1, x2, y2, xp1, yp1, xp2 = 0, yp2 = 0, templong;
            short zz, startwall, endwall, numscansbefore, scanfirst, bunchfrst;
            int z;
            short nextsectnum;

            if (sectnum < 0) return;

            //if (automapping) show2dsector[sectnum>>3] |= pow2char[sectnum&7];

            sectorborder[0] = sectnum;
            sectorbordercnt = 1;

            do
            {
                sectnum = sectorborder[--sectorbordercnt];

                for (z = headspritesect[sectnum]; z >= 0; z = nextspritesect[z])
                {
                    spr = sprite[z];
// jmarshall: hack not sure why we need this yet?
                    if (spr.picnum == 1405 && inrendermirror == false)
                        continue;

                    if ((((spr.cstat & 0x8000) == 0) || (showinvisibility)) &&
                          (spr.xrepeat > 0) && (spr.yrepeat > 0) &&
                          (spritesortcnt < MAXSPRITESONSCREEN))
                    {
                        xs = spr.x - globalposx; ys = spr.y - globalposy;
                        if ((spr.cstat & 48) != 0 || (xs * cosglobalang + ys * singlobalang > 0))
                        {
                            tsprite[spritesortcnt].Copy(spr);
                            // jv - non direct copy it?
                            //copybufbyte(spr,&tsprite[spritesortcnt],sizeof(spritetype));
                            tsprite[spritesortcnt++].owner = (short)z;
                        }
                    }
                }

                gotsector[sectnum >> 3] |= Engine.pow2char[sectnum & 7];

                bunchfrst = (short)numbunches;
                numscansbefore = (short)numscans;

                startwall = sector[sectnum].wallptr;
                endwall = (short)(startwall + sector[sectnum].wallnum);
                scanfirst = (short)numscans;


                for (z = startwall; z < endwall; z++)
                {
                    wal = wall[z];
                    nextsectnum = wal.nextsector;

                    wal2 = wall[wal.point2];
                    x1 = wal.x - globalposx; y1 = wal.y - globalposy;
                    x2 = wal2.x - globalposx; y2 = wal2.y - globalposy;

                    if ((nextsectnum >= 0) && ((wal.cstat & 32) == 0))
                        if ((gotsector[nextsectnum >> 3] & Engine.pow2char[nextsectnum & 7]) == 0)
                        {
                            templong = x1 * y2 - x2 * y1;
                            if (((uint)templong + 262144) < 524288)
                                if (pragmas.mulscale5(templong, templong) <= (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1))
                                    sectorborder[sectorbordercnt++] = nextsectnum;
                        }

                    if ((z == startwall) || (wall[z - 1].point2 != z))
                    {
                        xp1 = pragmas.dmulscale6(y1, cosglobalang, -x1, singlobalang);
                        yp1 = pragmas.dmulscale6(x1, cosviewingrangeglobalang, y1, sinviewingrangeglobalang);
                    }
                    else
                    {
                        xp1 = xp2;
                        yp1 = yp2;
                    }
                    xp2 = pragmas.dmulscale6(y2, cosglobalang, -x2, singlobalang);
                    yp2 = pragmas.dmulscale6(x2, cosviewingrangeglobalang, y2, sinviewingrangeglobalang);
                    if ((yp1 < 256) && (yp2 < 256)) goto skipitaddwall;

                    //If wall's NOT facing you
                    if (pragmas.dmulscale32(xp1, yp2, -xp2, yp1) >= 0) goto skipitaddwall;

                    if (xp1 >= -yp1)
                    {
                        if ((xp1 > yp1) || (yp1 == 0)) goto skipitaddwall;
                        xb1[numscans] = Engine._device.halfxdimen + pragmas.scale(xp1, Engine._device.halfxdimen, yp1);
                        if (xp1 >= 0) xb1[numscans]++;   //Fix for SIGNED divide
                        if (xb1[numscans] >= Engine._device.xdimen) xb1[numscans] = Engine._device.xdimen - 1;
                        yb1[numscans] = yp1;
                    }
                    else
                    {
                        if (xp2 < -yp2) goto skipitaddwall;
                        xb1[numscans] = 0;
                        templong = yp1 - yp2 + xp1 - xp2;
                        if (templong == 0) goto skipitaddwall;
                        yb1[numscans] = yp1 + pragmas.scale(yp2 - yp1, xp1 + yp1, templong);
                    }
                    if (yb1[numscans] < 256) goto skipitaddwall;

                    if (xp2 <= yp2)
                    {
                        if ((xp2 < -yp2) || (yp2 == 0)) goto skipitaddwall;
                        xb2[numscans] = Engine._device.halfxdimen + pragmas.scale(xp2, Engine._device.halfxdimen, yp2) - 1;
                        if (xp2 >= 0) xb2[numscans]++;   //Fix for SIGNED divide
                        if (xb2[numscans] >= Engine._device.xdimen) xb2[numscans] = Engine._device.xdimen - 1;
                        yb2[numscans] = yp2;
                    }
                    else
                    {
                        if (xp1 > yp1) goto skipitaddwall;
                        xb2[numscans] = Engine._device.xdimen - 1;
                        templong = xp2 - xp1 + yp1 - yp2;
                        if (templong == 0) goto skipitaddwall;
                        yb2[numscans] = yp1 + pragmas.scale(yp2 - yp1, yp1 - xp1, templong);
                    }
                    if ((yb2[numscans] < 256) || (xb1[numscans] > xb2[numscans])) goto skipitaddwall;

                    //Made it all the way!
                    thesector[numscans] = sectnum; thewall[numscans] = (short)z;
                    rx1[numscans] = xp1; ry1[numscans] = yp1;
                    rx2[numscans] = xp2; ry2[numscans] = yp2;
                    p2[numscans] = (short)(numscans + 1);
                    numscans++;
                skipitaddwall:

                    if ((wall[z].point2 < z) && (scanfirst < numscans))
                    {
                        p2[numscans - 1] = scanfirst;
                        scanfirst = (short)numscans;
                    }
                }

                for (z = numscansbefore; z < numscans; z++)
                    if ((wall[thewall[z]].point2 != thewall[p2[z]]) || (xb2[z] >= xb1[p2[z]]))
                    {
                        bunchfirst[numbunches++] = p2[z]; p2[z] = -1;
                    }

                for (z = bunchfrst; z < numbunches; z++)
                {
                    for (zz = bunchfirst[z]; p2[zz] >= 0; zz = p2[zz]) ;
                    bunchlast[z] = zz;
                }
            } while (sectorbordercnt > 0);
        }

        //
        // owallmost (internal)
        //
        private int owallmost(ref short[] mostbuf, int w, int z)
        {
            int bad = 0, inty, xcross, y, yinc;
            int s1, s2, s3, s4, ix1, ix2, iy1, iy2, t;
            int i;

            z <<= 7;
            s1 = pragmas.mulscale20(globaluclip, yb1[w]); s2 = pragmas.mulscale20(globaluclip, yb2[w]);
            s3 = pragmas.mulscale20(globaldclip, yb1[w]); s4 = pragmas.mulscale20(globaldclip, yb2[w]);
            //bad = (z<s1)+((z<s2)<<1)+((z>s3)<<2)+((z>s4)<<3);
            if (z < s1)
                bad = 1;

            if (z < s2)
                bad += 1 << 1;

            if (z > s3)
                bad += 1 << 2;

            if (z > s4)
                bad += 1 << 3;

            ix1 = xb1[w]; iy1 = yb1[w];
            ix2 = xb2[w]; iy2 = yb2[w];

            if ((bad & 3) == 3)
            {
                //clearbufbyte(ix1, ref mostbuf,(ix2-ix1+1)/**sizeof(mostbuf[0])*/,0L);
                for (i = ix1; i <= ix2; i++) mostbuf[i] = 0;
                return (bad);
            }

            if ((bad & 12) == 12)
            {
                //clearbufbyte(ix1, ref mostbuf, (ix2 - ix1 + 1)/**sizeof(mostbuf[0])*/, Engine._device.ydimen + (Engine._device.ydimen << 16));
                for (i = ix1; i <= ix2; i++) mostbuf[i] = (short)Engine._device.ydimen;
                return (bad);
            }

            if ((bad & 3) != 0)
            {
                t = pragmas.divscale30(z - s1, s2 - s1);
                inty = yb1[w] + pragmas.mulscale30(yb2[w] - yb1[w], t);
                xcross = xb1[w] + pragmas.scale(pragmas.mulscale30(yb2[w], t), xb2[w] - xb1[w], inty);

                if ((bad & 3) == 2)
                {
                    if (xb1[w] <= xcross) { iy2 = inty; ix2 = xcross; }
                    clearbufbyte(xcross + 1, ref mostbuf, (xb2[w] - xcross), 0);
                    for (i = xcross + 1; i <= xb2[w]; i++) mostbuf[i] = 0;
                }
                else
                {
                    if (xcross <= xb2[w]) { iy1 = inty; ix1 = xcross; }
                    clearbufbyte(xb1[w], ref mostbuf, (xcross - xb1[w] + 1), 0);
                    for (i = xb1[w]; i <= xcross; i++) mostbuf[i] = 0;
                }
            }

            if ((bad & 12) != 0)
            {
                t = pragmas.divscale30(z - s3, s4 - s3);
                inty = yb1[w] + pragmas.mulscale30(yb2[w] - yb1[w], t);
                xcross = xb1[w] + pragmas.scale(pragmas.mulscale30(yb2[w], t), xb2[w] - xb1[w], inty);

                if ((bad & 12) == 8)
                {
                    if (xb1[w] <= xcross) { iy2 = inty; ix2 = xcross; }
                    //clearbufbyte(xcross + 1, ref mostbuf[xcross + 1], (xb2[w] - xcross), Engine._device.ydimen + (Engine._device.ydimen << 16));
                    for (i = xcross + 1; i <= xb2[w]; i++) mostbuf[i] = (short)Engine._device.ydimen;
                }
                else
                {
                    if (xcross <= xb2[w]) { iy1 = inty; ix1 = xcross; }
                    //clearbufbyte(xb1[w], ref mostbuf, (xcross - xb1[w] + 1), Engine._device.ydimen + (Engine._device.ydimen << 16));
                    for (i = xb1[w]; i <= xcross; i++) mostbuf[i] = (short)Engine._device.ydimen;
                }
            }

            y = (pragmas.scale(z, Engine._device.xdimenscale, iy1) << 4);
            yinc = ((pragmas.scale(z, Engine._device.xdimenscale, iy2) << 4) - y) / (ix2 - ix1 + 1);
            pragmas.qinterpolatedown16short(ix1, ref mostbuf, ix2 - ix1 + 1, y + (globalhoriz << 16), yinc);

            if (mostbuf[ix1] < 0) mostbuf[ix1] = 0;
            if (mostbuf[ix1] > Engine._device.ydimen) mostbuf[ix1] = (short)Engine._device.ydimen;
            if (mostbuf[ix2] < 0) mostbuf[ix2] = 0;
            if (mostbuf[ix2] > Engine._device.ydimen) mostbuf[ix2] = (short)Engine._device.ydimen;

            return (bad);
        }

        //
        // wallmost (internal)
        //
        private int wallmost(ref short[] mostbuf, int w, int sectnum, char dastat)
        {
            int bad, i, j, t, y, z, inty, intz, xcross, yinc, fw;
            int x1, y1, z1, x2, y2, z2, xv, yv, dx, dy, dasqr, oz1, oz2;
            int s1, s2, s3, s4, ix1, ix2, iy1, iy2;
            //char datempbuf[256];

            if (dastat == 0)
            {
                z = sector[sectnum].ceilingz - globalposz;
                if ((sector[sectnum].ceilingstat & 2) == 0) return (owallmost(ref mostbuf, w, z));
            }
            else
            {
                z = sector[sectnum].floorz - globalposz;
                if ((sector[sectnum].floorstat & 2) == 0) return (owallmost(ref mostbuf, w, z));
            }

            i = thewall[w];
            if (i == sector[sectnum].wallptr) return (owallmost(ref mostbuf, w, z));

            x1 = wall[i].x; x2 = wall[wall[i].point2].x - x1;
            y1 = wall[i].y; y2 = wall[wall[i].point2].y - y1;

            fw = sector[sectnum].wallptr; i = wall[fw].point2;
            dx = wall[i].x - wall[fw].x; dy = wall[i].y - wall[fw].y;
            dasqr = pragmas.krecipasm((int)pragmas.nsqrtasm((uint)(dx * dx + dy * dy)));

            if (xb1[w] == 0)
            { xv = cosglobalang + sinviewingrangeglobalang; yv = singlobalang - cosviewingrangeglobalang; }
            else
            { xv = x1 - globalposx; yv = y1 - globalposy; }
            i = xv * (y1 - globalposy) - yv * (x1 - globalposx); j = yv * x2 - xv * y2;
            if (pragmas.klabs(j) > pragmas.klabs(i >> 3)) i = pragmas.divscale28(i, j);
            if (dastat == 0)
            {
                t = pragmas.mulscale15(sector[sectnum].ceilingheinum, dasqr);
                z1 = sector[sectnum].ceilingz;
            }
            else
            {
                t = pragmas.mulscale15(sector[sectnum].floorheinum, dasqr);
                z1 = sector[sectnum].floorz;
            }
            z1 = pragmas.dmulscale24(dx * t, pragmas.mulscale20(y2, i) + ((y1 - wall[fw].y) << 8),
                                 -dy * t, pragmas.mulscale20(x2, i) + ((x1 - wall[fw].x) << 8)) + ((z1 - globalposz) << 7);


            if (xb2[w] == Engine._device.xdimen - 1)
            { xv = cosglobalang - sinviewingrangeglobalang; yv = singlobalang + cosviewingrangeglobalang; }
            else
            { xv = (x2 + x1) - globalposx; yv = (y2 + y1) - globalposy; }
            i = xv * (y1 - globalposy) - yv * (x1 - globalposx); j = yv * x2 - xv * y2;
            if (pragmas.klabs(j) > pragmas.klabs(i >> 3)) i = pragmas.divscale28(i, j);
            if (dastat == 0)
            {
                t = pragmas.mulscale15(sector[sectnum].ceilingheinum, dasqr);
                z2 = sector[sectnum].ceilingz;
            }
            else
            {
                t = pragmas.mulscale15(sector[sectnum].floorheinum, dasqr);
                z2 = sector[sectnum].floorz;
            }
            z2 = pragmas.dmulscale24(dx * t, pragmas.mulscale20(y2, i) + ((y1 - wall[fw].y) << 8),
                                 -dy * t, pragmas.mulscale20(x2, i) + ((x1 - wall[fw].x) << 8)) + ((z2 - globalposz) << 7);


            s1 = pragmas.mulscale20(globaluclip, yb1[w]); s2 = pragmas.mulscale20(globaluclip, yb2[w]);
            s3 = pragmas.mulscale20(globaldclip, yb1[w]); s4 = pragmas.mulscale20(globaldclip, yb2[w]);
            //bad = (z1<s1)+((z2<s2)<<1)+((z1>s3)<<2)+((z2>s4)<<3);
            bad = 0;

            if (z1 < s1)
                bad = 1;

            if (z2 < s2)
                bad += 1 << 1;

            if (z1 > s3)
                bad += 1 << 2;

            if (z2 > s4)
                bad += 1 << 3;

            ix1 = xb1[w]; ix2 = xb2[w];
            iy1 = yb1[w]; iy2 = yb2[w];
            oz1 = z1; oz2 = z2;

            if ((bad & 3) == 3)
            {
                //clearbufbyte(&mostbuf[ix1],(ix2-ix1+1)*sizeof(mostbuf[0]),0L);
                for (i = ix1; i <= ix2; i++) mostbuf[i] = 0;
                return (bad);
            }

            if ((bad & 12) == 12)
            {
                //clearbufbyte(&mostbuf[ix1],(ix2-ix1+1)*sizeof(mostbuf[0]),ydimen+(ydimen<<16));
                for (i = ix1; i <= ix2; i++) mostbuf[i] = (short)Engine._device.ydimen;
                return (bad);
            }

            if ((bad & 3) != 0)
            {
                //inty = intz / (globaluclip>>16)
                t = pragmas.divscale30(oz1 - s1, s2 - s1 + oz1 - oz2);
                inty = yb1[w] + pragmas.mulscale30(yb2[w] - yb1[w], t);
                intz = oz1 + pragmas.mulscale30(oz2 - oz1, t);
                xcross = xb1[w] + pragmas.scale(pragmas.mulscale30(yb2[w], t), xb2[w] - xb1[w], inty);

                //t = divscale30((x1<<4)-xcross*yb1[w],xcross*(yb2[w]-yb1[w])-((x2-x1)<<4));
                //inty = yb1[w] + mulscale30(yb2[w]-yb1[w],t);
                //intz = z1 + mulscale30(z2-z1,t);

                if ((bad & 3) == 2)
                {
                    if (xb1[w] <= xcross) { z2 = intz; iy2 = inty; ix2 = xcross; }
                    //clearbufbyte(&mostbuf[xcross+1],(xb2[w]-xcross)*sizeof(mostbuf[0]),0L);
                    for (i = xcross + 1; i <= xb2[w]; i++) mostbuf[i] = 0;
                }
                else
                {
                    if (xcross <= xb2[w]) { z1 = intz; iy1 = inty; ix1 = xcross; }
                    //clearbufbyte(&mostbuf[xb1[w]],(xcross-xb1[w]+1)*sizeof(mostbuf[0]),0L);
                    for (i = xb1[w]; i <= xcross; i++) mostbuf[i] = 0;
                }
            }

            if ((bad & 12) != 0)
            {
                //inty = intz / (globaldclip>>16)
                t = pragmas.divscale30(oz1 - s3, s4 - s3 + oz1 - oz2);
                inty = yb1[w] + pragmas.mulscale30(yb2[w] - yb1[w], t);
                intz = oz1 + pragmas.mulscale30(oz2 - oz1, t);
                xcross = xb1[w] + pragmas.scale(pragmas.mulscale30(yb2[w], t), xb2[w] - xb1[w], inty);

                //t = divscale30((x1<<4)-xcross*yb1[w],xcross*(yb2[w]-yb1[w])-((x2-x1)<<4));
                //inty = yb1[w] + mulscale30(yb2[w]-yb1[w],t);
                //intz = z1 + mulscale30(z2-z1,t);

                if ((bad & 12) == 8)
                {
                    if (xb1[w] <= xcross) { z2 = intz; iy2 = inty; ix2 = xcross; }
                    //clearbufbyte(&mostbuf[xcross+1],(xb2[w]-xcross)*sizeof(mostbuf[0]),ydimen+(ydimen<<16));
                    for (i = xcross + 1; i <= xb2[w]; i++) mostbuf[i] = (short)Engine._device.ydimen;
                }
                else
                {
                    if (xcross <= xb2[w]) { z1 = intz; iy1 = inty; ix1 = xcross; }
                    //clearbufbyte(&mostbuf[xb1[w]],(xcross-xb1[w]+1)*sizeof(mostbuf[0]),ydimen+(ydimen<<16));
                    for (i = xb1[w]; i <= xcross; i++) mostbuf[i] = (short)Engine._device.ydimen;
                }
            }

            y = (pragmas.scale(z1, Engine._device.xdimenscale, iy1) << 4);
            yinc = ((pragmas.scale(z2, Engine._device.xdimenscale, iy2) << 4) - y) / (ix2 - ix1 + 1);
            pragmas.qinterpolatedown16short(ix1, ref mostbuf, ix2 - ix1 + 1, y + (globalhoriz << 16), yinc);

            if (mostbuf[ix1] < 0) mostbuf[ix1] = 0;
            if (mostbuf[ix1] > Engine._device.ydimen) mostbuf[ix1] = (short)Engine._device.ydimen;
            if (mostbuf[ix2] < 0) mostbuf[ix2] = 0;
            if (mostbuf[ix2] > Engine._device.ydimen) mostbuf[ix2] = (short)Engine._device.ydimen;

            return (bad);
        }

        public void updatesectorz(int x, int y, int z, ref short sectnum)
        {
            walltype wal;
            int i, j, cz = 0, fz = 0;

            getzsofslope(sectnum, x, y, ref cz, ref fz);
            if ((z >= cz) && (z <= fz))
                if (inside(x, y, sectnum) != 0) return;

            if ((sectnum >= 0) && (sectnum < numsectors))
            {
                int walnum = sector[sectnum].wallptr;

                j = sector[sectnum].wallnum;
                do
                {
                    wal = wall[walnum];
                    i = wal.nextsector;
                    if (i >= 0)
                    {
                        getzsofslope((short)i, x, y, ref cz, ref fz);
                        if ((z >= cz) && (z <= fz))
                            if (inside(x, y, (short)i) == 1)
                            { sectnum = (short)i; return; }
                    }
                    walnum++; j--;
                } while (j != 0);
            }

            for (i = numsectors - 1; i >= 0; i--)
            {
                getzsofslope((short)i, x, y, ref cz, ref fz);
                if ((z >= cz) && (z <= fz))
                    if (inside(x, y, (short)i) == 1)
                    { sectnum = (short)i; return; }
            }

            sectnum = -1;
        }

        //
        // drawsprite (internal)
        //
        private void drawsprite(int snum)
        {
            spritetype2 tspr;
            sectortype sec;
            int x;
            int startum, startdm, sectnum, xb, yp, cstat;
            int siz, xsiz, ysiz, xoff, yoff, xspan, yspan;
            int x1, y1, x2, y2, lx, rx, dalx2, darx2, i, j, k, linum, linuminc;
            int yinc, z, z1, z2, xp1, yp1, xp2, yp2;
            int xv, yv, top, topinc, bot, botinc, hplc, hinc;
            int cosang, sinang, dax, day, lpoint, lmax, rpoint, dax1, dax2, y;
            int npoints, npoints2, zz, t, zsgn, zzsgn;
            int tilenum, vtilenum = 0, spritenum;
            byte swapped, daclip;
            int rmax;

            tspr = tsprite[snum];

            xb = vissprites[snum].x;
            yp = vissprites[snum].y;
            tilenum = tspr.picnum;
            spritenum = tspr.owner;
            cstat = tspr.cstat;

            if ((cstat & 48) != 48 && (Engine.tiletovox[tilenum] != -1))
            {
                vtilenum = Engine.tiletovox[tilenum];
                cstat |= 48;
            }
            /*
                    #ifdef SUPERBUILD
                        if ((cstat&48)==48) vtilenum = tilenum;	// if the game wants voxels, it gets voxels
                        else if ((cstat&48)!=48 && (usevoxels) && (tiletovox[tilenum] != -1)
                    #if defined(POLYMOST) && defined(USE_OPENGL)
                             && (!(spriteext[tspr.owner].flags&SPREXT_NOTMD))
                    #endif
                           ) {
                            vtilenum = tiletovox[tilenum];
                            cstat |= 48;
                        }
                    #endif
            */
            if ((cstat & 48) != 48)
            {
                if ((Engine.picanm[tilenum] & 192) != 0) tilenum += Engine.animateoffs((short)tilenum, (short)(spritenum + 32768));
                if ((Engine.tilesizx[tilenum] <= 0) || (Engine.tilesizy[tilenum] <= 0) || (spritenum < 0))
                    return;
            }
            if ((tspr.xrepeat <= 0) || (tspr.yrepeat <= 0)) return;

            sectnum = tspr.sectnum; sec = sector[sectnum];
            globalpal = tspr.pal;
            // jv - removed
            //if (Engine.palette.isLookupValid(globalpal) == false) globalpal = 0;	// JBF: fixes null-pointer crash
            // jv end
            globalshade = tspr.shade;
            if ((cstat & 2) != 0)
            {
                if ((cstat & 512) != 0) A.settransreverse(); else A.settransnormal();
            }

            xoff = (int)((sbyte)((Engine.picanm[tilenum] >> 8) & 255)) + ((int)tspr.xoffset);
            yoff = (int)((sbyte)((Engine.picanm[tilenum] >> 16) & 255)) + ((int)tspr.yoffset);

            int cstatval = (cstat & 48);

// jmarshall - would we ever need opt out per picnum voxel bits?
            if(Engine.tiletovox[tspr.picnum] >= 0)
            {
                cstatval |= 48;
            }
// jmarshall end

            switch (cstatval)
            {
                case 0:
                    {
                        // jv
                        //		        if (yp <= (4<<8)) return;
                        // jv end
                        siz = pragmas.divscale19(Engine._device.xdimenscale, yp);

                        xv = pragmas.mulscale16(((int)tspr.xrepeat) << 16, Engine._device.xyaspect);

                        xspan = Engine.tilesizx[tilenum];
                        yspan = Engine.tilesizy[tilenum];
                        xsiz = pragmas.mulscale30(siz, xv * xspan);
                        ysiz = pragmas.mulscale14(siz, tspr.yrepeat * yspan);
                        // jv - removed
                        //        if (((Engine.tilesizx[tilenum]>>11) >= xsiz) || (yspan >= (ysiz>>1)))
                        //	        return;  //Watch out for divscale overflow
                        // jv end
                        x1 = xb - (xsiz >> 1);
                        if ((xspan & 1) != 0) x1 += pragmas.mulscale31(siz, xv);  //Odd xspans
                        i = pragmas.mulscale30(siz, xv * xoff);
                        if ((cstat & 4) == 0) x1 -= i; else x1 += i;

                        y1 = pragmas.mulscale16(tspr.z - globalposz, siz);
                        y1 -= pragmas.mulscale14(siz, tspr.yrepeat * yoff);
                        y1 += (globalhoriz << 8) - ysiz;
                        if ((cstat & 128) != 0)
                        {
                            y1 += (ysiz >> 1);
                            if ((yspan & 1) != 0) y1 += pragmas.mulscale15(siz, tspr.yrepeat);  //Odd yspans
                        }

                        x2 = x1 + xsiz - 1;
                        y2 = y1 + ysiz - 1;
                        if ((y1 | 255) >= (y2 | 255)) return;

                        lx = (x1 >> 8) + 1; if (lx < 0) lx = 0;
                        rx = (x2 >> 8); if (rx >= Engine._device.xdimen) rx = Engine._device.xdimen - 1;
                        if (lx > rx) return;

                        yinc = pragmas.divscale32(yspan, ysiz);

                        if ((sec.ceilingstat & 3) == 0)
                            startum = globalhoriz + pragmas.mulscale24(siz, sec.ceilingz - globalposz) - 1;
                        else
                            startum = 0;
                        if ((sec.floorstat & 3) == 0)
                            startdm = globalhoriz + pragmas.mulscale24(siz, sec.floorz - globalposz) + 1;
                        else
                            startdm = 0x7fffffff;
                        if ((y1 >> 8) > startum) startum = (y1 >> 8);
                        if ((y2 >> 8) < startdm) startdm = (y2 >> 8);

                        if (startum < -32768) startum = -32768;
                        if (startdm > 32767) startdm = 32767;
                        if (startum >= startdm) return;

                        if ((cstat & 4) == 0)
                        {
                            linuminc = pragmas.divscale24(xspan, xsiz);
                            linum = pragmas.mulscale8((lx << 8) - x1, linuminc);
                        }
                        else
                        {
                            linuminc = -pragmas.divscale24(xspan, xsiz);
                            linum = pragmas.mulscale8((lx << 8) - x2, linuminc);
                        }
                        if ((cstat & 8) > 0)
                        {
                            yinc = -yinc;
                            i = y1; y1 = y2; y2 = i;
                        }

                        for (x = lx; x <= rx; x++)
                        {
                            uwall[x] = (short)Math.Max(Engine._device.startumost[x + Engine._device.windowx1] - Engine._device.windowy1, (short)startum);
                            dwall[x] = (short)Math.Min(Engine._device.startdmost[x + Engine._device.windowx1] - Engine._device.windowy1, (short)startdm);
                        }
                        daclip = 0;
                        for (i = smostwallcnt - 1; i >= 0; i--)
                        {
                            if ((smostwalltype[i] & daclip) != 0) continue;
                            j = smostwall[i];
                            if ((xb1[j] > rx) || (xb2[j] < lx)) continue;
                            if ((yp <= yb1[j]) && (yp <= yb2[j])) continue;
                            if (spritewallfront(tspr, (int)thewall[j]) && ((yp <= yb1[j]) || (yp <= yb2[j]))) continue;

                            dalx2 = Math.Max(xb1[j], lx); darx2 = Math.Min(xb2[j], rx);


                            switch (smostwalltype[i])
                            {
                                case 0:
                                    if (dalx2 <= darx2)
                                    {
                                        if ((dalx2 == lx) && (darx2 == rx)) return;
                                        //clearbufbyte(&dwall[dalx2],(darx2-dalx2+1)*sizeof(dwall[0]),0L);
                                        for (k = dalx2; k <= darx2; k++) dwall[k] = 0;
                                    }
                                    break;
                                case 1:
                                    k = smoststart[i] - xb1[j];
                                    for (x = dalx2; x <= darx2; x++)
                                    {
                                        if (smost[k + x] > uwall[x]) uwall[x] = smost[k + x];
                                    }
                                    if ((dalx2 == lx) && (darx2 == rx)) daclip |= 1;
                                    break;
                                case 2:
                                    k = smoststart[i] - xb1[j];
                                    for (x = dalx2; x <= darx2; x++)
                                    {
                                        if (smost[k + x] < dwall[x]) dwall[x] = smost[k + x];
                                    }
                                    if ((dalx2 == lx) && (darx2 == rx)) daclip |= 2;
                                    break;
                            }
                        }

                        if (uwall[rx] >= dwall[rx])
                        {
                            for (x = lx; x < rx; x++)
                                if (uwall[x] < dwall[x]) break;
                            if (x == rx) return;
                        }

                        //sprite
                        if ((Engine.searchit >= 1) && (Engine.searchx >= lx) && (Engine.searchx <= rx))
                            if ((Engine.searchy >= uwall[Engine.searchx]) && (Engine.searchy < dwall[Engine.searchx]))
                            {
                                Engine.searchsector = sectnum; Engine.searchwall = spritenum;
                                Engine.searchstat = 3; Engine.searchit = 1;
                            }

                        z2 = tspr.z - ((yoff * tspr.yrepeat) << 2);
                        if ((cstat & 128) != 0)
                        {
                            z2 += ((yspan * tspr.yrepeat) << 1);
                            if ((yspan & 1) != 0) z2 += (tspr.yrepeat << 1);        //Odd yspans
                        }
                        z1 = z2 - ((yspan * tspr.yrepeat) << 2);

                        globalorientation = 0;
                        globalpicnum = tilenum;
                        if (globalpicnum >= MAXTILES) globalpicnum = 0;
                        globalxpanning = 0;
                        globalypanning = 0;
                        globvis = globalvisibility;
                        if (sec.visibility != 0) globvis = pragmas.mulscale4(globvis, (int)((byte)(sec.visibility + 16)));
                        globalshiftval = (Engine.picsiz[globalpicnum] >> 4);
                        if (Engine.pow2long[globalshiftval] != Engine.tilesizy[globalpicnum]) globalshiftval++;
                        globalshiftval = 32 - globalshiftval;
                        globalyscale = pragmas.divscale(512, tspr.yrepeat, globalshiftval - 19);
                        globalzd = (((globalposz - z1) * globalyscale) << 8);
                        if ((cstat & 8) > 0)
                        {
                            globalyscale = -globalyscale;
                            globalzd = (((globalposz - z2) * globalyscale) << 8);
                        }

                        pragmas.qinterpolatedown16(lx, ref lwall, rx - lx + 1, linum, linuminc);
                        clearbuf(lx, ref swall, rx - lx + 1, pragmas.mulscale19(yp, Engine._device.xdimscale));

                        if ((cstat & 2) == 0)
                            maskwallscan(lx, rx, ref uwall, ref dwall, ref swall, ref lwall);
                        else
                            transmaskwallscan(lx, rx);
                    }
                    break;
                //else if ((cstat&48) == 16) // wall sprite
                case 16:
                    {
                        if ((cstat & 4) > 0) xoff = -xoff;
                        if ((cstat & 8) > 0) yoff = -yoff;

                        xspan = Engine.tilesizx[tilenum]; yspan = Engine.tilesizy[tilenum];
                        xv = tspr.xrepeat * Engine.table.sintable[(tspr.ang + 2560 + 1536) & 2047];
                        yv = tspr.xrepeat * Engine.table.sintable[(tspr.ang + 2048 + 1536) & 2047];
                        i = (xspan >> 1) + xoff;
                        x1 = tspr.x - globalposx - pragmas.mulscale16(xv, i); x2 = x1 + pragmas.mulscale16(xv, xspan);
                        y1 = tspr.y - globalposy - pragmas.mulscale16(yv, i); y2 = y1 + pragmas.mulscale16(yv, xspan);

                        yp1 = pragmas.dmulscale6(x1, cosviewingrangeglobalang, y1, sinviewingrangeglobalang);
                        yp2 = pragmas.dmulscale6(x2, cosviewingrangeglobalang, y2, sinviewingrangeglobalang);
                        if ((yp1 <= 0) && (yp2 <= 0))
                            return;
                        xp1 = pragmas.dmulscale6(y1, cosglobalang, -x1, singlobalang);
                        xp2 = pragmas.dmulscale6(y2, cosglobalang, -x2, singlobalang);

                        x1 += globalposx; y1 += globalposy;
                        x2 += globalposx; y2 += globalposy;

                        swapped = 0;
                        if (pragmas.dmulscale32(xp1, yp2, -xp2, yp1) >= 0)  //If wall's NOT facing you
                        {
                            if ((cstat & 64) != 0) return;
                            i = xp1; xp1 = xp2; xp2 = i;
                            i = yp1; yp1 = yp2; yp2 = i;
                            i = x1; x1 = x2; x2 = i;
                            i = y1; y1 = y2; y2 = i;
                            swapped = 1;
                        }

                        if (xp1 >= -yp1)
                        {
                            if (xp1 > yp1) return;

                            if (yp1 == 0) return;
                            xb1[MAXWALLSB - 1] = Engine._device.halfxdimen + pragmas.scale(xp1, Engine._device.halfxdimen, yp1);
                            if (xp1 >= 0) xb1[MAXWALLSB - 1]++;   //Fix for SIGNED divide
                            if (xb1[MAXWALLSB - 1] >= Engine._device.xdimen) xb1[MAXWALLSB - 1] = Engine._device.xdimen - 1;
                            yb1[MAXWALLSB - 1] = yp1;
                        }
                        else
                        {
                            if (xp2 < -yp2) return;
                            xb1[MAXWALLSB - 1] = 0;
                            i = yp1 - yp2 + xp1 - xp2;
                            if (i == 0) return;
                            yb1[MAXWALLSB - 1] = yp1 + pragmas.scale(yp2 - yp1, xp1 + yp1, i);
                        }
                        if (xp2 <= yp2)
                        {
                            if (xp2 < -yp2) return;

                            if (yp2 == 0) return;
                            xb2[MAXWALLSB - 1] = Engine._device.halfxdimen + pragmas.scale(xp2, Engine._device.halfxdimen, yp2) - 1;
                            if (xp2 >= 0) xb2[MAXWALLSB - 1]++;   //Fix for SIGNED divide
                            if (xb2[MAXWALLSB - 1] >= Engine._device.xdimen) xb2[MAXWALLSB - 1] = Engine._device.xdimen - 1;
                            yb2[MAXWALLSB - 1] = yp2;
                        }
                        else
                        {
                            if (xp1 > yp1) return;

                            xb2[MAXWALLSB - 1] = Engine._device.xdimen - 1;
                            i = xp2 - xp1 + yp1 - yp2;
                            if (i == 0) return;
                            yb2[MAXWALLSB - 1] = yp1 + pragmas.scale(yp2 - yp1, yp1 - xp1, i);
                        }

                        if ((yb1[MAXWALLSB - 1] < 256) || (yb2[MAXWALLSB - 1] < 256) || (xb1[MAXWALLSB - 1] > xb2[MAXWALLSB - 1]))
                            return;

                        topinc = -pragmas.mulscale10(yp1, xspan);
                        top = (((pragmas.mulscale10(xp1, Engine._device.xdimen) - pragmas.mulscale9(xb1[MAXWALLSB - 1] - Engine._device.halfxdimen, yp1)) * xspan) >> 3);
                        botinc = ((yp2 - yp1) >> 8);
                        bot = pragmas.mulscale11(xp1 - xp2, Engine._device.xdimen) + pragmas.mulscale2(xb1[MAXWALLSB - 1] - Engine._device.halfxdimen, botinc);

                        j = xb2[MAXWALLSB - 1] + 3;
                        z = pragmas.mulscale20(top, pragmas.krecipasm(bot));
                        lwall[xb1[MAXWALLSB - 1]] = (z >> 8);
                        for (x = xb1[MAXWALLSB - 1] + 4; x <= j; x += 4)
                        {
                            top += topinc; bot += botinc;
                            zz = z; z = pragmas.mulscale20(top, pragmas.krecipasm(bot));
                            lwall[x] = (z >> 8);
                            i = ((z + zz) >> 1);
                            lwall[x - 2] = (i >> 8);
                            lwall[x - 3] = ((i + zz) >> 9);
                            lwall[x - 1] = ((i + z) >> 9);
                        }

                        if (lwall[xb1[MAXWALLSB - 1]] < 0) lwall[xb1[MAXWALLSB - 1]] = 0;
                        if (lwall[xb2[MAXWALLSB - 1]] >= xspan) lwall[xb2[MAXWALLSB - 1]] = xspan - 1;
                        // jv
                        int sval2 = 0;

                        if ((cstat & 4) > 0)
                            sval2 = 1;
                        if ((swapped ^ (sval2)) > 0)
                        // jv end
                        {
                            j = xspan - 1;
                            for (x = xb1[MAXWALLSB - 1]; x <= xb2[MAXWALLSB - 1]; x++)
                                lwall[x] = j - lwall[x];
                        }

                        rx1[MAXWALLSB - 1] = xp1; ry1[MAXWALLSB - 1] = yp1;
                        rx2[MAXWALLSB - 1] = xp2; ry2[MAXWALLSB - 1] = yp2;

                        hplc = pragmas.divscale19(Engine._device.xdimenscale, yb1[MAXWALLSB - 1]);
                        hinc = pragmas.divscale19(Engine._device.xdimenscale, yb2[MAXWALLSB - 1]);
                        hinc = (hinc - hplc) / (xb2[MAXWALLSB - 1] - xb1[MAXWALLSB - 1] + 1);

                        z2 = tspr.z - ((yoff * tspr.yrepeat) << 2);
                        if ((cstat & 128) != 0)
                        {
                            z2 += ((yspan * tspr.yrepeat) << 1);
                            if ((yspan & 1) != 0) z2 += (tspr.yrepeat << 1);        //Odd yspans
                        }
                        z1 = z2 - ((yspan * tspr.yrepeat) << 2);

                        globalorientation = 0;
                        globalpicnum = tilenum;
                        if (globalpicnum >= MAXTILES) globalpicnum = 0;
                        globalxpanning = 0;
                        globalypanning = 0;
                        globvis = globalvisibility;
                        if (sec.visibility != 0) globvis = pragmas.mulscale4(globvis, (int)((byte)(sec.visibility + 16)));
                        globalshiftval = (Engine.picsiz[globalpicnum] >> 4);
                        if (Engine.pow2long[globalshiftval] != Engine.tilesizy[globalpicnum]) globalshiftval++;
                        globalshiftval = 32 - globalshiftval;
                        globalyscale = pragmas.divscale(512, tspr.yrepeat, globalshiftval - 19);
                        globalzd = (((globalposz - z1) * globalyscale) << 8);
                        if ((cstat & 8) > 0)
                        {
                            globalyscale = -globalyscale;
                            globalzd = (((globalposz - z2) * globalyscale) << 8);
                        }

                        if (((sec.ceilingstat & 1) == 0) && (z1 < sec.ceilingz))
                            z1 = sec.ceilingz;
                        if (((sec.floorstat & 1) == 0) && (z2 > sec.floorz))
                            z2 = sec.floorz;

                        owallmost(ref uwall, (int)(MAXWALLSB - 1), z1 - globalposz);
                        owallmost(ref dwall, (int)(MAXWALLSB - 1), z2 - globalposz);
                        for (i = xb1[MAXWALLSB - 1]; i <= xb2[MAXWALLSB - 1]; i++)
                        { swall[i] = (pragmas.krecipasm(hplc) << 2); hplc += hinc; }

                        for (i = smostwallcnt - 1; i >= 0; i--)
                        {
                            j = smostwall[i];

                            if ((xb1[j] > xb2[MAXWALLSB - 1]) || (xb2[j] < xb1[MAXWALLSB - 1])) continue;

                            dalx2 = xb1[j]; darx2 = xb2[j];
                            if (Math.Max(yb1[MAXWALLSB - 1], yb2[MAXWALLSB - 1]) > Math.Min(yb1[j], yb2[j]))
                            {
                                if (Math.Min(yb1[MAXWALLSB - 1], yb2[MAXWALLSB - 1]) > Math.Max(yb1[j], yb2[j]))
                                {
                                    // jv
                                    x = -2147483648; // 0x80000000;
                                    // jv end
                                }
                                else
                                {
                                    x = thewall[j]; xp1 = wall[x].x; yp1 = wall[x].y;
                                    x = wall[x].point2; xp2 = wall[x].x; yp2 = wall[x].y;

                                    z1 = (xp2 - xp1) * (y1 - yp1) - (yp2 - yp1) * (x1 - xp1);
                                    z2 = (xp2 - xp1) * (y2 - yp1) - (yp2 - yp1) * (x2 - xp1);
                                    if ((z1 ^ z2) >= 0)
                                        x = (z1 + z2);
                                    else
                                    {
                                        z1 = (x2 - x1) * (yp1 - y1) - (y2 - y1) * (xp1 - x1);
                                        z2 = (x2 - x1) * (yp2 - y1) - (y2 - y1) * (xp2 - x1);

                                        if ((z1 ^ z2) >= 0)
                                            x = -(z1 + z2);
                                        else
                                        {
                                            if ((xp2 - xp1) * (tspr.y - yp1) == (tspr.x - xp1) * (yp2 - yp1))
                                            {
                                                if (wall[thewall[j]].nextsector == tspr.sectnum)
                                                {
                                                    // jv
                                                    x = -2147483648; // 0x80000000;
                                                    // jv end
                                                }
                                                else
                                                {
                                                    // jv
                                                    x = 2147483647; // 0x7fffffff;
                                                    // jv end
                                                }
                                            }
                                            else
                                            {     //INTERSECTION!
                                                x = (xp1 - globalposx) + pragmas.scale(xp2 - xp1, z1, z1 - z2);
                                                y = (yp1 - globalposy) + pragmas.scale(yp2 - yp1, z1, z1 - z2);

                                                yp1 = pragmas.dmulscale14(x, cosglobalang, y, singlobalang);
                                                if (yp1 > 0)
                                                {
                                                    xp1 = pragmas.dmulscale14(y, cosglobalang, (int)-x, singlobalang);

                                                    x = Engine._device.halfxdimen + pragmas.scale(xp1, Engine._device.halfxdimen, yp1);
                                                    if (xp1 >= 0) x++;   //Fix for SIGNED divide

                                                    if (z1 < 0)
                                                    { if (dalx2 < x) dalx2 = x; }
                                                    else
                                                    { if (darx2 > x) darx2 = x; }

                                                    // jv
                                                    x = -2147483647; // 0x80000001;
                                                    // jv end
                                                }
                                                else
                                                {
                                                    // jv
                                                    //x = 0x7fffffff;
                                                    x = 2147483647;
                                                    // jv end
                                                }
                                            }
                                        }
                                    }
                                }


                                if (x < 0)
                                {
                                    if (dalx2 < xb1[MAXWALLSB - 1]) dalx2 = xb1[MAXWALLSB - 1];
                                    if (darx2 > xb2[MAXWALLSB - 1]) darx2 = xb2[MAXWALLSB - 1];
                                    switch (smostwalltype[i])
                                    {
                                        case 0:
                                            if (dalx2 <= darx2)
                                            {
                                                if ((dalx2 == xb1[MAXWALLSB - 1]) && (darx2 == xb2[MAXWALLSB - 1])) return;
                                                //clearbufbyte(&dwall[dalx2],(darx2-dalx2+1)*sizeof(dwall[0]),0L);
                                                for (k = dalx2; k <= darx2; k++) dwall[k] = 0;
                                            }
                                            break;
                                        case 1:

                                            k = smoststart[i] - xb1[j];
                                            for (x = dalx2; x <= darx2; x++)
                                            {
                                                if (smost[k + x] > uwall[x]) uwall[x] = smost[k + x];
                                            }
                                            break;
                                        case 2:
                                            k = smoststart[i] - xb1[j];
                                            for (x = dalx2; x <= darx2; x++)
                                            {
                                                if (smost[k + x] < dwall[x]) dwall[x] = smost[k + x];
                                            }
                                            break;
                                    }
                                }
                            }
                        }

                        //sprite
                        if ((Engine.searchit >= 1) && (Engine.searchx >= xb1[MAXWALLSB - 1]) && (Engine.searchx <= xb2[MAXWALLSB - 1]))
                            if ((Engine.searchy >= uwall[Engine.searchx]) && (Engine.searchy <= dwall[Engine.searchx]))
                            {
                                Engine.searchsector = sectnum; Engine.searchwall = spritenum;
                                Engine.searchstat = 3; Engine.searchit = 1;
                            }

                        if ((cstat & 2) == 0)
                        {
                            maskwallscan(xb1[MAXWALLSB - 1], xb2[MAXWALLSB - 1], ref uwall, ref dwall, ref swall, ref lwall);
                        }
                        else
                        {
                            transmaskwallscan(xb1[MAXWALLSB - 1], xb2[MAXWALLSB - 1]);
                        }
                    }
                    break;
                case 32: // floorsprite
                    {
                        if ((cstat & 64) != 0)
                            if ((globalposz > tspr.z) == ((cstat & 8) == 0))
                                return;

                        if ((cstat & 4) > 0) xoff = -xoff;
                        if ((cstat & 8) > 0) yoff = -yoff;
                        xspan = Engine.tilesizx[tilenum];
                        yspan = Engine.tilesizy[tilenum];

                        //Rotate center point
                        dax = tspr.x - globalposx;
                        day = tspr.y - globalposy;
                        rzi[0] = pragmas.dmulscale10(cosglobalang, dax, singlobalang, day);
                        rxi[0] = pragmas.dmulscale10(cosglobalang, day, -singlobalang, dax);

                        //Get top-left corner
                        i = ((tspr.ang + 2048 - globalang) & 2047);
                        cosang = Engine.table.sintable[(i + 512) & 2047]; sinang = Engine.table.sintable[i];
                        dax = ((xspan >> 1) + xoff) * tspr.xrepeat;
                        day = ((yspan >> 1) + yoff) * tspr.yrepeat;
                        rzi[0] += pragmas.dmulscale12(sinang, dax, cosang, day);
                        rxi[0] += pragmas.dmulscale12(sinang, day, -cosang, dax);

                        //Get other 3 corners
                        dax = xspan * tspr.xrepeat;
                        day = yspan * tspr.yrepeat;
                        rzi[1] = rzi[0] - pragmas.mulscale12(sinang, dax);
                        rxi[1] = rxi[0] + pragmas.mulscale12(cosang, dax);
                        dax = -pragmas.mulscale12(cosang, day);
                        day = -pragmas.mulscale12(sinang, day);
                        rzi[2] = rzi[1] + dax; rxi[2] = rxi[1] + day;
                        rzi[3] = rzi[0] + dax; rxi[3] = rxi[0] + day;

                        //Put all points on same z
                        ryi[0] = pragmas.scale((tspr.z - globalposz), Engine._device.yxaspect, 320 << 8);
                        if (ryi[0] == 0) return;
                        ryi[1] = ryi[2] = ryi[3] = ryi[0];

                        if ((cstat & 4) == 0)
                        { z = 0; z1 = 1; z2 = 3; }
                        else
                        { z = 1; z1 = 0; z2 = 2; }

                        dax = rzi[z1] - rzi[z]; day = rxi[z1] - rxi[z];
                        bot = pragmas.dmulscale8(dax, dax, day, day);
                        if (((pragmas.klabs(dax) >> 13) >= bot) || ((pragmas.klabs(day) >> 13) >= bot)) return;
                        globalx1 = pragmas.divscale18(dax, bot);
                        globalx2 = pragmas.divscale18(day, bot);

                        dax = rzi[z2] - rzi[z]; day = rxi[z2] - rxi[z];
                        bot = pragmas.dmulscale8(dax, dax, day, day);
                        if (((pragmas.klabs(dax) >> 13) >= bot) || ((pragmas.klabs(day) >> 13) >= bot)) return;
                        globaly1 = pragmas.divscale18(dax, bot);
                        globaly2 = pragmas.divscale18(day, bot);

                        //Calculate globals for hline texture mapping function
                        globalxpanning = (rxi[z] << 12);
                        globalypanning = (rzi[z] << 12);
                        globalzd = (ryi[z] << 12);

                        rzi[0] = pragmas.mulscale16(rzi[0], Engine._device.viewingrange);
                        rzi[1] = pragmas.mulscale16(rzi[1], Engine._device.viewingrange);
                        rzi[2] = pragmas.mulscale16(rzi[2], Engine._device.viewingrange);
                        rzi[3] = pragmas.mulscale16(rzi[3], Engine._device.viewingrange);

                        if (ryi[0] < 0)   //If ceilsprite is above you, reverse order of points
                        {
                            i = rxi[1]; rxi[1] = rxi[3]; rxi[3] = i;
                            i = rzi[1]; rzi[1] = rzi[3]; rzi[3] = i;
                        }


                        //Clip polygon in 3-space
                        npoints = 4;

                        //Clip edge 1
                        npoints2 = 0;
                        zzsgn = rxi[0] + rzi[0];
                        for (z = 0; z < npoints; z++)
                        {
                            zz = z + 1; if (zz == npoints) zz = 0;
                            zsgn = zzsgn; zzsgn = rxi[zz] + rzi[zz];
                            if (zsgn >= 0)
                            {
                                rxi2[npoints2] = rxi[z]; ryi2[npoints2] = ryi[z]; rzi2[npoints2] = rzi[z];
                                npoints2++;
                            }
                            if ((zsgn ^ zzsgn) < 0)
                            {
                                t = pragmas.divscale30(zsgn, zsgn - zzsgn);
                                rxi2[npoints2] = rxi[z] + pragmas.mulscale30(t, rxi[zz] - rxi[z]);
                                ryi2[npoints2] = ryi[z] + pragmas.mulscale30(t, ryi[zz] - ryi[z]);
                                rzi2[npoints2] = rzi[z] + pragmas.mulscale30(t, rzi[zz] - rzi[z]);
                                npoints2++;
                            }
                        }
                        if (npoints2 <= 2) return;

                        //Clip edge 2
                        npoints = 0;
                        zzsgn = rxi2[0] - rzi2[0];
                        for (z = 0; z < npoints2; z++)
                        {
                            zz = z + 1; if (zz == npoints2) zz = 0;
                            zsgn = zzsgn; zzsgn = rxi2[zz] - rzi2[zz];
                            if (zsgn <= 0)
                            {
                                rxi[npoints] = rxi2[z]; ryi[npoints] = ryi2[z]; rzi[npoints] = rzi2[z];
                                npoints++;
                            }
                            if ((zsgn ^ zzsgn) < 0)
                            {
                                t = pragmas.divscale30(zsgn, zsgn - zzsgn);
                                rxi[npoints] = rxi2[z] + pragmas.mulscale30(t, rxi2[zz] - rxi2[z]);
                                ryi[npoints] = ryi2[z] + pragmas.mulscale30(t, ryi2[zz] - ryi2[z]);
                                rzi[npoints] = rzi2[z] + pragmas.mulscale30(t, rzi2[zz] - rzi2[z]);
                                npoints++;
                            }
                        }
                        if (npoints <= 2) return;

                        //Clip edge 3
                        npoints2 = 0;
                        zzsgn = ryi[0] * Engine._device.halfxdimen + (rzi[0] * (globalhoriz - 0));
                        for (z = 0; z < npoints; z++)
                        {
                            zz = z + 1; if (zz == npoints) zz = 0;
                            zsgn = zzsgn; zzsgn = ryi[zz] * Engine._device.halfxdimen + (rzi[zz] * (globalhoriz - 0));
                            if (zsgn >= 0)
                            {
                                rxi2[npoints2] = rxi[z];
                                ryi2[npoints2] = ryi[z];
                                rzi2[npoints2] = rzi[z];
                                npoints2++;
                            }
                            if ((zsgn ^ zzsgn) < 0)
                            {
                                t = pragmas.divscale30(zsgn, zsgn - zzsgn);
                                rxi2[npoints2] = rxi[z] + pragmas.mulscale30(t, rxi[zz] - rxi[z]);
                                ryi2[npoints2] = ryi[z] + pragmas.mulscale30(t, ryi[zz] - ryi[z]);
                                rzi2[npoints2] = rzi[z] + pragmas.mulscale30(t, rzi[zz] - rzi[z]);
                                npoints2++;
                            }
                        }
                        if (npoints2 <= 2) return;

                        //Clip edge 4
                        npoints = 0;
                        zzsgn = ryi2[0] * Engine._device.halfxdimen + (rzi2[0] * (globalhoriz - Engine._device.ydimen));
                        for (z = 0; z < npoints2; z++)
                        {
                            zz = z + 1; if (zz == npoints2) zz = 0;
                            zsgn = zzsgn; zzsgn = ryi2[zz] * Engine._device.halfxdimen + (rzi2[zz] * (globalhoriz - Engine._device.ydimen));
                            if (zsgn <= 0)
                            {
                                rxi[npoints] = rxi2[z];
                                ryi[npoints] = ryi2[z];
                                rzi[npoints] = rzi2[z];
                                npoints++;
                            }
                            if ((zsgn ^ zzsgn) < 0)
                            {
                                t = pragmas.divscale30(zsgn, zsgn - zzsgn);
                                rxi[npoints] = rxi2[z] + pragmas.mulscale30(t, rxi2[zz] - rxi2[z]);
                                ryi[npoints] = ryi2[z] + pragmas.mulscale30(t, ryi2[zz] - ryi2[z]);
                                rzi[npoints] = rzi2[z] + pragmas.mulscale30(t, rzi2[zz] - rzi2[z]);
                                npoints++;
                            }
                        }
                        if (npoints <= 2) return;

                        //Project onto screen
                        lpoint = -1; lmax = 0x7fffffff;
                        rpoint = -1;
                        // jv
                        rmax = -2147483648;//0x80000000;
                        // jv end
                        for (z = 0; z < npoints; z++)
                        {
                            xsi[z] = pragmas.scale(rxi[z], Engine._device.xdimen << 15, rzi[z]) + (Engine._device.xdimen << 15);
                            ysi[z] = pragmas.scale(ryi[z], Engine._device.xdimen << 15, rzi[z]) + (globalhoriz << 16);
                            if (xsi[z] < 0) xsi[z] = 0;
                            if (xsi[z] > (Engine._device.xdimen << 16)) xsi[z] = (Engine._device.xdimen << 16);
                            if (ysi[z] < ((int)0 << 16)) ysi[z] = ((int)0 << 16);
                            if (ysi[z] > ((int)Engine._device.ydimen << 16)) ysi[z] = ((int)Engine._device.ydimen << 16);
                            if (xsi[z] < lmax) { lmax = xsi[z]; lpoint = z; }
                            if (xsi[z] > rmax) { rmax = xsi[z]; rpoint = z; }
                        }

                        //Get uwall arrays
                        for (z = lpoint; z != rpoint; z = zz)
                        {
                            zz = z + 1; if (zz == npoints) zz = 0;

                            dax1 = ((xsi[z] + 65535) >> 16);
                            dax2 = ((xsi[zz] + 65535) >> 16);
                            if (dax2 > dax1)
                            {
                                yinc = pragmas.divscale16(ysi[zz] - ysi[z], xsi[zz] - xsi[z]);
                                y = ysi[z] + pragmas.mulscale16((dax1 << 16) - xsi[z], yinc);
                                pragmas.qinterpolatedown16short(dax1, ref uwall, dax2 - dax1, y, yinc);
                            }
                        }

                        //Get dwall arrays
                        for (; z != lpoint; z = zz)
                        {
                            zz = z + 1; if (zz == npoints) zz = 0;

                            dax1 = ((xsi[zz] + 65535) >> 16);
                            dax2 = ((xsi[z] + 65535) >> 16);
                            if (dax2 > dax1)
                            {
                                yinc = pragmas.divscale16(ysi[zz] - ysi[z], xsi[zz] - xsi[z]);
                                y = ysi[zz] + pragmas.mulscale16((dax1 << 16) - xsi[zz], yinc);
                                pragmas.qinterpolatedown16short(dax1, ref dwall, dax2 - dax1, y, yinc);
                            }
                        }


                        lx = ((lmax + 65535) >> 16);
                        rx = (int)((rmax + 65535) >> 16);
                        for (x = lx; x <= rx; x++)
                        {
                            uwall[x] = (short)Math.Max((int)uwall[x], Engine._device.startumost[x + Engine._device.windowx1] - Engine._device.windowy1);
                            dwall[x] = (short)Math.Min((int)dwall[x], Engine._device.startdmost[x + Engine._device.windowx1] - Engine._device.windowy1);
                        }

                        //Additional uwall/dwall clipping goes here
                        for (i = smostwallcnt - 1; i >= 0; i--)
                        {
                            j = smostwall[i];
                            if ((xb1[j] > rx) || (xb2[j] < lx)) continue;
                            if ((yp <= yb1[j]) && (yp <= yb2[j])) continue;

                            //if (spritewallfront(tspr,thewall[j]) == 0)
                            x = thewall[j]; xp1 = wall[x].x; yp1 = wall[x].y;
                            x = wall[x].point2; xp2 = wall[x].x; yp2 = wall[x].y;
                            x = (xp2 - xp1) * (tspr.y - yp1) - (tspr.x - xp1) * (yp2 - yp1);
                            if ((yp > yb1[j]) && (yp > yb2[j])) x = -1;
                            if ((x >= 0) && ((x != 0) || (wall[thewall[j]].nextsector != tspr.sectnum))) continue;

                            dalx2 = Math.Max(xb1[j], lx); darx2 = Math.Min(xb2[j], rx);

                            switch (smostwalltype[i])
                            {
                                case 0:
                                    if (dalx2 <= darx2)
                                    {
                                        if ((dalx2 == lx) && (darx2 == rx)) return;
                                        //clearbufbyte(&dwall[dalx2],(darx2-dalx2+1)*sizeof(dwall[0]),0L);
                                        for (x = dalx2; x <= darx2; x++) dwall[x] = 0;
                                    }
                                    break;
                                case 1:
                                    k = smoststart[i] - xb1[j];
                                    for (x = dalx2; x <= darx2; x++)
                                        if (smost[k + x] > uwall[x]) uwall[x] = smost[k + x];
                                    break;
                                case 2:
                                    k = smoststart[i] - xb1[j];
                                    for (x = dalx2; x <= darx2; x++)
                                        if (smost[k + x] < dwall[x]) dwall[x] = smost[k + x];
                                    break;
                            }
                        }

                        //sprite
                        if ((Engine.searchit >= 1) && (Engine.searchx >= lx) && (Engine.searchx <= rx))
                            if ((Engine.searchy >= uwall[Engine.searchx]) && (Engine.searchy <= dwall[Engine.searchx]))
                            {
                                Engine.searchsector = sectnum; Engine.searchwall = spritenum;
                                Engine.searchstat = 3; Engine.searchit = 1;
                            }

                        globalorientation = cstat;
                        globalpicnum = tilenum;
                        if (globalpicnum >= MAXTILES) globalpicnum = 0;
                        //if (picanm[globalpicnum]&192) globalpicnum += animateoffs((short)globalpicnum,spritenum+32768);

                        if (Engine.waloff[(int)globalpicnum] == null) Engine.loadtile((short)globalpicnum);
                        // Engine.setgotpic(globalpicnum);
                        globalbuf = Engine.waloff[(int)globalpicnum].memory;
                        globalbufplc = 0;

                        globvis = pragmas.mulscale16(globalhisibility, Engine._device.viewingrange);
                        if (sec.visibility != 0) globvis = pragmas.mulscale4(globvis, (int)((byte)(sec.visibility + 16)));

                        x = Engine.picsiz[globalpicnum]; y = (((int)x >> 4) & 15); x &= 15;
                        if (Engine.pow2long[x] != xspan)
                        {
                            x++;
                            globalx1 = pragmas.mulscale(globalx1, xspan, (int)x);
                            globalx2 = pragmas.mulscale(globalx2, xspan, (int)x);
                        }

                        dax = globalxpanning; day = globalypanning;
                        globalxpanning = -pragmas.dmulscale6(globalx1, day, globalx2, dax);
                        globalypanning = -pragmas.dmulscale6(globaly1, day, globaly2, dax);

                        globalx2 = pragmas.mulscale16(globalx2, Engine._device.viewingrange);
                        globaly2 = pragmas.mulscale16(globaly2, Engine._device.viewingrange);
                        globalzd = pragmas.mulscale16(globalzd, Engine._device.viewingrangerecip);

                        globalx1 = (globalx1 - globalx2) * Engine._device.halfxdimen;
                        globaly1 = (globaly1 - globaly2) * Engine._device.halfxdimen;

                        if ((cstat & 2) == 0)
                            A.msethlineshift((int)x, y);
                        else
                            A.tsethlineshift((int)x, y);

                        //Draw it!
                        ceilspritescan(lx, rx - 1);
                    }
                    break;
                case 48:
                    //else if ((cstat&48) == 48)
                    {
                        int nxrepeat, nyrepeat;
                        int tspritez = tspr.z;

                        lx = 0; rx = Engine._device.xdim - 1;
                        for (x = lx; x <= rx; x++)
                        {
                            lwall[x] = (int)Engine._device.startumost[x + Engine._device.windowx1] - Engine._device.windowy1;
                            swall[x] = (int)Engine._device.startdmost[x + Engine._device.windowx1] - Engine._device.windowy1;
                        }
                        for (i = smostwallcnt - 1; i >= 0; i--)
                        {
                            j = smostwall[i];
                            if ((xb1[j] > rx) || (xb2[j] < lx)) continue;
                            if ((yp <= yb1[j]) && (yp <= yb2[j])) continue;
                            if (spritewallfront(tspr, (int)thewall[j]) && ((yp <= yb1[j]) || (yp <= yb2[j]))) continue;

                            dalx2 = Math.Max(xb1[j], lx); darx2 = Math.Min(xb2[j], rx);

                            switch (smostwalltype[i])
                            {
                                case 0:
                                    if (dalx2 <= darx2)
                                    {
                                        if ((dalx2 == lx) && (darx2 == rx)) return;
                                        //clearbufbyte(&swall[dalx2],(darx2-dalx2+1)*sizeof(swall[0]),0L);
                                        for (x = dalx2; x <= darx2; x++) swall[x] = 0;
                                    }
                                    break;
                                case 1:
                                    k = smoststart[i] - xb1[j];
                                    for (x = dalx2; x <= darx2; x++)
                                        if (smost[k + x] > lwall[x]) lwall[x] = smost[k + x];
                                    break;
                                case 2:
                                    k = smoststart[i] - xb1[j];
                                    for (x = dalx2; x <= darx2; x++)
                                        if (smost[k + x] < swall[x]) swall[x] = smost[k + x];
                                    break;
                            }
                        }

                        if (lwall[rx] >= swall[rx])
                        {
                            for (x = lx; x < rx; x++)
                                if (lwall[x] < swall[x]) break;
                            if (x == rx) return;
                        }

                        Engine.bVoxelMipmap intptr = Engine.voxoff[vtilenum][0];
                        intptr._reader.BaseStream.Position = 0;
                        if (Engine.voxscale[vtilenum] == 65536)
                        {
                            nxrepeat = (((int)tspr.xrepeat) << 16);
                            nyrepeat = (((int)tspr.yrepeat) << 16);
                        }
                        else
                        {
                            nxrepeat = ((int)tspr.xrepeat) * Engine.voxscale[vtilenum];
                            nyrepeat = ((int)tspr.yrepeat) * Engine.voxscale[vtilenum];
                        }

                        if ((cstat & 128) == 0) tspritez -= pragmas.mulscale22(B_LITTLE32(intptr.GetInt(5)), nyrepeat);
                        yoff = (int)((sbyte)((Engine.picanm[sprite[tspr.owner].picnum] >> 16) & 255)) + ((int)tspr.yoffset);
                        tspritez -= pragmas.mulscale14(yoff, nyrepeat);

                        globvis = globalvisibility;
                        if (sec.visibility != 0) globvis = pragmas.mulscale4(globvis, (int)((sbyte)(sec.visibility + 16)));

                        if ((Engine.searchit >= 1) && (yp > (4 << 8)) && (Engine.searchy >= lwall[Engine.searchx]) && (Engine.searchy < swall[Engine.searchx]))
                        {
                            siz = pragmas.divscale19(Engine._device.xdimenscale, yp);

                            xv = pragmas.mulscale16(nxrepeat, Engine._device.xyaspect);

                            xspan = ((B_LITTLE32(intptr.GetInt(0)) + B_LITTLE32(intptr.GetInt(1))) >> 1);
                            yspan = B_LITTLE32(intptr.GetInt(2));
                            xsiz = pragmas.mulscale30(siz, xv * xspan);
                            ysiz = pragmas.mulscale30(siz, nyrepeat * yspan);

                            //Watch out for divscale overflow
                            if (((xspan >> 11) < xsiz) && (yspan < (ysiz >> 1)))
                            {
                                x1 = xb - (xsiz >> 1);
                                if ((xspan & 1) != 0) x1 += pragmas.mulscale31(siz, xv);  //Odd xspans
                                i = pragmas.mulscale30(siz, xv * xoff);
                                if ((cstat & 4) == 0) x1 -= i; else x1 += i;

                                y1 = pragmas.mulscale16(tspritez - globalposz, siz);
                                //y1 -= mulscale30(siz,nyrepeat*yoff);
                                y1 += (globalhoriz << 8) - ysiz;
                                //if (cstat&128)  //Already fixed up above
                                y1 += (ysiz >> 1);

                                x2 = x1 + xsiz - 1;
                                y2 = y1 + ysiz - 1;
                                if (((y1 | 255) < (y2 | 255)) && (Engine.searchx >= (x1 >> 8) + 1) && (Engine.searchx <= (x2 >> 8)))
                                {
                                    if ((sec.ceilingstat & 3) == 0)
                                        startum = globalhoriz + pragmas.mulscale24(siz, sec.ceilingz - globalposz) - 1;
                                    else
                                        startum = 0;
                                    if ((sec.floorstat & 3) == 0)
                                        startdm = globalhoriz + pragmas.mulscale24(siz, sec.floorz - globalposz) + 1;
                                    else
                                    {
                                        // jv
                                        startdm = 2147483647; // startdm = 0x7fffffff;
                                    }
                                    // jv end
                                    //sprite
                                    if ((Engine.searchy >= Math.Max(startum, (y1 >> 8))) && (Engine.searchy < Math.Min(startdm, (y2 >> 8))))
                                    {
                                        Engine.searchsector = sectnum; Engine.searchwall = spritenum;
                                        Engine.searchstat = 3; Engine.searchit = 1;
                                    }
                                }
                            }
                        }


                        i = (int)tspr.ang + 1536;
// jmarshall - hack vox scale
                        drawvox(tspr.x, tspr.y, tspritez, i, (int)(tspr.xrepeat * 1.3f), (int)(tspr.yrepeat * 1.15f), vtilenum, tspr.shade, tspr.pal, ref lwall, ref swall);
// jmarshall end
                    }
                    break;
            }
            //  if (automapping == 1) show2dsprite[spritenum>>3] |= pow2char[spritenum&7];

        }

        //
        // ceilspritehline (internal)
        //
        private void ceilspritehline(int x2, int y)
        {
            int x1, v, bx, by;

            //x = x1 + (x2-x1)t + (y1-y2)u  �  x = 160v
            //y = y1 + (y2-y1)t + (x2-x1)u  �  y = (scrx-160)v
            //z = z1 = z2                   �  z = posz + (scry-horiz)v

            x1 = lastx[y]; if (x2 < x1) return;

            v = pragmas.mulscale20(globalzd, Engine.lookups[Engine.horizlookup + (y - globalhoriz + Engine.horizycent)]);
            bx = pragmas.mulscale14(globalx2 * x1 + globalx1, v) + globalxpanning;
            by = pragmas.mulscale14(globaly2 * x1 + globaly1, v) + globalypanning;
            A.asm1 = pragmas.mulscale14(globalx2, v);
            A.asm2 = pragmas.mulscale14(globaly2, v);

            A.asm3 = Engine.palette.palookup[globalpal] + (Engine.palette.getpalookup((int)pragmas.mulscale28(pragmas.klabs(v), globvis), globalshade) << 8);

            if ((globalorientation & 2) == 0)
                A.mhline(globalbuf, globalbufplc, (uint)bx, (x2 - x1) << 16, 0, (uint)by, frameoffset + (Engine.ylookup[y] + x1));
            else
            {
                A.thline(globalbuf, globalbufplc, (uint)bx, (x2 - x1) << 16, 0, (uint)by, frameoffset + (Engine.ylookup[y] + x1));
            }
        }


        //
        // ceilspritescan (internal)
        //
        private void ceilspritescan(int x1, int x2)
        {
            int x, y1, y2, twall, bwall;

            y1 = uwall[x1]; y2 = y1;
            for (x = x1; x <= x2; x++)
            {
                twall = uwall[x] - 1; bwall = dwall[x];
                if (twall < bwall - 1)
                {
                    if (twall >= y2)
                    {
                        while (y1 < y2 - 1) ceilspritehline(x - 1, ++y1);
                        y1 = twall;
                    }
                    else
                    {
                        while (y1 < twall) ceilspritehline(x - 1, ++y1);
                        while (y1 > twall) lastx[y1--] = x;
                    }
                    while (y2 > bwall) ceilspritehline(x - 1, --y2);
                    while (y2 < bwall) lastx[y2++] = x;
                }
                else
                {
                    while (y1 < y2 - 1) ceilspritehline(x - 1, ++y1);
                    if (x == x2) break;
                    y1 = uwall[x + 1]; y2 = y1;
                }
            }
            while (y1 < y2 - 1) ceilspritehline(x2, ++y1);
            //  faketimerhandler();
        }


        private const int BITSOFPRECISION = 3;  //Don't forget to change this in A.ASM also!
        private void grouscan(int dax1, int dax2, int sectnum, char dastat)
        {
            int i, j, k, l, m, n, x, y, dx, dy, wx, wy, x1, y1, x2, y2, daz;
            int daslope, dasqr;
            int dashade, m1, m2, shinc;
            int shoffs;
            int mptr1, mptr2, nptr1, nptr2;
            walltype wal;
            sectortype sec;

            sec = sector[sectnum];

            if (dastat == 0)
            {
                if (globalposz <= getceilzofslope((short)sectnum, globalposx, globalposy))
                    return;  //Back-face culling
                globalorientation = sec.ceilingstat;
                globalpicnum = sec.ceilingpicnum;
                globalshade = sec.ceilingshade;
                globalpal = sec.ceilingpal;
                daslope = sec.ceilingheinum;
                daz = sec.ceilingz;
            }
            else
            {
                if (globalposz >= getflorzofslope((short)sectnum, globalposx, globalposy))
                    return;  //Back-face culling
                globalorientation = sec.floorstat;
                globalpicnum = sec.floorpicnum;
                globalshade = sec.floorshade;
                globalpal = sec.floorpal;
                daslope = sec.floorheinum;
                daz = sec.floorz;
            }

            if ((Engine.picanm[globalpicnum] & 192) != 0) globalpicnum += Engine.animateoffs((short)globalpicnum, (short)sectnum);
            Engine.setgotpic(globalpicnum);
            if ((Engine.tilesizx[globalpicnum] <= 0) || (Engine.tilesizy[globalpicnum] <= 0)) return;

            if (Engine.waloff[(int)globalpicnum] == null) Engine.loadtile((short)globalpicnum);

            wal = wall[sec.wallptr];
            wx = wall[wal.point2].x - wal.x;
            wy = wall[wal.point2].y - wal.y;
            dasqr = (int)pragmas.krecipasm((int)pragmas.nsqrtasm((uint)(wx * wx + wy * wy)));
            i = pragmas.mulscale21(daslope, dasqr);
            wx *= i; wy *= i;

            globalx = -pragmas.mulscale19(singlobalang, Engine._device.xdimenrecip);
            globaly = pragmas.mulscale19(cosglobalang, Engine._device.xdimenrecip);
            globalx1 = (globalposx << 8);
            globaly1 = -(globalposy << 8);
            i = (dax1 - Engine._device.halfxdimen) * Engine._device.xdimenrecip;
            globalx2 = pragmas.mulscale16(cosglobalang << 4, Engine._device.viewingrangerecip) - pragmas.mulscale27(singlobalang, i);
            globaly2 = pragmas.mulscale16(singlobalang << 4, Engine._device.viewingrangerecip) + pragmas.mulscale27(cosglobalang, i);
            globalzd = (Engine._device.xdimscale << 9);
            globalzx = -pragmas.dmulscale17(wx, globaly2, -wy, globalx2) + pragmas.mulscale10(1 - globalhoriz, globalzd);
            globalz = -pragmas.dmulscale25(wx, globaly, -wy, globalx);

            if ((globalorientation & 64) != 0)  //Relative alignment
            {
                dx = pragmas.mulscale14(wall[wal.point2].x - wal.x, dasqr);
                dy = pragmas.mulscale14(wall[wal.point2].y - wal.y, dasqr);

                i = (int)pragmas.nsqrtasm((uint)(daslope * daslope + 16777216));

                x = globalx; y = globaly;
                globalx = pragmas.dmulscale16(x, dx, y, dy);
                globaly = pragmas.mulscale12(pragmas.dmulscale16(-y, dx, x, dy), i);

                x = ((wal.x - globalposx) << 8); y = ((wal.y - globalposy) << 8);
                globalx1 = pragmas.dmulscale16(-x, dx, -y, dy);
                globaly1 = pragmas.mulscale12(pragmas.dmulscale16(-y, dx, x, dy), i);

                x = globalx2; y = globaly2;
                globalx2 = pragmas.dmulscale16(x, dx, y, dy);
                globaly2 = pragmas.mulscale12(pragmas.dmulscale16(-y, dx, x, dy), i);
            }
            if ((globalorientation & 0x4) != 0)
            {
                i = globalx; globalx = -globaly; globaly = -i;
                i = globalx1; globalx1 = globaly1; globaly1 = i;
                i = globalx2; globalx2 = -globaly2; globaly2 = -i;
            }
            if ((globalorientation & 0x10) != 0) { globalx1 = -globalx1; globalx2 = -globalx2; globalx = -globalx; }
            if ((globalorientation & 0x20) != 0) { globaly1 = -globaly1; globaly2 = -globaly2; globaly = -globaly; }

            daz = pragmas.dmulscale9(wx, globalposy - wal.y, -wy, globalposx - wal.x) + ((daz - globalposz) << 8);
            globalx2 = pragmas.mulscale20(globalx2, daz); globalx = pragmas.mulscale28(globalx, daz);
            globaly2 = pragmas.mulscale20(globaly2, -daz); globaly = pragmas.mulscale28(globaly, -daz);

            i = 8 - (Engine.picsiz[globalpicnum] & 15); j = 8 - (Engine.picsiz[globalpicnum] >> 4);
            if ((globalorientation & 8) != 0) { i++; j++; }
            globalx1 <<= (int)(i + 12); globalx2 <<= (int)i; globalx <<= (int)i;
            globaly1 <<= (int)(j + 12); globaly2 <<= (int)j; globaly <<= (int)j;

            if (dastat == 0)
            {
                globalx1 += (((int)sec.ceilingxpanning) << 24);
                globaly1 += (((int)sec.ceilingypanning) << 24);
                // jv - this should be wrong.
                //     globalx1 = -globalx1;
                //    globaly1 = -globaly1;
                // jv end
            }
            else
            {
                globalx1 += (((int)sec.floorxpanning) << 24);
                globaly1 += (((int)sec.floorypanning) << 24);
            }

            A.asm1 = -(globalzd >> (16 - BITSOFPRECISION));

            globvis = globalvisibility;
            if (sec.visibility != 0) globvis = pragmas.mulscale4(globvis, (int)((byte)(sec.visibility + 16)));
            globvis = pragmas.mulscale13(globvis, daz);
            globvis = pragmas.mulscale16(globvis, Engine._device.xdimscale);
            // j = globalpal; // Engine.palette.palookup[globalpal].arraynum;

            A.setupslopevlin(((int)(Engine.picsiz[globalpicnum] & 15)) + (((int)(Engine.picsiz[globalpicnum] >> 4)) << 8), Engine.waloff[(int)globalpicnum].memory, 0, -Engine.ylookup[1]);

            l = (globalzd >> 16);

            shinc = pragmas.mulscale16(globalz, Engine._device.xdimenscale);
            if (shinc > 0) shoffs = (4 << 15); else shoffs = ((16380 - Engine._device.ydimen) << 15);   // JBF: was 2044
            if (dastat == 0) y1 = umost[dax1]; else y1 = Math.Max(umost[dax1], dplc[dax1]);
            m1 = pragmas.mulscale16(y1, globalzd) + (globalzx >> 6);
            //Avoid visibility overflow by crossing horizon
            if (globalzd > 0) m1 += (globalzd >> 16); else m1 -= (globalzd >> 16);
            m2 = m1 + l;
            mptr1 = y1 + (shoffs >> 15); mptr2 = mptr1 + 1;

            // slopalookup

            int[] slopalookupbuf = slopalookup;
            for (x = dax1; x <= dax2; x++)
            {
                if (dastat == 0) { y1 = umost[x]; y2 = Math.Min(dmost[x], uplc[x]) - 1; }
                else { y1 = Math.Max(umost[x], dplc[x]); y2 = dmost[x] - 1; }
                if (y1 <= y2)
                {
                    nptr1 = y1 + (shoffs >> 15);
                    nptr2 = y2 + (shoffs >> 15);

                    while (nptr1 <= mptr1)
                    {
                        slopalookupbuf[mptr1--] = (Engine.palette.getpalookup((int)pragmas.mulscale24(pragmas.krecipasm(m1), globvis), globalshade) << 8);
                        m1 -= l;
                    }
                    while (nptr2 >= mptr2)
                    {
                        slopalookupbuf[mptr2++] = (Engine.palette.getpalookup((int)pragmas.mulscale24(pragmas.krecipasm(m2), globvis), globalshade) << 8);
                        m2 += l;
                    }

                    A.globalx3 = (globalx2 >> 10);
                    A.globaly3 = (globaly2 >> 10);
                    A.asm5 = (int)(pragmas.mulscale16(y2, globalzd) + (globalzx >> 6));


                    A.slopevlin(frameoffset + Engine.ylookup[y2] + x, pragmas.krecipasm(((int)A.asm5) >> 3), slopalookupbuf, nptr2, y2 - y1 + 1, globalx1, globaly1);

                    // if ((x&15) == 0) faketimerhandler();
                }
                globalx2 += globalx;
                globaly2 += globaly;
                globalzx += globalz;
                shoffs += shinc;
            }
        }

        private int[] y1ve = new int[4];
        private int[] y2ve = new int[4];

        private void wallscan(int x1, int x2, ref short[] uwal, ref short[] dwal, ref int[] swal, ref int[] lwal)
        {
            bool xnice, ynice;
            int i, x, shade;
            int u4, d4, dax, z, tsizx, tsizy;
            int fpalookup;
            byte bad;

            tsizx = Engine.tilesizx[globalpicnum];
            tsizy = Engine.tilesizy[globalpicnum];
            Engine.setgotpic(globalpicnum);
            if ((tsizx <= 0) || (tsizy <= 0))
                return;
            if ((uwal[x1] > Engine._device.ydimen) && (uwal[x2] > Engine._device.ydimen)) return;
            if ((dwal[x1] < 0) && (dwal[x2] < 0)) return;

            if (Engine.waloff[(int)globalpicnum] == null) Engine.loadtile((short)globalpicnum);

            xnice = (Engine.pow2long[Engine.picsiz[globalpicnum] & 15] == tsizx);
            if (xnice) tsizx--;
            ynice = (Engine.pow2long[Engine.picsiz[globalpicnum] >> 4] == tsizy);
            if (ynice) tsizy = (Engine.picsiz[globalpicnum] >> 4);

            //fpalookup = globalpal; // Engine.palette.palookup[globalpal];

            A.setupvlineasm(globalshiftval);

            for (x = x1; x <= x2; x++)
            {
                y1ve[0] = Math.Max(uwal[x], umost[x]);
                y2ve[0] = Math.Min(dwal[x], dmost[x]);
                if (y2ve[0] <= y1ve[0]) continue;

                palookupoffse = (Engine.palette.getpalookup((int)pragmas.mulscale16(swal[x], globvis), globalshade) << 8);

                bufplce[0] = lwal[x] + globalxpanning;

                if (bufplce[0] >= tsizx) { if (xnice == false) bufplce[0] %= tsizx; else bufplce[0] &= tsizx; }
                if (ynice == false) bufplce[0] *= tsizy; else bufplce[0] <<= (int)tsizy;

                vince[0] = swal[x] * globalyscale;
                vplce[0] = globalzd + vince[0] * (y1ve[0] - globalhoriz + 1);
                // jv
                A.vlineasm1(vince[0], palookupoffse, y2ve[0] - y1ve[0] - 1, (uint)vplce[0], Engine.waloff[(int)globalpicnum].memory, bufplce[0], frameoffset + Engine.ylookup[y1ve[0]] + x);
                // jv end
            }
            //faketimerhandler();
        }

        //
        // hline (internal)
        //
        private void hline(int xr, int yp)
        {
            int xl, r, s;

            xl = lastx[yp]; if (xl > xr) return;
            r = Engine.lookups2[Engine.horizlookup2 + (yp - globalhoriz + Engine.horizycent)];
            A.asm1 = globalx1 * r;
            A.asm2 = globaly2 * r;
            s = ((int)Engine.palette.getpalookup((int)pragmas.mulscale16(r, globvis), globalshade) << 8);

            A.hlineasm4(xr - xl, 0, s, (uint)(globalx2 * r + globalypanning), (uint)(globaly1 * r + globalxpanning),
                frameoffset + Engine.ylookup[yp] + xr);
        }

        private void slowhline(int xr, int yp)
        {
            int xl, x, y, ox, oy, r, p, shade;

            xl = lastx[yp]; if (xl > xr) return;
            r = Engine.lookups2[Engine.horizlookup2 + (yp - globalhoriz + Engine.horizycent)];
            A.asm1 = globalx1 * r;
            A.asm2 = globaly2 * r;

            A.asm3 = Engine.palette.globalpalwritten + ((int)Engine.palette.getpalookup((int)pragmas.mulscale16(r, globvis), globalshade) << 8);
            if ((globalorientation & 256) == 0)
            {
                A.mhline(globalbuf, globalbufplc, (uint)(globaly1 * r + globalxpanning - A.asm1 * (xr - xl)), (xr - xl) << 16, 0,
                    (uint)(globalx2 * r + globalypanning - A.asm2 * (xr - xl)), Engine.ylookup[yp] + xl + frameoffset);
                return;
            }
            A.thline(globalbuf, globalbufplc, (uint)(globaly1 * r + globalxpanning - A.asm1 * (xr - xl)), (xr - xl) << 16, 0,
                (uint)(globalx2 * r + globalypanning - A.asm2 * (xr - xl)), Engine.ylookup[yp] + xl + frameoffset);
            //  transarea += (xr-xl); // jv
        }


        private void drawvox(int dasprx, int daspry, int dasprz, int dasprang,
          int daxscale, int dayscale, int daindex,
          sbyte dashade, byte dapal, ref int[] daumost, ref int[] dadmost)
        {
            int i, j, k, x, y, syoff, ggxstart, ggystart, nxoff;
            int cosang, sinang, sprcosang, sprsinang, backx, backy, gxinc, gyinc;
            int daxsiz, daysiz, dazsiz, daxpivot, daypivot, dazpivot;
            int daxscalerecip, dayscalerecip, cnt, gxstart, gystart, odayscale;
            int l1, l2, slabxoffs, xyvoxoffs;
            int lx, rx, nx, ny, x1 = 0, y1 = 0, z1, x2 = 0, y2 = 0, z2, yplc, yinc = 0;
            int yoff, xs = 0, ys = 0, xe, ye, xi = 0, yi = 0, cbackx, cbacky, dagxinc, dagyinc;
            int shortptr;
            int voxptr, voxend, oand, oand16, oand32;
            Engine.bVoxelMipmap davoxptr;

            cosang = Engine.table.sintable[(globalang + 512) & 2047];
            sinang = Engine.table.sintable[globalang & 2047];
            sprcosang = Engine.table.sintable[(dasprang + 512) & 2047];
            sprsinang = Engine.table.sintable[dasprang & 2047];

            i = pragmas.klabs(pragmas.dmulscale6(dasprx - globalposx, cosang, daspry - globalposy, sinang));
            j = (int)(Engine.palette.getpalookup((int)pragmas.mulscale21(globvis, i), (int)dashade) << 8);
            A.setupdrawslab(Engine.ylookup[1], Engine.palette.palookup[dapal], j);
            j = 1310720;
            j *= Math.Min(daxscale, dayscale); j >>= 6;  //New hacks (for sized-down voxels)
            for (k = 0; k < 5; k++)
            {
                if (i < j) { i = k; break; }
                j <<= 1;
            }
            if (k >= 5) i = 5 - 1;

            //  if (novoxmips) i = 0;
            davoxptr = Engine.voxoff[daindex][i];

            if (davoxptr == null && i > 0) { davoxptr = Engine.voxoff[daindex][0]; i = 0; }
            if (davoxptr == null) return;

            if (Engine.voxscale[daindex] == 65536)
            { daxscale <<= (i + 8); dayscale <<= (i + 8); }
            else
            {
                daxscale = pragmas.mulscale8(daxscale << i, Engine.voxscale[daindex]);
                dayscale = pragmas.mulscale8(dayscale << i, Engine.voxscale[daindex]);
            }

            odayscale = dayscale;
            daxscale = pragmas.mulscale16(daxscale, Engine._device.xyaspect);
            daxscale = pragmas.scale(daxscale, Engine._device.xdimenscale, Engine._device.xdimen << 8);
            dayscale = pragmas.scale(dayscale, pragmas.mulscale16(Engine._device.xdimenscale, Engine._device.viewingrangerecip), Engine._device.xdimen << 8);

            daxscalerecip = (1 << 30) / daxscale;
            dayscalerecip = (1 << 30) / dayscale;

            davoxptr._reader.BaseStream.Position = 0;
            daxsiz = davoxptr.GetInt(0); daysiz = davoxptr.GetInt(1); dazsiz = davoxptr.GetInt(2);
            daxpivot = davoxptr.GetInt(3); daypivot = davoxptr.GetInt(4); dazpivot = davoxptr.GetInt(5);
            davoxptr._reader.BaseStream.Position += (6 << 2);

            x = pragmas.mulscale16(globalposx - dasprx, daxscalerecip);
            y = pragmas.mulscale16(globalposy - daspry, daxscalerecip);
            backx = ((pragmas.dmulscale10(x, sprcosang, y, sprsinang) + daxpivot) >> 8);
            backy = ((pragmas.dmulscale10(y, sprcosang, x, -sprsinang) + daypivot) >> 8);
            cbackx = Math.Min(Math.Max(backx, 0), daxsiz - 1);
            cbacky = Math.Min(Math.Max(backy, 0), daysiz - 1);

            sprcosang = pragmas.mulscale14(daxscale, sprcosang);
            sprsinang = pragmas.mulscale14(daxscale, sprsinang);

            x = (dasprx - globalposx) - pragmas.dmulscale18(daxpivot, sprcosang, daypivot, -sprsinang);
            y = (daspry - globalposy) - pragmas.dmulscale18(daypivot, sprcosang, daxpivot, sprsinang);

            cosang = pragmas.mulscale16(cosang, dayscalerecip);
            sinang = pragmas.mulscale16(sinang, dayscalerecip);

            gxstart = y * cosang - x * sinang;
            gystart = x * cosang + y * sinang;
            gxinc = pragmas.dmulscale10(sprsinang, cosang, sprcosang, -sinang);
            gyinc = pragmas.dmulscale10(sprcosang, cosang, sprsinang, sinang);

            x = 0; y = 0; j = Math.Max(daxsiz, daysiz);
            for (i = 0; i <= j; i++)
            {
                Engine.ggxinc[i] = x; x += gxinc;
                Engine.ggyinc[i] = y; y += gyinc;
            }

            if ((pragmas.klabs(globalposz - dasprz) >> 10) >= pragmas.klabs(odayscale)) return;
            syoff = pragmas.divscale21(globalposz - dasprz, odayscale) + (dazpivot << 7);
            yoff = ((pragmas.klabs(gxinc) + pragmas.klabs(gyinc)) >> 1);
            xyvoxoffs = ((daxsiz + 1) << 2);

            Engine._device.BeginDrawing();  //{{{

            for (cnt = 0; cnt < 8; cnt++)
            {
                switch (cnt)
                {
                    case 0: xs = 0; ys = 0; xi = 1; yi = 1; break;
                    case 1: xs = daxsiz - 1; ys = 0; xi = -1; yi = 1; break;
                    case 2: xs = 0; ys = daysiz - 1; xi = 1; yi = -1; break;
                    case 3: xs = daxsiz - 1; ys = daysiz - 1; xi = -1; yi = -1; break;
                    case 4: xs = 0; ys = cbacky; xi = 1; yi = 2; break;
                    case 5: xs = daxsiz - 1; ys = cbacky; xi = -1; yi = 2; break;
                    case 6: xs = cbackx; ys = 0; xi = 2; yi = 1; break;
                    case 7: xs = cbackx; ys = daysiz - 1; xi = 2; yi = -1; break;
                }
                xe = cbackx; ye = cbacky;
                if (cnt < 4)
                {
                    if ((xi < 0) && (xe >= xs)) continue;
                    if ((xi > 0) && (xe <= xs)) continue;
                    if ((yi < 0) && (ye >= ys)) continue;
                    if ((yi > 0) && (ye <= ys)) continue;
                }
                else
                {
                    if ((xi < 0) && (xe > xs)) continue;
                    if ((xi > 0) && (xe < xs)) continue;
                    if ((yi < 0) && (ye > ys)) continue;
                    if ((yi > 0) && (ye < ys)) continue;
                    xe += xi; ye += yi;
                }

                i = pragmas.ksgn(ys - backy) + pragmas.ksgn(xs - backx) * 3 + 4;
                switch (i)
                {
                    case 6: case 7: x1 = 0; y1 = 0; break;
                    case 8: case 5: x1 = gxinc; y1 = gyinc; break;
                    case 0: case 3: x1 = gyinc; y1 = -gxinc; break;
                    case 2: case 1: x1 = gxinc + gyinc; y1 = gyinc - gxinc; break;
                }
                switch (i)
                {
                    case 2: case 5: x2 = 0; y2 = 0; break;
                    case 0: case 1: x2 = gxinc; y2 = gyinc; break;
                    case 8: case 7: x2 = gyinc; y2 = -gxinc; break;
                    case 6: case 3: x2 = gxinc + gyinc; y2 = gyinc - gxinc; break;
                }

                int cmpx = 0, cmpy = 0;

                if (xs < backx) cmpx = 1;
                if (ys < backy) cmpy = 1;

                oand = Engine.pow2char[cmpx + 0] + Engine.pow2char[cmpy + 2];
                oand16 = oand + 16;
                oand32 = oand + 32;

                if (yi > 0) { dagxinc = gxinc; dagyinc = pragmas.mulscale16(gyinc, Engine._device.viewingrangerecip); }
                else { dagxinc = -gxinc; dagyinc = -pragmas.mulscale16(gyinc, Engine._device.viewingrangerecip); }

                //Fix for non 90 degree viewing ranges
                nxoff = pragmas.mulscale16(x2 - x1, Engine._device.viewingrangerecip);
                x1 = pragmas.mulscale16(x1, Engine._device.viewingrangerecip);

                ggxstart = gxstart + Engine.ggyinc[ys];
                ggystart = gystart - Engine.ggxinc[ys];

                int basepos = (6 << 2);
                for (x = xs; x != xe; x += xi)
                {
                    davoxptr._reader.BaseStream.Position = basepos;

                    slabxoffs = basepos + davoxptr.GetInt(x); // (int)&davoxptr[B_LITTLE32(intptr[x])];
                    shortptr = basepos + ((x * (daysiz + 1)) << 1) + xyvoxoffs;//(short *)&davoxptr[((x*(daysiz+1))<<1)+xyvoxoffs];

                    nx = pragmas.mulscale16(ggxstart + Engine.ggxinc[x], Engine._device.viewingrangerecip) + x1;
                    ny = ggystart + Engine.ggyinc[x];
                    for (y = ys; y != ye; y += yi, nx += dagyinc, ny -= dagxinc)
                    {
                        if ((ny <= nytooclose) || (ny >= nytoofar)) continue;
                        davoxptr._reader.BaseStream.Position = shortptr;
                        voxptr = davoxptr.GetShort(y) + slabxoffs;
                        voxend = davoxptr.GetShort(y + 1) + slabxoffs;//(char *)(B_LITTLE16(shortptr[y+1])+slabxoffs);
                        if (voxptr == voxend) continue;

                        lx = pragmas.mulscale32(nx >> 3, (int)distrecip[(ny + y1) >> 14]) + Engine._device.halfxdimen;
                        if (lx < 0) lx = 0;
                        rx = pragmas.mulscale32((nx + nxoff) >> 3, (int)distrecip[(ny + y2) >> 14]) + Engine._device.halfxdimen;
                        if (rx > Engine._device.xdimen) rx = Engine._device.xdimen;
                        if (rx <= lx) continue;
                        rx -= lx;

                        l1 = (int)distrecip[(ny - yoff) >> 14];
                        l2 = (int)distrecip[(ny + yoff) >> 14];
                        davoxptr._reader.BaseStream.Position = voxptr;
                        for (; voxptr < voxend; voxptr += davoxptr.data[voxptr + 1] + 3)
                        {
                            j = (davoxptr.data[voxptr + 0] << 15) - syoff;
                            if (j < 0)
                            {
                                k = j + (davoxptr.data[voxptr + 1] << 15);
                                if (k < 0)
                                {
                                    if ((davoxptr.data[voxptr + 2] & oand32) == 0) continue;
                                    z2 = pragmas.mulscale32(l2, k) + globalhoriz;     //Below slab
                                }
                                else
                                {
                                    if ((davoxptr.data[voxptr + 2] & oand) == 0) continue;    //Middle of slab
                                    z2 = pragmas.mulscale32(l1, k) + globalhoriz;
                                }
                                z1 = pragmas.mulscale32(l1, j) + globalhoriz;
                            }
                            else
                            {
                                if ((davoxptr.data[voxptr + 2] & oand16) == 0) continue;
                                z1 = pragmas.mulscale32(l2, j) + globalhoriz;        //Above slab
                                z2 = pragmas.mulscale32(l1, j + (davoxptr.data[voxptr + 1] << 15)) + globalhoriz;
                            }

                            if (davoxptr.data[voxptr + 1] == 1)
                            {
                                yplc = 0; yinc = 0;
                                if (z1 < daumost[lx]) z1 = daumost[lx];
                            }
                            else
                            {
                                if (z2 - z1 >= 1024) yinc = pragmas.divscale16(davoxptr.data[voxptr + 1], z2 - z1);
                                else if (z2 > z1) yinc = (Engine.lowrecip[z2 - z1] * davoxptr.data[voxptr + 1] >> 8);
                                if (z1 < daumost[lx]) { yplc = yinc * (daumost[lx] - z1); z1 = daumost[lx]; } else yplc = 0;
                            }
                            if (z2 > dadmost[lx]) z2 = dadmost[lx];
                            z2 -= z1; if (z2 <= 0) continue;

                            A.drawslab(rx, yplc, z2, yinc, davoxptr.data, (voxptr + 3), Engine.ylookup[z1] + lx + frameoffset);
                        }
                    }
                }
            }

            Engine._device.EndDrawing();	//}}}
        }

        //
        // florscan (internal)
        //
        private void florscan(int x1, int x2, int sectnum)
        {
            int i, j, ox, oy, x, y1, y2, twall, bwall;
            sectortype sec;

            sec = sector[sectnum];
            if (sec.floorpal != Engine.palette.globalpalwritten)
            {
                Engine.palette.globalpalwritten = sec.floorpal;
                // jv
                //if (Engine.palette.isLookupValid(Engine.palette.globalpalwritten) == false) Engine.palette.globalpalwritten = globalpal;	// JBF: fixes null-pointer crash
                // jv end
                A.setpalookupaddress(Engine.palette.globalpalwritten, 0);
            }

            globalzd = globalposz - sec.floorz;
            if (globalzd > 0) return;
            globalpicnum = sec.floorpicnum;
            if (globalpicnum >= MAXTILES) globalpicnum = 0;
            Engine.setgotpic(globalpicnum);
            if ((Engine.tilesizx[globalpicnum] <= 0) || (Engine.tilesizy[globalpicnum] <= 0)) return;
            if ((Engine.picanm[globalpicnum] & 192) != 0) globalpicnum += Engine.animateoffs((short)globalpicnum, (short)sectnum);

            if (Engine.waloff[(int)globalpicnum] == null) Engine.loadtile((short)globalpicnum);
            globalbuf = Engine.waloff[(int)globalpicnum].memory;
            globalbufplc = 0;
            globalshade = (int)sec.floorshade;
            globvis = globalcisibility;
            if (sec.visibility != 0) globvis = pragmas.mulscale4(globvis, (int)((byte)(sec.visibility + 16)));
            globalorientation = (int)sec.floorstat;


            if ((globalorientation & 64) == 0)
            {
                globalx1 = singlobalang; globalx2 = singlobalang;
                globaly1 = cosglobalang; globaly2 = cosglobalang;
                globalxpanning = (globalposx << 20);
                globalypanning = -(globalposy << 20);
            }
            else
            {
                j = sec.wallptr;
                ox = wall[wall[j].point2].x - wall[j].x;
                oy = wall[wall[j].point2].y - wall[j].y;
                i = (int)pragmas.nsqrtasm((uint)(ox * ox + oy * oy)); if (i == 0) i = 1024; else i = 1048576 / i;
                globalx1 = pragmas.mulscale10(pragmas.dmulscale10(ox, singlobalang, -oy, cosglobalang), i);
                globaly1 = pragmas.mulscale10(pragmas.dmulscale10(ox, cosglobalang, oy, singlobalang), i);
                globalx2 = -globalx1;
                globaly2 = -globaly1;

                ox = ((wall[j].x - globalposx) << 6); oy = ((wall[j].y - globalposy) << 6);
                i = pragmas.dmulscale14(oy, cosglobalang, -ox, singlobalang);
                j = pragmas.dmulscale14(ox, cosglobalang, oy, singlobalang);
                ox = i; oy = j;
                globalxpanning = globalx1 * ox - globaly1 * oy;
                globalypanning = globaly2 * ox + globalx2 * oy;
            }
            globalx2 = pragmas.mulscale16(globalx2, Engine._device.viewingrangerecip);
            globaly1 = pragmas.mulscale16(globaly1, Engine._device.viewingrangerecip);
            globalxshift = (8 - (Engine.picsiz[globalpicnum] & 15));
            globalyshift = (8 - (Engine.picsiz[globalpicnum] >> 4));
            if ((globalorientation & 8) != 0) { globalxshift++; globalyshift++; }

            if ((globalorientation & 0x4) > 0)
            {
                i = globalxpanning; globalxpanning = globalypanning; globalypanning = i;
                i = globalx2; globalx2 = -globaly1; globaly1 = -i;
                i = globalx1; globalx1 = globaly2; globaly2 = i;
            }
            if ((globalorientation & 0x10) > 0) { globalx1 = -globalx1; globaly1 = -globaly1; globalxpanning = -globalxpanning; }
            if ((globalorientation & 0x20) > 0) { globalx2 = -globalx2; globaly2 = -globaly2; globalypanning = -globalypanning; }
            globalx1 <<= (int)globalxshift; globaly1 <<= (int)globalxshift;
            globalx2 <<= (int)globalyshift; globaly2 <<= (int)globalyshift;
            globalxpanning <<= (int)globalxshift; globalypanning <<= (int)globalyshift;
            globalxpanning += (((int)sec.floorxpanning) << 24);
            globalypanning += (((int)sec.floorypanning) << 24);
            globaly1 = (-globalx1 - globaly1) * Engine._device.halfxdimen;
            globalx2 = (globalx2 - globaly2) * Engine._device.halfxdimen;

            A.sethlinesizes(Engine.picsiz[globalpicnum] & 15, Engine.picsiz[globalpicnum] >> 4, globalbuf, globalbufplc);

            globalx2 += globaly2 * (x1 - 1);
            globaly1 += globalx1 * (x1 - 1);
            globalx1 = pragmas.mulscale16(globalx1, globalzd);
            globalx2 = pragmas.mulscale16(globalx2, globalzd);
            globaly1 = pragmas.mulscale16(globaly1, globalzd);
            globaly2 = pragmas.mulscale16(globaly2, globalzd);
            globvis = pragmas.klabs(pragmas.mulscale10(globvis, globalzd));

            if ((globalorientation & 0x180) == 0)
            {
                y1 = Math.Max(dplc[x1], umost[x1]); y2 = y1;
                for (x = x1; x <= x2; x++)
                {
                    twall = Math.Max(dplc[x], umost[x]) - 1; bwall = dmost[x];
                    if (twall < bwall - 1)
                    {
                        if (twall >= y2)
                        {
                            while (y1 < y2 - 1) hline(x - 1, ++y1);
                            y1 = twall;
                        }
                        else
                        {
                            while (y1 < twall) hline(x - 1, ++y1);
                            while (y1 > twall) lastx[y1--] = x;
                        }
                        while (y2 > bwall) hline(x - 1, --y2);
                        while (y2 < bwall) lastx[y2++] = x;
                    }
                    else
                    {
                        while (y1 < y2 - 1) hline(x - 1, ++y1);
                        if (x == x2) { globalx2 += globaly2; globaly1 += globalx1; break; }
                        y1 = Math.Max(dplc[x + 1], umost[x + 1]); y2 = y1;
                    }
                    globalx2 += globaly2; globaly1 += globalx1;
                }
                while (y1 < y2 - 1) hline(x2, ++y1);
                //faketimerhandler();
                return;
            }

            switch (globalorientation & 0x180)
            {
                case 128:
                    A.msethlineshift(Engine.picsiz[globalpicnum] & 15, Engine.picsiz[globalpicnum] >> 4);
                    break;
                case 256:
                    A.settransnormal();
                    A.tsethlineshift(Engine.picsiz[globalpicnum] & 15, Engine.picsiz[globalpicnum] >> 4);
                    break;
                case 384:
                    A.settransreverse();
                    A.tsethlineshift(Engine.picsiz[globalpicnum] & 15, Engine.picsiz[globalpicnum] >> 4);
                    break;
            }

            y1 = Math.Max(dplc[x1], umost[x1]); y2 = y1;
            for (x = x1; x <= x2; x++)
            {
                twall = Math.Max(dplc[x], umost[x]) - 1; bwall = dmost[x];
                if (twall < bwall - 1)
                {
                    if (twall >= y2)
                    {
                        while (y1 < y2 - 1) slowhline(x - 1, ++y1);
                        y1 = twall;
                    }
                    else
                    {
                        while (y1 < twall) slowhline(x - 1, ++y1);
                        while (y1 > twall) lastx[y1--] = x;
                    }
                    while (y2 > bwall) slowhline(x - 1, --y2);
                    while (y2 < bwall) lastx[y2++] = x;
                }
                else
                {
                    while (y1 < y2 - 1) slowhline(x - 1, ++y1);
                    if (x == x2) { globalx2 += globaly2; globaly1 += globalx1; break; }
                    y1 = Math.Max(dplc[x + 1], umost[x + 1]); y2 = y1;
                }
                globalx2 += globaly2; globaly1 += globalx1;
            }
            while (y1 < y2 - 1) slowhline(x2, ++y1);
            //  faketimerhandler();
        }

        //
        // ceilscan (internal)
        //
        private void ceilscan(int x1, int x2, int sectnum)
        {
            int i, j, ox, oy, x, y1, y2, twall, bwall;
            sectortype sec;

            sec = sector[sectnum];
            if (sec.ceilingpal != Engine.palette.globalpalwritten)
            {
                Engine.palette.globalpalwritten = sec.ceilingpal;
                // jv
                //if (Engine.palette.isLookupValid(Engine.palette.globalpalwritten) == false) Engine.palette.globalpalwritten = globalpal;	// JBF: fixes null-pointer crash
                // jv end
                A.setpalookupaddress(Engine.palette.globalpalwritten, 0);
            }

            globalzd = sec.ceilingz - globalposz;
            if (globalzd > 0) return;
            globalpicnum = sec.ceilingpicnum;
            if (globalpicnum >= MAXTILES) globalpicnum = 0;
            Engine.setgotpic(globalpicnum);
            if ((Engine.tilesizx[globalpicnum] <= 0) || (Engine.tilesizy[globalpicnum] <= 0)) return;
            if ((Engine.picanm[globalpicnum] & 192) != 0) globalpicnum += Engine.animateoffs((short)globalpicnum, (short)sectnum);

            if (Engine.waloff[(int)globalpicnum] == null) Engine.loadtile((short)globalpicnum);
            globalbuf = Engine.waloff[(int)globalpicnum].memory;
            globalbufplc = 0;
            globalshade = (int)sec.ceilingshade;
            globvis = globalcisibility;
            if (sec.visibility != 0) globvis = pragmas.mulscale4(globvis, (int)((byte)(sec.visibility + 16)));
            globalorientation = (int)sec.ceilingstat;


            if ((globalorientation & 64) == 0)
            {
                globalx1 = singlobalang; globalx2 = singlobalang;
                globaly1 = cosglobalang; globaly2 = cosglobalang;
                globalxpanning = (globalposx << 20);
                globalypanning = -(globalposy << 20);
            }
            else
            {
                j = sec.wallptr;
                ox = wall[wall[j].point2].x - wall[j].x;
                oy = wall[wall[j].point2].y - wall[j].y;
                i = (int)pragmas.nsqrtasm((uint)(ox * ox + oy * oy)); if (i == 0) i = 1024; else i = 1048576 / i;
                globalx1 = pragmas.mulscale10(pragmas.dmulscale10(ox, singlobalang, -oy, cosglobalang), i);
                globaly1 = pragmas.mulscale10(pragmas.dmulscale10(ox, cosglobalang, oy, singlobalang), i);
                globalx2 = -globalx1;
                globaly2 = -globaly1;

                ox = ((wall[j].x - globalposx) << 6); oy = ((wall[j].y - globalposy) << 6);
                i = pragmas.dmulscale14(oy, cosglobalang, -ox, singlobalang);
                j = pragmas.dmulscale14(ox, cosglobalang, oy, singlobalang);
                ox = i; oy = j;
                globalxpanning = globalx1 * ox - globaly1 * oy;
                globalypanning = globaly2 * ox + globalx2 * oy;
            }
            globalx2 = pragmas.mulscale16(globalx2, Engine._device.viewingrangerecip);
            globaly1 = pragmas.mulscale16(globaly1, Engine._device.viewingrangerecip);
            globalxshift = (8 - (Engine.picsiz[globalpicnum] & 15));
            globalyshift = (8 - (Engine.picsiz[globalpicnum] >> 4));
            if ((globalorientation & 8) != 0) { globalxshift++; globalyshift++; }

            if ((globalorientation & 0x4) > 0)
            {
                i = globalxpanning; globalxpanning = globalypanning; globalypanning = i;
                i = globalx2; globalx2 = -globaly1; globaly1 = -i;
                i = globalx1; globalx1 = globaly2; globaly2 = i;
            }
            if ((globalorientation & 0x10) > 0) { globalx1 = -globalx1; globaly1 = -globaly1; globalxpanning = -globalxpanning; }
            if ((globalorientation & 0x20) > 0) { globalx2 = -globalx2; globaly2 = -globaly2; globalypanning = -globalypanning; }
            globalx1 <<= (int)globalxshift; globaly1 <<= (int)globalxshift;
            globalx2 <<= (int)globalyshift; globaly2 <<= (int)globalyshift;
            globalxpanning <<= (int)globalxshift; globalypanning <<= (int)globalyshift;
            globalxpanning += (((int)sec.ceilingxpanning) << 24);
            globalypanning += (((int)sec.ceilingypanning) << 24);
            globaly1 = (-globalx1 - globaly1) * Engine._device.halfxdimen;
            globalx2 = (globalx2 - globaly2) * Engine._device.halfxdimen;

            A.sethlinesizes(Engine.picsiz[globalpicnum] & 15, Engine.picsiz[globalpicnum] >> 4, globalbuf, globalbufplc);

            globalx2 += globaly2 * (x1 - 1);
            globaly1 += globalx1 * (x1 - 1);
            globalx1 = pragmas.mulscale16(globalx1, globalzd);
            globalx2 = pragmas.mulscale16(globalx2, globalzd);
            globaly1 = pragmas.mulscale16(globaly1, globalzd);
            globaly2 = pragmas.mulscale16(globaly2, globalzd);
            globvis = pragmas.klabs(pragmas.mulscale10(globvis, globalzd));

            if ((globalorientation & 0x180) == 0)
            {
                y1 = umost[x1]; y2 = y1;
                for (x = x1; x <= x2; x++)
                {
                    twall = umost[x] - 1; bwall = Math.Min(uplc[x], dmost[x]);
                    if (twall < bwall - 1)
                    {
                        if (twall >= y2)
                        {
                            while (y1 < y2 - 1) hline(x - 1, ++y1);
                            y1 = twall;
                        }
                        else
                        {
                            while (y1 < twall) hline(x - 1, ++y1);
                            while (y1 > twall) lastx[y1--] = x;
                        }
                        while (y2 > bwall) hline(x - 1, --y2);
                        while (y2 < bwall) lastx[y2++] = x;
                    }
                    else
                    {
                        while (y1 < y2 - 1) hline(x - 1, ++y1);
                        if (x == x2) { globalx2 += globaly2; globaly1 += globalx1; break; }
                        y1 = umost[x + 1]; y2 = y1;
                    }
                    globalx2 += globaly2; globaly1 += globalx1;
                }
                while (y1 < y2 - 1) hline(x2, ++y1);
                // faketimerhandler();
                return;
            }

            switch (globalorientation & 0x180)
            {
                case 128:
                    A.msethlineshift(Engine.picsiz[globalpicnum] & 15, Engine.picsiz[globalpicnum] >> 4);
                    break;
                case 256:
                    A.settransnormal();
                    A.tsethlineshift(Engine.picsiz[globalpicnum] & 15, Engine.picsiz[globalpicnum] >> 4);
                    break;
                case 384:
                    A.settransreverse();
                    A.tsethlineshift(Engine.picsiz[globalpicnum] & 15, Engine.picsiz[globalpicnum] >> 4);
                    break;
            }

            y1 = umost[x1]; y2 = y1;
            for (x = x1; x <= x2; x++)
            {
                twall = umost[x] - 1; bwall = Math.Min(uplc[x], dmost[x]);
                if (twall < bwall - 1)
                {
                    if (twall >= y2)
                    {
                        while (y1 < y2 - 1) slowhline(x - 1, ++y1);
                        y1 = twall;
                    }
                    else
                    {
                        while (y1 < twall) slowhline(x - 1, ++y1);
                        while (y1 > twall) lastx[y1--] = x;
                    }
                    while (y2 > bwall) slowhline(x - 1, --y2);
                    while (y2 < bwall) lastx[y2++] = x;
                }
                else
                {
                    while (y1 < y2 - 1) slowhline(x - 1, ++y1);
                    if (x == x2) { globalx2 += globaly2; globaly1 += globalx1; break; }
                    y1 = umost[x + 1]; y2 = y1;
                }
                globalx2 += globaly2; globaly1 += globalx1;
            }
            while (y1 < y2 - 1) slowhline(x2, ++y1);
            // faketimerhandler();
        }

        private void addclipline(int dax1, int day1, int dax2, int day2, int daoval)
        {
            clipit[clipnum].x1 = dax1; clipit[clipnum].y1 = day1;
            clipit[clipnum].x2 = dax2; clipit[clipnum].y2 = day2;
            clipobjectval[clipnum] = (int)daoval;
            clipnum++;
        }

        public int clipmove(ref int x, ref int y, ref int z, ref short sectnum, int xvect, int yvect, int walldist, int ceildist, int flordist, int cliptype)
        {
            walltype wal, wal2;
            spritetype spr;
            sectortype sec, sec2;
            int i, j, templong1, templong2;
            int oxvect, oyvect, goalx, goaly, intx, inty, lx, ly, retval;
            int k, l, clipsectcnt, startwall, endwall, cstat, dasect;
            int x1, y1, x2, y2, cx, cy, rad, xmin, ymin, xmax, ymax, daz, daz2;
            int bsz, dax, day, xoff, yoff, xspan, yspan, cosang, sinang, tilenum;
            int xrepeat, yrepeat, gx, gy, dx, dy, dasprclipmask, dawalclipmask;
            int hitwall, cnt, clipyou;

            if (((xvect | yvect) == 0) || (sectnum < 0)) return (0);
            retval = 0;

            oxvect = xvect;
            oyvect = yvect;

            goalx = (int)(x) + (xvect >> 14);
            goaly = (int)(y) + (yvect >> 14);

            clipnum = 0;

            cx = ((int)((x) + goalx) >> 1);
            cy = ((int)((y) + goaly) >> 1);
            //Extra walldist for sprites on sector lines
            gx = goalx - (int)(x);
            gy = goaly - (int)(y);
            rad = (int)pragmas.nsqrtasm((uint)(gx * gx + gy * gy)) + MAXCLIPDIST + walldist + 8;
            xmin = cx - rad; ymin = cy - rad;
            xmax = cx + rad; ymax = cy + rad;

            dawalclipmask = (cliptype & 65535);        //CLIPMASK0 = 0x00010001
            dasprclipmask = (cliptype >> 16);          //CLIPMASK1 = 0x01000040

            clipsectorlist[0] = sectnum;
            clipsectcnt = 0; clipsectnum = 1;
            do
            {
                dasect = clipsectorlist[clipsectcnt++];
                sec = sector[dasect];
                startwall = sec.wallptr; endwall = startwall + sec.wallnum;
                for (j = startwall; j < endwall; j++)
                {
                    wal = wall[j];
                    wal2 = wall[wal.point2];
                    if ((wal.x < xmin) && (wal2.x < xmin)) continue;
                    if ((wal.x > xmax) && (wal2.x > xmax)) continue;
                    if ((wal.y < ymin) && (wal2.y < ymin)) continue;
                    if ((wal.y > ymax) && (wal2.y > ymax)) continue;

                    x1 = wal.x; y1 = wal.y; x2 = wal2.x; y2 = wal2.y;

                    dx = x2 - x1; dy = y2 - y1;
                    if (dx * ((y) - y1) < ((x) - x1) * dy) continue;  //If wall's not facing you

                    if (dx > 0) dax = dx * (ymin - y1); else dax = dx * (ymax - y1);
                    if (dy > 0) day = dy * (xmax - x1); else day = dy * (xmin - x1);
                    if (dax >= day) continue;

                    clipyou = 0;
                    if ((wal.nextsector < 0) || (wal.cstat & dawalclipmask) != 0) clipyou = 1;
                    else if (Engine.editstatus == false)
                    {
                        daz = 0;
                        if (Engine.rintersect((int)x, (int)y, 0, gx, gy, 0, x1, y1, x2, y2, ref dax, ref day, ref daz) == 0)
                        {
                            dax = (int)x;
                            day = (int)y;
                        }
                        daz = getflorzofslope((short)dasect, dax, day);
                        daz2 = getflorzofslope(wal.nextsector, dax, day);

                        sec2 = sector[wal.nextsector];
                        if (daz2 < daz - (1 << 8))
                            if ((sec2.floorstat & 1) == 0)
                                if ((z) >= daz2 - (flordist - 1)) clipyou = 1;
                        if (clipyou == 0)
                        {
                            daz = getceilzofslope((short)dasect, dax, day);
                            daz2 = getceilzofslope(wal.nextsector, dax, day);
                            if (daz2 > daz + (1 << 8))
                                if ((sec2.ceilingstat & 1) == 0)
                                    if ((z) <= daz2 + (ceildist - 1)) clipyou = 1;
                        }
                    }

                    if (clipyou != 0)
                    {
                        //Add 2 boxes at endpoints
                        bsz = walldist; if (gx < 0) bsz = -bsz;
                        addclipline(x1 - bsz, y1 - bsz, x1 - bsz, y1 + bsz, (short)j + 32768);
                        addclipline(x2 - bsz, y2 - bsz, x2 - bsz, y2 + bsz, (short)j + 32768);
                        bsz = walldist; if (gy < 0) bsz = -bsz;
                        addclipline(x1 + bsz, y1 - bsz, x1 - bsz, y1 - bsz, (short)j + 32768);
                        addclipline(x2 + bsz, y2 - bsz, x2 - bsz, y2 - bsz, (short)j + 32768);

                        dax = walldist; if (dy > 0) dax = -dax;
                        day = walldist; if (dx < 0) day = -day;
                        addclipline(x1 + dax, y1 + day, x2 + dax, y2 + day, (short)j + 32768);
                    }
                    else
                    {
                        for (i = clipsectnum - 1; i >= 0; i--)
                            if (wal.nextsector == clipsectorlist[i]) break;
                        if (i < 0) clipsectorlist[clipsectnum++] = wal.nextsector;
                    }
                }

                for (j = headspritesect[dasect]; j >= 0; j = nextspritesect[j])
                {
                    spr = sprite[j];
                    cstat = spr.cstat;
                    if ((cstat & dasprclipmask) == 0) continue;
                    x1 = spr.x;
                    y1 = spr.y;
                    switch (cstat & 48)
                    {
                        case 0:
                            if ((x1 >= xmin) && (x1 <= xmax) && (y1 >= ymin) && (y1 <= ymax))
                            {
                                k = ((Engine.tilesizy[spr.picnum] * spr.yrepeat) << 2);
                                if ((cstat & 128) != 0) daz = spr.z + (k >> 1);
                                else daz = spr.z;

                                if ((Engine.picanm[spr.picnum] & 0x00ff0000) != 0)
                                    daz -= ((int)((byte)((Engine.picanm[spr.picnum] >> 16) & 255)) * spr.yrepeat << 2);

                                if ((z < daz + ceildist) && (z > daz - k - flordist))
                                {
                                    bsz = (spr.clipdist << 2) + walldist;
                                    if (gx < 0) bsz = -bsz;
                                    addclipline(x1 - bsz, y1 - bsz, x1 - bsz, y1 + bsz, (short)j + 49152);
                                    bsz = (spr.clipdist << 2) + walldist;
                                    if (gy < 0) bsz = -bsz;
                                    addclipline(x1 + bsz, y1 - bsz, x1 - bsz, y1 - bsz, (short)j + 49152);
                                }
                            }
                            break;
                        case 16:
                            k = ((Engine.tilesizy[spr.picnum] * spr.yrepeat) << 2);

                            if ((cstat & 128) != 0)
                                daz = spr.z + (k >> 1);
                            else
                                daz = spr.z;

                            if ((Engine.picanm[spr.picnum] & 0x00ff0000) != 0)
                                daz -= ((int)((byte)((Engine.picanm[spr.picnum] >> 16) & 255)) * spr.yrepeat << 2);
                            daz2 = daz - k;
                            daz += ceildist;
                            daz2 -= flordist;
                            if ((z < daz) && (z > daz2))
                            {
                                /*
                                 * These lines get the 2 points of the rotated sprite
                                 * Given: (x1, y1) starts out as the center point
                                 */
                                tilenum = spr.picnum;
                                xoff = (int)((byte)((Engine.picanm[tilenum] >> 8) & 255)) + ((int)spr.xoffset);
                                if ((cstat & 4) > 0) xoff = -xoff;
                                k = spr.ang;
                                l = spr.xrepeat;
                                dax = Engine.table.sintable[k & 2047] * l;
                                day = Engine.table.sintable[(k + 1536) & 2047] * l;
                                l = Engine.tilesizx[tilenum];
                                k = (l >> 1) + xoff;
                                x1 -= pragmas.mulscale16(dax, k);
                                x2 = x1 + pragmas.mulscale16(dax, l);
                                y1 -= pragmas.mulscale16(day, k);
                                y2 = y1 + pragmas.mulscale16(day, l);
                                if (Engine.clipinsideboxline(cx, cy, x1, y1, x2, y2, rad) != false)
                                {
                                    dax = pragmas.mulscale14(Engine.table.sintable[(spr.ang + 256 + 512) & 2047], walldist);
                                    day = pragmas.mulscale14(Engine.table.sintable[(spr.ang + 256) & 2047], walldist);

                                    if ((x1 - x) * (y2 - y) >= (x2 - x) * (y1 - y))   /* Front */
                                    {
                                        addclipline(x1 + dax, y1 + day, x2 + day, y2 - dax, (short)j + 49152);
                                    }
                                    else
                                    {
                                        if ((cstat & 64) != 0) continue;
                                        addclipline(x2 - dax, y2 - day, x1 - day, y1 + dax, (short)j + 49152);
                                    }

                                    /* Side blocker */
                                    if ((x2 - x1) * (x - x1) + (y2 - y1) * (y - y1) < 0)
                                    {
                                        addclipline(x1 - day, y1 + dax, x1 + dax, y1 + day, (short)j + 49152);
                                    }
                                    else if ((x1 - x2) * (x - x2) + (y1 - y2) * (y - y2) < 0)
                                    {
                                        addclipline(x2 + day, y2 - dax, x2 - dax, y2 - day, (short)j + 49152);
                                    }
                                }
                            }
                            break;
                        case 32:
                            daz = spr.z + ceildist;
                            daz2 = spr.z - flordist;
                            if ((z < daz) && (z > daz2))
                            {
                                if ((cstat & 64) != 0)
                                    if ((z > spr.z) == ((cstat & 8) == 0)) continue;

                                tilenum = spr.picnum;
                                xoff = (int)((byte)((Engine.picanm[tilenum] >> 8) & 255)) + ((int)spr.xoffset);
                                yoff = (int)((byte)((Engine.picanm[tilenum] >> 16) & 255)) + ((int)spr.yoffset);
                                if ((cstat & 4) > 0) xoff = -xoff;
                                if ((cstat & 8) > 0) yoff = -yoff;

                                k = spr.ang;
                                cosang = Engine.table.sintable[(k + 512) & 2047];
                                sinang = Engine.table.sintable[k];
                                xspan = Engine.tilesizx[tilenum];  //Engine.tilesizx[tilenum];
                                xrepeat = spr.xrepeat;
                                yspan = Engine.tilesizy[tilenum];// Engine.tilesizy[tilenum];
                                yrepeat = spr.yrepeat;

                                dax = ((xspan >> 1) + xoff) * xrepeat;
                                day = ((yspan >> 1) + yoff) * yrepeat;
                                rxi[0] = x1 + pragmas.dmulscale16(sinang, dax, cosang, day);
                                ryi[0] = y1 + pragmas.dmulscale16(sinang, day, -cosang, dax);
                                l = xspan * xrepeat;
                                rxi[1] = rxi[0] - pragmas.mulscale16(sinang, l);
                                ryi[1] = ryi[0] + pragmas.mulscale16(cosang, l);
                                l = yspan * yrepeat;
                                k = -pragmas.mulscale16(cosang, l);
                                rxi[2] = rxi[1] + k;
                                rxi[3] = rxi[0] + k;
                                k = -pragmas.mulscale16(sinang, l);
                                ryi[2] = ryi[1] + k;
                                ryi[3] = ryi[0] + k;

                                dax = pragmas.mulscale14(Engine.table.sintable[(spr.ang - 256 + 512) & 2047], walldist);
                                day = pragmas.mulscale14(Engine.table.sintable[(spr.ang - 256) & 2047], walldist);

                                if ((rxi[0] - x) * (ryi[1] - y) < (rxi[1] - x) * (ryi[0] - y))
                                {
                                    if (Engine.clipinsideboxline(cx, cy, rxi[1], ryi[1], rxi[0], ryi[0], rad) != false)
                                        addclipline(rxi[1] - day, ryi[1] + dax, rxi[0] + dax, ryi[0] + day, (short)j + 49152);
                                }
                                else if ((rxi[2] - x) * (ryi[3] - y) < (rxi[3] - x) * (ryi[2] - y))
                                {
                                    if (Engine.clipinsideboxline(cx, cy, rxi[3], ryi[3], rxi[2], ryi[2], rad) != false)
                                        addclipline(rxi[3] + day, ryi[3] - dax, rxi[2] - dax, ryi[2] - day, (short)j + 49152);
                                }

                                if ((rxi[1] - x) * (ryi[2] - y) < (rxi[2] - x) * (ryi[1] - y))
                                {
                                    if (Engine.clipinsideboxline(cx, cy, rxi[2], ryi[2], rxi[1], ryi[1], rad) != false)
                                        addclipline(rxi[2] - dax, ryi[2] - day, rxi[1] - day, ryi[1] + dax, (short)j + 49152);
                                }
                                else if ((rxi[3] - x) * (ryi[0] - y) < (rxi[0] - x) * (ryi[3] - y))
                                {
                                    if (Engine.clipinsideboxline(cx, cy, rxi[0], ryi[0], rxi[3], ryi[3], rad) != false)
                                        addclipline(rxi[0] + dax, ryi[0] + day, rxi[3] + day, ryi[3] - dax, (short)j + 49152);
                                }
                            }
                            break;
                    }
                }
            } while (clipsectcnt < clipsectnum);


            hitwall = 0;
            cnt = clipmoveboxtracenum;
            do
            {
                intx = goalx; inty = goaly;
                if ((hitwall = raytrace((int)x, (int)y, ref intx, ref inty)) >= 0)
                {
                    lx = clipit[hitwall].x2 - clipit[hitwall].x1;
                    ly = clipit[hitwall].y2 - clipit[hitwall].y1;
                    templong2 = lx * lx + ly * ly;
                    if (templong2 > 0)
                    {
                        templong1 = (goalx - intx) * lx + (goaly - inty) * ly;

                        if ((pragmas.klabs(templong1) >> 11) < templong2)
                            i = pragmas.divscale20(templong1, templong2);
                        else
                            i = 0;
                        goalx = pragmas.mulscale20(lx, i) + intx;
                        goaly = pragmas.mulscale20(ly, i) + inty;
                    }

                    templong1 = pragmas.dmulscale6(lx, oxvect, ly, oyvect);
                    for (i = cnt + 1; i <= clipmoveboxtracenum; i++)
                    {
                        j = hitwalls[i];
                        templong2 = pragmas.dmulscale6(clipit[j].x2 - clipit[j].x1, oxvect, clipit[j].y2 - clipit[j].y1, oyvect);
                        if ((templong1 ^ templong2) < 0)
                        {
                            updatesector((int)x, (int)y, ref sectnum);
                            return (retval);
                        }
                    }

                    keepaway(ref goalx, ref goaly, hitwall);
                    xvect = ((goalx - intx) << 14);
                    yvect = ((goaly - inty) << 14);

                    if (cnt == clipmoveboxtracenum) retval = clipobjectval[hitwall];
                    hitwalls[cnt] = (int)hitwall;
                }
                cnt--;

                x = intx;
                y = inty;
            } while (((xvect | yvect) != 0) && (hitwall >= 0) && (cnt > 0));

            for (j = 0; j < clipsectnum; j++)
                if (inside((int)x, (int)y, (short)clipsectorlist[j]) == 1)
                {
                    sectnum = (short)clipsectorlist[j];
                    return (retval);
                }

            sectnum = -1; templong1 = 0x7fffffff;
            for (j = numsectors - 1; j >= 0; j--)
                if (inside((int)x, (int)y, (short)j) == 1)
                {
                    if ((sector[j].ceilingstat & 2) != 0)
                        templong2 = (getceilzofslope((short)j, (int)x, (int)y) - ((int)z));
                    else
                        templong2 = (sector[j].ceilingz - ((int)z));

                    if (templong2 > 0)
                    {
                        if (templong2 < templong1)
                        { sectnum = (short)j; templong1 = templong2; }
                    }
                    else
                    {
                        if ((sector[j].floorstat & 2) != 0)
                            templong2 = (int)(z) - getflorzofslope((short)j, (int)x, (int)y);
                        else
                            templong2 = ((int)(z) - sector[j].floorz);

                        if (templong2 <= 0)
                        {
                            sectnum = (short)j;
                            return (retval);
                        }
                        if (templong2 < templong1)
                        { sectnum = (short)j; templong1 = templong2; }
                    }
                }

            return (retval);
        }

        //
        // keepaway (internal)
        //
        private void keepaway(ref int x, ref int y, int w)
        {
            int dx, dy, ox, oy, x1, y1;
            bool first;

            x1 = clipit[w].x1; dx = clipit[w].x2 - x1;
            y1 = clipit[w].y1; dy = clipit[w].y2 - y1;
            ox = pragmas.ksgn(-dy); oy = pragmas.ksgn(dx);
            first = (pragmas.klabs(dx) <= pragmas.klabs(dy));
            while (true)
            {
                if (dx * (y - y1) > (x - x1) * dy)
                    return;
                if (first == false)
                    x += ox;
                else
                    y += oy;
                first ^= true;
            }
        }

        public int clipinsidebox(int x, int y, short wallnum, int walldist)
        {
            walltype wal;
            int x1, y1, x2, y2, r;

            if (wall[wallnum] == null)
                return 0;

            r = (walldist << 1);
            wal = wall[wallnum]; x1 = wal.x + walldist - x; y1 = wal.y + walldist - y;
            wal = wall[wal.point2]; x2 = wal.x + walldist - x; y2 = wal.y + walldist - y;

            if ((x1 < 0) && (x2 < 0)) return (0);
            if ((y1 < 0) && (y2 < 0)) return (0);
            if ((x1 >= r) && (x2 >= r)) return (0);
            if ((y1 >= r) && (y2 >= r)) return (0);

            x2 -= x1; y2 -= y1;
            if (x2 * (walldist - y1) >= y2 * (walldist - x1))  //Front
            {
                if (x2 > 0) x2 *= (0 - y1); else x2 *= (r - y1);
                if (y2 > 0) y2 *= (r - x1); else y2 *= (0 - x1);

                if (x2 < y2)
                    return 1;

                return 0;
            }
            if (x2 > 0) x2 *= (r - y1); else x2 *= (0 - y1);
            if (y2 > 0) y2 *= (0 - x1); else y2 *= (r - x1);

            int ret = 0;
            if (x2 >= y2)
            {
                ret = 1;
            }

            return (ret << 1);
        }

        public void getzrange(int x, int y, int z, short sectnum,
                             ref int ceilz, ref int ceilhit, ref int florz, ref int florhit,
                             int walldist, int cliptype)
        {
            sectortype sec;
            walltype wal, wal2;
            spritetype spr;
            int clipsectcnt, startwall, endwall, tilenum, xoff, yoff, dax, day;
            int xmin, ymin, xmax, ymax, i, j, k, l, daz = 0, daz2 = 0, dx, dy;
            int x1, y1, x2, y2, x3, y3, x4, y4, ang, cosang, sinang;
            int xspan, yspan, xrepeat, yrepeat, dasprclipmask, dawalclipmask, wallnum;
            short cstat;
            char bad;
            bool clipyou;

            if (sectnum < 0)
            {
                ceilz = unchecked((int)0x80000000); ceilhit = -1;
                florz = 0x7fffffff; florhit = -1;
                return;
            }

            //Extra walldist for sprites on sector lines
            i = walldist + MAXCLIPDIST + 1;
            xmin = x - i; ymin = y - i;
            xmax = x + i; ymax = y + i;

            getzsofslope((short)sectnum, x, y, ref ceilz, ref florz);
            ceilhit = sectnum + 16384; florhit = sectnum + 16384;

            dawalclipmask = (cliptype & 65535);
            dasprclipmask = (cliptype >> 16);

            clipsectorlist[0] = sectnum;
            clipsectcnt = 0; clipsectnum = 1;

            do  //Collect sectors inside your square first
            {
                sec = sector[clipsectorlist[clipsectcnt]];
                startwall = sec.wallptr; endwall = startwall + sec.wallnum;
                for (j = startwall, wallnum = 0; j < endwall; j++, wallnum++)
                {
                    wal = wall[startwall + wallnum];

                    k = wal.nextsector;
                    if (k >= 0)
                    {
                        wal2 = wall[wal.point2];
                        x1 = wal.x; x2 = wal2.x;
                        if ((x1 < xmin) && (x2 < xmin)) continue;
                        if ((x1 > xmax) && (x2 > xmax)) continue;
                        y1 = wal.y; y2 = wal2.y;
                        if ((y1 < ymin) && (y2 < ymin)) continue;
                        if ((y1 > ymax) && (y2 > ymax)) continue;

                        dx = x2 - x1; dy = y2 - y1;
                        if (dx * (y - y1) < (x - x1) * dy) continue; //back
                        if (dx > 0) dax = dx * (ymin - y1); else dax = dx * (ymax - y1);
                        if (dy > 0) day = dy * (xmax - x1); else day = dy * (xmin - x1);
                        if (dax >= day) continue;

                        if ((wal.cstat & dawalclipmask) != 0) continue;
                        sec = sector[k];
                        if (/*editstatus == 0*/ true)
                        {
                            if (((sec.ceilingstat & 1) == 0) && (z <= sec.ceilingz + (3 << 8))) continue;
                            if (((sec.floorstat & 1) == 0) && (z >= sec.floorz - (3 << 8))) continue;
                        }

                        for (i = clipsectnum - 1; i >= 0; i--) if (clipsectorlist[i] == k) break;
                        if (i < 0) clipsectorlist[clipsectnum++] = (int)k;

                        if ((x1 < xmin + MAXCLIPDIST) && (x2 < xmin + MAXCLIPDIST)) continue;
                        if ((x1 > xmax - MAXCLIPDIST) && (x2 > xmax - MAXCLIPDIST)) continue;
                        if ((y1 < ymin + MAXCLIPDIST) && (y2 < ymin + MAXCLIPDIST)) continue;
                        if ((y1 > ymax - MAXCLIPDIST) && (y2 > ymax - MAXCLIPDIST)) continue;
                        if (dx > 0) dax += dx * MAXCLIPDIST; else dax -= dx * MAXCLIPDIST;
                        if (dy > 0) day -= dy * MAXCLIPDIST; else day += dy * MAXCLIPDIST;
                        if (dax >= day) continue;

                        //It actually got here, through all the continue's!!!
                        daz = 0;
                        daz2 = 0;
                        getzsofslope((short)k, x, y, ref daz, ref daz2);
                        if (daz > ceilz) { ceilz = daz; ceilhit = k + 16384; }
                        if (daz2 < florz) { florz = daz2; florhit = k + 16384; }
                    }
                }
                clipsectcnt++;
            } while (clipsectcnt < clipsectnum);
 
	        for(i=0;i<clipsectnum;i++)
	        {
		        for(j=headspritesect[clipsectorlist[i]];j>=0;j=nextspritesect[j])
		        {
			        spr = sprite[j];
			        cstat = spr.cstat;
			        if ((cstat&dasprclipmask) != 0)
			        {
				        x1 = spr.x; y1 = spr.y;

				        clipyou = false;
				        switch((int)(cstat&48))
				        {
					        case 0:
						        k = walldist+(spr.clipdist<<2)+1;
						        if ((pragmas.klabs(x1-x) <= k) && (pragmas.klabs(y1-y) <= k))
						        {
							        daz = spr.z;
							        k = ((Engine.tilesizy[spr.picnum]*spr.yrepeat)<<1);
							        if ((cstat&128) != 0) daz += k;
							        if ((Engine.picanm[spr.picnum]&0x00ff0000) != 0) daz -= ((int)((sbyte)((Engine.picanm[spr.picnum]>>16)&255))*spr.yrepeat<<2);
							        daz2 = daz - (k<<1);
							        clipyou = true;
						        }
						        break;
					        case 16:
						        tilenum = spr.picnum;
						        xoff = (int)((sbyte)((Engine.picanm[tilenum]>>8)&255))+((int)spr.xoffset);
						        if ((cstat&4) > 0) xoff = -xoff;
						        k = spr.ang; l = spr.xrepeat;
						        dax = Engine.table.sintable[k&2047]*l; day = Engine.table.sintable[(k+1536)&2047]*l;
						        l = Engine.tilesizx[tilenum]; k = (l>>1)+xoff;
						        x1 -= pragmas.mulscale16(dax,k); x2 = x1+pragmas.mulscale16(dax,l);
						        y1 -= pragmas.mulscale16(day,k); y2 = y1+pragmas.mulscale16(day,l);
						        if (Engine.clipinsideboxline(x,y,x1,y1,x2,y2,walldist+1))
						        {
							        daz = spr.z; k = ((Engine.tilesizy[spr.picnum]*spr.yrepeat)<<1);
							        if ((cstat&128) != 0) daz += k;
							        if ((Engine.picanm[spr.picnum]&0x00ff0000) != 0) daz -= ((int)((sbyte)((Engine.picanm[spr.picnum]>>16)&255))*spr.yrepeat<<2);
							        daz2 = daz-(k<<1);
							        clipyou = true;
						        }
						        break;
					        case 32:
						        daz = spr.z; daz2 = daz;

						        if ((cstat&64) != 0)
							        if ((z > daz) == ((cstat&8)==0)) continue;

						        tilenum = spr.picnum;
						        xoff = (int)((sbyte)((Engine.picanm[tilenum]>>8)&255))+((int)spr.xoffset);
						        yoff = (int)((sbyte)((Engine.picanm[tilenum]>>16)&255))+((int)spr.yoffset);
						        if ((cstat&4) > 0) xoff = -xoff;
						        if ((cstat&8) > 0) yoff = -yoff;

						        ang = spr.ang;
						        cosang = Engine.table.sintable[(ang+512)&2047]; sinang = Engine.table.sintable[ang];
						        xspan = Engine.tilesizx[tilenum]; xrepeat = spr.xrepeat;
						        yspan = Engine.tilesizy[tilenum]; yrepeat = spr.yrepeat;

						        dax = ((xspan>>1)+xoff)*xrepeat; day = ((yspan>>1)+yoff)*yrepeat;
						        x1 += pragmas.dmulscale16(sinang,dax,cosang,day)-x;
						        y1 += pragmas.dmulscale16(sinang,day,-cosang,dax)-y;
						        l = xspan*xrepeat;
						        x2 = x1 - pragmas.mulscale16(sinang,l);
						        y2 = y1 + pragmas.mulscale16(cosang,l);
						        l = yspan*yrepeat;
						        k = -pragmas.mulscale16(cosang,l); x3 = x2+k; x4 = x1+k;
						        k = -pragmas.mulscale16(sinang,l); y3 = y2+k; y4 = y1+k;

						        dax = pragmas.mulscale14(Engine.table.sintable[(spr.ang-256+512)&2047],walldist+4);
						        day = pragmas.mulscale14(Engine.table.sintable[(spr.ang-256)&2047],walldist+4);
						        x1 += dax; x2 -= day; x3 -= dax; x4 += day;
						        y1 += day; y2 += dax; y3 -= day; y4 -= dax;

						        if ((y1^y2) < 0)
						        {
							        if ((x1^x2) < 0) clipyou ^= (x1*y2<x2*y1)^(y1<y2);
							        else if (x1 >= 0) clipyou ^= true;
						        }
						        if ((y2^y3) < 0)
						        {
							        if ((x2^x3) < 0) clipyou ^= (x2*y3<x3*y2)^(y2<y3);
							        else if (x2 >= 0) clipyou ^= true;
						        }
						        if ((y3^y4) < 0)
						        {
							        if ((x3^x4) < 0) clipyou ^= (x3*y4<x4*y3)^(y3<y4);
							        else if (x3 >= 0) clipyou ^= true;
						        }
						        if ((y4^y1) < 0)
						        {
							        if ((x4^x1) < 0) clipyou ^= (x4*y1<x1*y4)^(y4<y1);
							        else if (x4 >= 0) clipyou ^= true;
						        }
						        break;
				        }

				        if (clipyou != false)
				        {
					        if ((z > daz) && (daz > ceilz)) { ceilz = daz; ceilhit = j+49152; }
					        if ((z < daz2) && (daz2 < florz)) { florz = daz2; florhit = j+49152; }
				        }
			        }
		        }
	        }
        }

        //
        // pushmove
        //
        public int pushmove(ref int x, ref int y, ref int z, ref short sectnum,
                 int walldist, int ceildist, int flordist, uint cliptype)
        {
            sectortype sec, sec2;
            walltype wal, wal2;
            spritetype spr;
            int i, j, k, t, dx, dy, dax, day, daz, daz2, bad, dir;
            int dasprclipmask, dawalclipmask;
            int startwall, endwall, clipsectcnt;
            byte bad2;

            if ((sectnum) < 0) return (-1);

            dawalclipmask = (int)(cliptype & 65535);
            dasprclipmask = (int)(cliptype >> 16);

            k = 32;
            dir = 1;
            do
            {
                bad = 0;

                clipsectorlist[0] = sectnum;
                clipsectcnt = 0; clipsectnum = 1;
                do
                {
                    /*Push FACE sprites
			        for(i=headspritesect[clipsectorlist[clipsectcnt]];i>=0;i=nextspritesect[i])
			        {
				        spr = &sprite[i];
				        if (((spr.cstat&48) != 0) && ((spr.cstat&48) != 48)) continue;
				        if ((spr.cstat&dasprclipmask) == 0) continue;

				        dax = x-spr.x; day = y-spr.y;
				        t = (spr.clipdist<<2)+walldist;
				        if ((klabs(dax) < t) && (klabs(day) < t))
				        {
					        t = ((tilesizy[spr.picnum]*spr.yrepeat)<<2);
					        if (spr.cstat&128) daz = spr.z+(t>>1); else daz = spr.z;
					        if (picanm[spr.picnum]&0x00ff0000) daz -= ((int)((signed char)((picanm[spr.picnum]>>16)&255))*spr.yrepeat<<2);
					        if ((z < daz+ceildist) && (z > daz-t-flordist))
					        {
						        t = (spr.clipdist<<2)+walldist;

						        j = getangle(dax,day);
						        dx = (sintable[(j+512)&2047]>>11);
						        dy = (sintable[(j)&2047]>>11);
						        bad2 = 16;
						        do
						        {
							        *x = x + dx; *y = y + dy;
							        bad2--; if (bad2 == 0) break;
						        } while ((klabs(x-spr.x) < t) && (klabs(y-spr.y) < t));
						        bad = -1;
						        k--; if (k <= 0) return(bad);
						        updatesector(*x,*y,sectnum);
					        }
				        }
			        }*/

                    if (clipsectcnt < 0)
                        return 0;

                    if (clipsectorlist[clipsectcnt] < 0)
                        return 0;

                    sec = sector[clipsectorlist[clipsectcnt]];
                    if (dir > 0)
                    {
                        startwall = sec.wallptr; endwall = startwall + sec.wallnum;
                    }
                    else
                    {
                        endwall = sec.wallptr; startwall = endwall + sec.wallnum;
                    }

                    int walnum = startwall;
                    for (i = startwall; i != endwall; i += dir, walnum += dir)
                    {
                        wal = wall[walnum];
                        if (clipinsidebox(x, y, (short)i, walldist - 4) == 1)
                        {
                            j = 0;
                            if (wal.nextsector < 0) j = 1;
                            if ((wal.cstat & dawalclipmask) != 0) j = 1;
                            if (j == 0)
                            {
                                sec2 = sector[wal.nextsector];


                                //Find closest point on wall (dax, day) to (*x, *y)
                                dax = wall[wal.point2].x - wal.x;
                                day = wall[wal.point2].y - wal.y;
                                daz = dax * ((x) - wal.x) + day * ((y) - wal.y);
                                if (daz <= 0)
                                    t = 0;
                                else
                                {
                                    daz2 = dax * dax + day * day;
                                    if (daz >= daz2) t = (1 << 30); else t = pragmas.divscale30(daz, daz2);
                                }
                                dax = wal.x + pragmas.mulscale30(dax, t);
                                day = wal.y + pragmas.mulscale30(day, t);


                                daz = getflorzofslope((short)clipsectorlist[clipsectcnt], dax, day);
                                daz2 = getflorzofslope(wal.nextsector, dax, day);
                                if ((daz2 < daz - (1 << 8)) && ((sec2.floorstat & 1) == 0))
                                    if (z >= daz2 - (flordist - 1)) j = 1;

                                daz = getceilzofslope((short)clipsectorlist[clipsectcnt], dax, day);
                                daz2 = getceilzofslope(wal.nextsector, dax, day);
                                if ((daz2 > daz + (1 << 8)) && ((sec2.ceilingstat & 1) == 0))
                                    if (z <= daz2 + (ceildist - 1)) j = 1;
                            }
                            if (j != 0)
                            {
                                j = Engine.getangle(wall[wal.point2].x - wal.x, wall[wal.point2].y - wal.y);
                                dx = (Engine.table.sintable[(j + 1024) & 2047] >> 11);
                                dy = (Engine.table.sintable[(j + 512) & 2047] >> 11);
                                bad2 = 16;
                                do
                                {
                                    x = x + dx; y = y + dy;
                                    bad2--; if (bad2 == 0) break;
                                } while (clipinsidebox(x, y, (short)i, walldist - 4) != 0);
                                bad = -1;
                                k--; if (k <= 0) return (bad);
                                updatesector(x, y, ref sectnum);
                            }
                            else
                            {
                                for (j = clipsectnum - 1; j >= 0; j--)
                                    if (wal.nextsector == clipsectorlist[j]) break;
                                if (j < 0) clipsectorlist[clipsectnum++] = wal.nextsector;
                            }
                        }
                    }
                    clipsectcnt++;
                } while (clipsectcnt < clipsectnum);
                dir = -dir;
            } while (bad != 0);

            return (bad);
        }


        //
        // raytrace (internal)
        //
        private int raytrace(int x3, int y3, ref int x4, ref int y4)
        {
            int x1, y1, x2, y2, bot, topu, nintx, ninty, cnt, z, hitwall;
            int x21, y21, x43, y43;

            hitwall = -1;
            for (z = clipnum - 1; z >= 0; z--)
            {
                x1 = clipit[z].x1; x2 = clipit[z].x2; x21 = x2 - x1;
                y1 = clipit[z].y1; y2 = clipit[z].y2; y21 = y2 - y1;

                topu = x21 * (y3 - y1) - (x3 - x1) * y21; if (topu <= 0) continue;
                if (x21 * (y4 - y1) > (x4 - x1) * y21) continue;
                x43 = x4 - x3; y43 = y4 - y3;
                if (x43 * (y1 - y3) > (x1 - x3) * y43) continue;
                if (x43 * (y2 - y3) <= (x2 - x3) * y43) continue;
                bot = x43 * y21 - x21 * y43; if (bot == 0) continue;

                cnt = 256;
                do
                {
                    cnt--; if (cnt < 0) { x4 = x3; y4 = y3; return (z); }
                    nintx = x3 + pragmas.scale(x43, topu, bot);
                    ninty = y3 + pragmas.scale(y43, topu, bot);
                    topu--;
                } while (x21 * (ninty - y1) <= (nintx - x1) * y21);

                if (pragmas.klabs(x3 - nintx) + pragmas.klabs(y3 - ninty) < pragmas.klabs(x3 - x4) + pragmas.klabs(y3 - y4))
                { x4 = nintx; y4 = ninty; hitwall = z; }
            }
            return (hitwall);
        }

        private void parascan(int dax1, int dax2, int sectnum, char dastat, int bunch)
        {
            sectortype sec;
            int i, j = 0, k, l, m, n, x, y, z, wallnum, nextsectnum, globalhorizbak;
            short[] topptr, botptr;

            sectnum = thesector[bunchfirst[bunch]]; sec = sector[sectnum];

            globalhorizbak = globalhoriz;
            if (parallaxyscale != 65536)
                globalhoriz = pragmas.mulscale16(globalhoriz - (Engine._device.ydimen >> 1), parallaxyscale) + ((Engine._device.ydimen >> 1));
            globvis = globalpisibility;
            //globalorientation = 0L;
            if (sec.visibility != 0) globvis = pragmas.mulscale4(globvis, (int)((byte)(sec.visibility + 16)));

            if (dastat == 0)
            {
                globalpal = sec.ceilingpal;
                globalpicnum = sec.ceilingpicnum;
                globalshade = (int)sec.ceilingshade;
                globalxpanning = (int)sec.ceilingxpanning;
                globalypanning = (int)sec.ceilingypanning;
                topptr = umost;
                botptr = uplc;
            }
            else
            {
                globalpal = sec.floorpal;
                globalpicnum = sec.floorpicnum;
                globalshade = (int)sec.floorshade;
                globalxpanning = (int)sec.floorxpanning;
                globalypanning = (int)sec.floorypanning;
                topptr = dplc;
                botptr = dmost;
            }

            if (globalpicnum >= Engine.MAXTILES) globalpicnum = 0;
            if ((Engine.picanm[globalpicnum] & 192) != 0) globalpicnum += Engine.animateoffs((short)globalpicnum, (short)sectnum);
            globalshiftval = (Engine.picsiz[globalpicnum] >> 4);
            if (Engine.pow2long[globalshiftval] != Engine.tilesizy[globalpicnum]) globalshiftval++;
            globalshiftval = 32 - globalshiftval;
            globalzd = (((Engine.tilesizy[globalpicnum] >> 1) + parallaxyoffs) << (int)globalshiftval) + (globalypanning << 24);
            globalyscale = (8 << ((int)globalshiftval - 19));
            //if (globalorientation&256) globalyscale = -globalyscale, globalzd = -globalzd;

            k = 11 - (Engine.picsiz[globalpicnum] & 15) - pskybits;
            x = -1;

            for (z = bunchfirst[bunch]; z >= 0; z = p2[z])
            {
                wallnum = thewall[z]; nextsectnum = wall[wallnum].nextsector;
                if (nextsectnum > 0)
                {
                    if (dastat == 0) j = sector[nextsectnum].ceilingstat;
                    else j = sector[nextsectnum].floorstat;
                }

                if ((nextsectnum < 0) || ((wall[wallnum].cstat & 32) != 0) || ((j & 1) == 0))
                {
                    if (x == -1) x = xb1[z];

                    if (parallaxtype == 0)
                    {
                        n = pragmas.mulscale16(Engine._device.xdimenrecip, Engine._device.viewingrange);
                        for (j = xb1[z]; j <= xb2[z]; j++)
                            lplc[j] = (((pragmas.mulscale23(j - Engine._device.halfxdimen, n) + globalang) & 2047) >> (int)k);
                    }
                    else
                    {
                        for (j = xb1[z]; j <= xb2[z]; j++)
                            lplc[j] = ((((int)radarang2[j] + globalang) & 2047) >> (int)k);
                    }
                    if (parallaxtype == 2)
                    {
                        n = pragmas.mulscale16(Engine._device.xdimscale, Engine._device.viewingrange);
                        for (j = xb1[z]; j <= xb2[z]; j++)
                            swplc[j] = pragmas.mulscale14(Engine.table.sintable[((int)radarang2[j] + 512) & 2047], n);
                    }
                    else
                        clearbuf(xb1[z], ref swplc, xb2[z] - xb1[z] + 1, pragmas.mulscale16(Engine._device.xdimscale, Engine._device.viewingrange));
                }
                else if (x >= 0)
                {
                    l = globalpicnum; m = (Engine.picsiz[globalpicnum] & 15);
                    globalpicnum = l + pskyoff[lplc[x] >> (int)m];

                    if (((lplc[x] ^ lplc[xb1[z] - 1]) >> (int)m) == 0)
                        wallscan(x, xb1[z] - 1, ref topptr, ref botptr, ref swplc, ref lplc);
                    else
                    {
                        j = x;
                        while (x < xb1[z])
                        {
                            n = l + pskyoff[lplc[x] >> (int)m];
                            if (n != globalpicnum)
                            {
                                wallscan(j, x - 1, ref topptr, ref botptr, ref swplc, ref lplc);
                                j = x;
                                globalpicnum = n;
                            }
                            x++;
                        }
                        if (j < x)
                            wallscan(j, x - 1, ref topptr, ref botptr, ref swplc, ref lplc);
                    }

                    globalpicnum = l;
                    x = -1;
                }
            }

            if (x >= 0)
            {
                l = globalpicnum; m = (Engine.picsiz[globalpicnum] & 15);
                globalpicnum = l + pskyoff[lplc[x] >> (int)m];

                if (((lplc[x] ^ lplc[xb2[bunchlast[bunch]]]) >> (int)m) == 0)
                    wallscan(x, xb2[bunchlast[bunch]], ref topptr, ref botptr, ref swplc, ref lplc);
                else
                {
                    j = x;
                    while (x <= xb2[bunchlast[bunch]])
                    {
                        n = l + pskyoff[lplc[x] >> (int)m];
                        if (n != globalpicnum)
                        {
                            wallscan(j, x - 1, ref topptr, ref botptr, ref swplc, ref lplc);
                            j = x;
                            globalpicnum = n;
                        }
                        x++;
                    }
                    if (j <= x)
                        wallscan(j, x, ref topptr, ref botptr, ref swplc, ref lplc);
                }
                globalpicnum = l;
            }
            globalhoriz = globalhorizbak;
        }

        //
        // prepwall (internal)
        //
        private void prepwall(int z, walltype wal)
        {
            int i, l = 0, ol = 0, splc, sinc, x, topinc, top, botinc, bot, walxrepeat;

            walxrepeat = (wal.xrepeat << 3);

            //lwall calculation
            i = xb1[z] - Engine._device.halfxdimen;
            topinc = -(ry1[z] >> 2);
            botinc = ((ry2[z] - ry1[z]) >> 8);
            top = pragmas.mulscale5(rx1[z], Engine._device.xdimen) + pragmas.mulscale2(topinc, i);
            bot = pragmas.mulscale11(rx1[z] - rx2[z], Engine._device.xdimen) + pragmas.mulscale2(botinc, i);

            splc = pragmas.mulscale19(ry1[z], Engine._device.xdimscale);
            sinc = pragmas.mulscale16(ry2[z] - ry1[z], Engine._device.xdimscale);

            x = xb1[z];
            if (bot != 0)
            {
                l = pragmas.divscale12(top, bot);
                swall[x] = pragmas.mulscale21(l, sinc) + splc;
                l *= walxrepeat;
                lwall[x] = (l >> 18);
            }
            while (x + 4 <= xb2[z])
            {
                top += topinc; bot += botinc;
                if (bot != 0)
                {
                    ol = l; l = pragmas.divscale12(top, bot);
                    swall[x + 4] = pragmas.mulscale21(l, sinc) + splc;
                    l *= walxrepeat;
                    lwall[x + 4] = (l >> 18);
                }
                i = ((ol + l) >> 1);
                lwall[x + 2] = (i >> 18);
                lwall[x + 1] = ((ol + i) >> 19);
                lwall[x + 3] = ((l + i) >> 19);
                swall[x + 2] = ((swall[x] + swall[x + 4]) >> 1);
                swall[x + 1] = ((swall[x] + swall[x + 2]) >> 1);
                swall[x + 3] = ((swall[x + 4] + swall[x + 2]) >> 1);
                x += 4;
            }
            if (x + 2 <= xb2[z])
            {
                top += (topinc >> 1); bot += (botinc >> 1);
                if (bot != 0)
                {
                    ol = l; l = pragmas.divscale12(top, bot);
                    swall[x + 2] = pragmas.mulscale21(l, sinc) + splc;
                    l *= walxrepeat;
                    lwall[x + 2] = (l >> 18);
                }
                lwall[x + 1] = ((l + ol) >> 19);
                swall[x + 1] = ((swall[x] + swall[x + 2]) >> 1);
                x += 2;
            }
            if (x + 1 <= xb2[z])
            {
                bot += (botinc >> 2);
                if (bot != 0)
                {
                    l = pragmas.divscale12(top + (topinc >> 2), bot);
                    swall[x + 1] = pragmas.mulscale21(l, sinc) + splc;
                    lwall[x + 1] = pragmas.mulscale18(l, walxrepeat);
                }
            }

            if (lwall[xb1[z]] < 0) lwall[xb1[z]] = 0;
            if ((lwall[xb2[z]] >= walxrepeat) && (walxrepeat != 0)) lwall[xb2[z]] = walxrepeat - 1;
            if ((wal.cstat & 8) != 0)
            {
                walxrepeat--;
                for (x = xb1[z]; x <= xb2[z]; x++) lwall[x] = walxrepeat - lwall[x];
            }
        }

        private bool spritewallfront(spritetype2 s, int w)
        {
            walltype wal;
            int x1, y1;

            wal = wall[w]; x1 = wal.x; y1 = wal.y;
            wal = wall[wal.point2];
            return (pragmas.dmulscale32(wal.x - x1, s.y - y1, -(s.x - x1), wal.y - y1) >= 0);
        }

        public void drawmasks()
        {
            int i, j, k, l, gap, xs, ys, zs, xp, yp, zp, z1, z2, yoff, yspan;

            //for(i=spritesortcnt-1;i>=0;i--) tspriteptr[i] = &tsprite[i];
            for (i = spritesortcnt - 1; i >= 0; i--)
            {
                xs = tsprite[i].x - globalposx; ys = tsprite[i].y - globalposy;
                yp = pragmas.dmulscale6(xs, cosviewingrangeglobalang, ys, sinviewingrangeglobalang);
                if (yp > (4 << 8))
                {
                    xp = pragmas.dmulscale6(ys, cosglobalang, -xs, singlobalang);
                    vissprites[i].x = pragmas.scale(xp + yp, Engine._device.xdimen << 7, yp);
                }
                else if ((tsprite[i].cstat & 48) == 0)
                {
                    spritesortcnt--;  //Delete face sprite if on wrong side!
                    if (i != spritesortcnt)
                    {
                        tsprite[i] = tsprite[spritesortcnt];
                        vissprites[i].x = vissprites[spritesortcnt].x;
                        vissprites[i].y = vissprites[spritesortcnt].y;
                    }
                    continue;
                }
                vissprites[i].y = yp;
            }

            gap = 1; while (gap < spritesortcnt) gap = (gap << 1) + 1;
            for (gap >>= 1; gap > 0; gap >>= 1)      //Sort sprite list
                for (i = 0; i < spritesortcnt - gap; i++)
                    for (l = i; l >= 0; l -= gap)
                    {
                        if (vissprites[l].y <= vissprites[l + gap].y) break;
                        pragmas.swaplong<spritetype2>(ref tsprite[l], ref tsprite[l + gap]);
                        pragmas.swaplong<VisSprite_t>(ref vissprites[l], ref vissprites[l + gap]);
                    }

            if (spritesortcnt > 0)
                vissprites[spritesortcnt].y = (vissprites[spritesortcnt - 1].y ^ 1);

            ys = vissprites[0].y; i = 0;
            for (j = 1; j <= spritesortcnt; j++)
            {
                if (vissprites[j].y == ys) continue;
                ys = vissprites[j].y;
                if (j > i + 1)
                {
                    for (k = i; k < j; k++)
                    {
                        vissprites[k].z = tsprite[k].z;
                        if ((tsprite[k].cstat & 48) != 32)
                        {
                            yoff = (int)((sbyte)((Engine.picanm[tsprite[k].picnum] >> 16) & 255)) + ((int)tsprite[k].yoffset);
                            vissprites[k].z -= ((yoff * tsprite[k].yrepeat) << 2);
                            yspan = (Engine.tilesizy[tsprite[k].picnum] * (tsprite[k].yrepeat << 2));
                            if ((tsprite[k].cstat & 128) == 0) vissprites[k].z -= (yspan >> 1);
                            if (pragmas.klabs(vissprites[k].z - globalposz) < (yspan >> 1)) vissprites[k].z = globalposz;
                        }
                    }
                    for (k = i + 1; k < j; k++)
                        for (l = i; l < k; l++)
                            if (pragmas.klabs(vissprites[k].z - globalposz) < pragmas.klabs(vissprites[l].z - globalposz))
                            {
                                pragmas.swaplong<spritetype2>(ref tsprite[k], ref tsprite[l]);
                                pragmas.swaplong<VisSprite_t>(ref vissprites[k], ref vissprites[l]);
                            }
                    for (k = i + 1; k < j; k++)
                        for (l = i; l < k; l++)
                            if (tsprite[k].statnum < tsprite[l].statnum)
                            {
                                pragmas.swaplong<spritetype2>(ref tsprite[k], ref tsprite[l]);
                                pragmas.swaplong<VisSprite_t>(ref vissprites[k], ref vissprites[l]);
                            }
                }
                i = j;
            }

            Engine.BeginDrawing();

            /*for(i=spritesortcnt-1;i>=0;i--)
	        {
		        xs = tspriteptr[i].x-globalposx;
		        ys = tspriteptr[i].y-globalposy;
		        zs = tspriteptr[i].z-globalposz;

		        xp = ys*cosglobalang-xs*singlobalang;
		        yp = (zs<<1);
		        zp = xs*cosglobalang+ys*singlobalang;

		        xs = scale(xp,halfxdimen<<12,zp)+((halfxdimen+windowx1)<<12);
		        ys = scale(yp,xdimenscale<<12,zp)+((globalhoriz+windowy1)<<12);

		        drawline256(xs-65536,ys-65536,xs+65536,ys+65536,31);
		        drawline256(xs+65536,ys-65536,xs-65536,ys+65536,31);
	        }*/

            while ((spritesortcnt > 0) && (maskwallcnt > 0))  //While BOTH > 0
            {
                j = maskwall[maskwallcnt - 1];
                if (spritewallfront(tsprite[spritesortcnt - 1], (int)thewall[j]) == false)
                {
                    drawsprite(--spritesortcnt);
                }
                else
                {
                    //Check to see if any sprites behind the masked wall...
                    k = -1;
                    gap = 0;
                    for (i = spritesortcnt - 2; i >= 0; i--)
                        if ((xb1[j] <= (vissprites[i].x >> 8)) && ((vissprites[i].x >> 8) <= xb2[j]))
                            if (spritewallfront(tsprite[i], (int)thewall[j]) == false)
                            {
                                drawsprite(i);
                                tsprite[i].owner = -1;
                                k = i;
                                gap++;
                            }
                    if (k >= 0)       //remove holes in sprite list
                    {
                        for (i = k; i < spritesortcnt; i++)
                            if (tsprite[i].owner >= 0)
                            {
                                if (i > k)
                                {
                                    tsprite[k] = tsprite[i];
                                    vissprites[k] = vissprites[i];
                                    //spritesx[k] = spritesx[i];
                                    //spritesy[k] = spritesy[i];
                                }
                                k++;
                            }
                        spritesortcnt -= gap;
                    }

                    //finally safe to draw the masked wall
                    drawmaskwall((short)--maskwallcnt);
                }
            }
            framesortcnt = spritesortcnt;
            while (spritesortcnt > 0) drawsprite(--spritesortcnt);
            while (maskwallcnt > 0) drawmaskwall((short)--maskwallcnt);

            Engine.EndDrawing();
        }

        private void maskwallscan(int x1, int x2, ref short[] uwal, ref short[] dwal, ref int[] swal, ref int[] lwal)
        {
            bool xnice, ynice;
            int i, x, startx, fpalookup, shade;
            int u4, d4, dax, z, tsizx, tsizy;
            char bad;
            int p = 0;

            tsizx = Engine.tilesizx[globalpicnum];
            tsizy = Engine.tilesizy[globalpicnum];
            Engine.setgotpic(globalpicnum);
            if ((tsizx <= 0) || (tsizy <= 0)) return;
            if ((uwal[x1] > Engine._device.ydimen) && (uwal[x2] > Engine._device.ydimen)) return;
            if ((dwal[x1] < 0) && (dwal[x2] < 0)) return;

            if (Engine.waloff[globalpicnum] == null) Engine.loadtile((short)globalpicnum);

            startx = x1;

            xnice = (Engine.pow2long[Engine.picsiz[globalpicnum] & 15] == tsizx);
            if (xnice) tsizx = (tsizx - 1);
            ynice = (Engine.pow2long[Engine.picsiz[globalpicnum] >> 4] == tsizy);
            if (ynice) tsizy = (Engine.picsiz[globalpicnum] >> 4);

            //fpalookup = Engine.palette.palookup[globalpal];

            A.setupmvlineasm(globalshiftval);

            // jv - was <=
            for (x = startx; x < x2; x++, p++)
            // jv end
            {
                y1ve[0] = Math.Max(uwal[x], Engine._device.startumost[x + Engine._device.windowx1] - Engine._device.windowy1);
                y2ve[0] = Math.Min(dwal[x], Engine._device.startdmost[x + Engine._device.windowx1] - Engine._device.windowy1);
                if (y2ve[0] <= y1ve[0])
                {
                    continue;
                }

                palookupoffse = (Engine.palette.getpalookup((int)pragmas.mulscale16(swal[x], globvis), globalshade) << 8);

                bufplce[0] = lwal[x] + globalxpanning;
                if (bufplce[0] >= tsizx) { if (xnice == false) bufplce[0] %= tsizx; else bufplce[0] &= tsizx; }
                if (ynice == false) bufplce[0] *= tsizy; else bufplce[0] = bufplce[0] << tsizy;

                vince[0] = swal[x] * globalyscale;
                vplce[0] = globalzd + vince[0] * (y1ve[0] - globalhoriz + 1);

                A.mvlineasm1(vince[0], Engine.palette.palookup, palookupoffse, y2ve[0] - y1ve[0] - 1, (uint)vplce[0], Engine.waloff[globalpicnum].memory, 0, bufplce[0], frameoffset + Engine.ylookup[y1ve[0]] + startx + p, tsizx, tsizy);
            }

            //faketimerhandler();
        }

        //
        // transmaskvline (internal)
        //
        private void transmaskvline(int x)
        {
            int palookupoffs;
            int p;
            int vplc, vinc, i;
            short y1v, y2v;
            byte[] bufplc;

            if ((x < 0) || (x >= Engine._device.xdimen)) return;

            y1v = (short)Math.Max(uwall[x], Engine._device.startumost[x + Engine._device.windowx1] - Engine._device.windowy1);
            y2v = (short)Math.Min(dwall[x], Engine._device.startdmost[x + Engine._device.windowx1] - Engine._device.windowy1);
            y2v--;
            if (y2v < y1v) return;

            palookupoffs = Engine.palette.palookup[globalpal] + (Engine.palette.getpalookup((int)pragmas.mulscale16(swall[x], globvis), globalshade) << 8);

            vinc = swall[x] * globalyscale;
            vplc = globalzd + vinc * (y1v - globalhoriz + 1);

            i = lwall[x] + globalxpanning;
            if (i >= Engine.tilesizx[globalpicnum]) i %= Engine.tilesizx[globalpicnum];
            bufplc = Engine.waloff[globalpicnum].memory;
            int bufplcval = (i * Engine.tilesizy[globalpicnum]);

            p = Engine.ylookup[y1v] + x + frameoffset;

            A.tvlineasm1(vinc, Engine.palette.palookup, palookupoffs, y2v - y1v, (uint)vplc, bufplc, bufplcval, p);
        }


        //
        // transmaskwallscan (internal)
        //
        private void transmaskwallscan(int x1, int x2)
        {
            int x;

            Engine.setgotpic(globalpicnum);

            if ((Engine.tilesizx[globalpicnum] <= 0) || (Engine.tilesizy[globalpicnum] <= 0)) return;

            if (Engine.waloff[globalpicnum] == null) Engine.loadtile((short)globalpicnum);

            A.setuptvlineasm(globalshiftval);

            x = x1;
            while ((Engine._device.startumost[x + Engine._device.windowx1] > Engine._device.startdmost[x + Engine._device.windowx1]) && (x <= x2)) x++;

            while (x <= x2) { transmaskvline(x); x++; }
            // faketimerhandler();
        }


        private void drawmaskwall(short damaskwallcnt)
        {
            int i, j, k, x, z, sectnum, z1, z2, lx, rx;
            sectortype sec, nsec;
            walltype wal;

            z = maskwall[damaskwallcnt];
            wal = wall[thewall[z]];
            sectnum = thesector[z]; sec = sector[sectnum];
            nsec = sector[wal.nextsector];
            z1 = Math.Max(nsec.ceilingz, sec.ceilingz);
            z2 = Math.Min(nsec.floorz, sec.floorz);

            wallmost(ref uwall, z, sectnum, (char)0);
            wallmost(ref uplc, z, (int)wal.nextsector, (char)0);
            for (x = xb1[z]; x <= xb2[z]; x++) if (uplc[x] > uwall[x]) uwall[x] = uplc[x];
            wallmost(ref dwall, z, sectnum, (char)1);
            wallmost(ref dplc, z, (int)wal.nextsector, (char)1);
            for (x = xb1[z]; x <= xb2[z]; x++) if (dplc[x] < dwall[x]) dwall[x] = dplc[x];
            prepwall(z, wal);

            globalorientation = (int)wal.cstat;
            globalpicnum = wal.overpicnum;
            if (globalpicnum >= MAXTILES) globalpicnum = 0;
            globalxpanning = (int)wal.xpanning;
            globalypanning = (int)wal.ypanning;
            if ((Engine.picanm[globalpicnum] & 192) != 0) globalpicnum += Engine.animateoffs((short)globalpicnum, (short)(thewall[z] + 16384));
            globalshade = (int)wal.shade;
            globvis = globalvisibility;
            if (sec.visibility != 0) globvis = pragmas.mulscale4(globvis, (int)((byte)(sec.visibility + 16)));
            globalpal = (int)wal.pal;
            globalshiftval = (Engine.picsiz[globalpicnum] >> 4);
            if (Engine.pow2long[globalshiftval] != Engine.tilesizy[globalpicnum]) globalshiftval++;
            globalshiftval = 32 - globalshiftval;
            globalyscale = (wal.yrepeat << (int)(globalshiftval - 19));
            if ((globalorientation & 4) == 0)
                globalzd = (((globalposz - z1) * globalyscale) << 8);
            else
                globalzd = (((globalposz - z2) * globalyscale) << 8);
            globalzd += (globalypanning << 24);
            if ((globalorientation & 256) != 0) { globalyscale = -globalyscale; globalzd = -globalzd; };

            for (i = smostwallcnt - 1; i >= 0; i--)
            {
                j = smostwall[i];
                if ((xb1[j] > xb2[z]) || (xb2[j] < xb1[z])) continue;
                if (wallfront(j, z) != 0) continue;

                lx = Math.Max(xb1[j], xb1[z]); rx = Math.Min(xb2[j], xb2[z]);

                switch (smostwalltype[i])
                {
                    case 0:
                        if (lx <= rx)
                        {
                            if ((lx == xb1[z]) && (rx == xb2[z])) return;
                            clearbufbyte(lx, ref dwall, (rx - lx + 1), 0);
                        }
                        break;
                    case 1:
                        k = smoststart[i] - xb1[j];
                        for (x = lx; x <= rx; x++)
                            if (smost[k + x] > uwall[x]) uwall[x] = smost[k + x];
                        break;
                    case 2:
                        k = smoststart[i] - xb1[j];
                        for (x = lx; x <= rx; x++)
                            if (smost[k + x] < dwall[x]) dwall[x] = smost[k + x];
                        break;
                }
            }

            //maskwall
            if ((Engine.searchit >= 1) && (Engine.searchx >= xb1[z]) && (Engine.searchx <= xb2[z]))
                if ((Engine.searchy >= uwall[Engine.searchx]) && (Engine.searchy <= dwall[Engine.searchx]))
                {
                    Engine.searchsector = sectnum; Engine.searchwall = thewall[z];
                    Engine.searchstat = 4; Engine.searchit = 1;
                }

            if ((globalorientation & 128) == 0)
                maskwallscan(xb1[z], xb2[z], ref uwall, ref dwall, ref swall, ref lwall);
            else
            {
                if ((globalorientation & 128) != 0)
                {
                    if ((globalorientation & 512) != 0) A.settransreverse(); else A.settransnormal();
                }
                transmaskwallscan(xb1[z], xb2[z]);
            }
        }
        //
        // drawalls (internal)
        //
        private int[] cz = new int[5];
        private int[] fz = new int[5];
        private void drawalls(int bunch)
        {
            sectortype sec;
            walltype wal;
            int i, x, x1, x2;
            int z, wallnum, sectnum, nextsectnum;
            int startsmostwallcnt, startsmostcnt, gotswall;
            byte andwstat1, andwstat2;

            z = bunchfirst[bunch];
            sectnum = thesector[z]; sec = sector[sectnum];

            andwstat1 = 0xff; andwstat2 = 0xff;
            for (; z >= 0; z = p2[z])  //uplc/dplc calculation
            {
                andwstat1 &= (byte)wallmost(ref uplc, z, sectnum, (char)0);
                andwstat2 &= (byte)wallmost(ref dplc, z, sectnum, (char)1);
            }

            if ((andwstat1 & 3) != 3)     //draw ceilings
            {
                if ((sec.ceilingstat & 3) == 2)
                    grouscan(xb1[bunchfirst[bunch]], xb2[bunchlast[bunch]], sectnum, (char)0x0);
                else if ((sec.ceilingstat & 1) == 0)
                    ceilscan(xb1[bunchfirst[bunch]], xb2[bunchlast[bunch]], sectnum);
                else
                    parascan(xb1[bunchfirst[bunch]], xb2[bunchlast[bunch]], sectnum, (char)0, bunch);
            }


            if ((andwstat2 & 12) != 12)   //draw floors
            {
                if ((sec.floorstat & 3) == 2)
                    grouscan(xb1[bunchfirst[bunch]], xb2[bunchlast[bunch]], sectnum, (char)1);
                else if ((sec.floorstat & 1) == 0)
                    florscan(xb1[bunchfirst[bunch]], xb2[bunchlast[bunch]], sectnum);
                else
                    parascan(xb1[bunchfirst[bunch]], xb2[bunchlast[bunch]], sectnum, (char)1, bunch);
            }


            //DRAW WALLS SECTION!
            for (z = bunchfirst[bunch]; z >= 0; z = p2[z])
            {
                x1 = xb1[z]; x2 = xb2[z];
                if (umost[x2] >= dmost[x2])
                {
                    for (x = x1; x < x2; x++)
                        if (umost[x] < dmost[x]) break;
                    if (x >= x2)
                    {
                        smostwall[smostwallcnt] = z;
                        smostwalltype[smostwallcnt] = 0;
                        smostwallcnt++;
                        continue;
                    }
                }


                wallnum = thewall[z]; wal = wall[wallnum];
                nextsectnum = wal.nextsector;



                gotswall = 0;

                startsmostwallcnt = smostwallcnt;
                startsmostcnt = smostcnt;

                if ((Engine.searchit == 2) && (Engine.searchx >= x1) && (Engine.searchx <= x2))
                {
                    if (Engine.searchy <= uplc[Engine.searchx]) //ceiling
                    {
                        Engine.searchsector = sectnum; Engine.searchwall = wallnum;
                        Engine.searchstat = 1; Engine.searchit = 1;
                    }
                    else if (Engine.searchy >= dplc[Engine.searchx]) //floor
                    {
                        Engine.searchsector = sectnum; Engine.searchwall = wallnum;
                        Engine.searchstat = 2; Engine.searchit = 1;
                    }
                }

                sectortype nextsec = null;
                if (nextsectnum >= 0)
                {

                    nextsec = sector[nextsectnum];
                    getzsofslope((short)sectnum, wal.x, wal.y, ref cz[0], ref fz[0]);
                    getzsofslope((short)sectnum, wall[wal.point2].x, wall[wal.point2].y, ref cz[1], ref fz[1]);
                    getzsofslope((short)nextsectnum, wal.x, wal.y, ref cz[2], ref fz[2]);
                    getzsofslope((short)nextsectnum, wall[wal.point2].x, wall[wal.point2].y, ref cz[3], ref fz[3]);
                    getzsofslope((short)nextsectnum, globalposx, globalposy, ref cz[4], ref fz[4]);

                    if ((wal.cstat & 48) == 16) maskwall[maskwallcnt++] = z;

                    if (((sec.ceilingstat & 1) == 0) || ((nextsec.ceilingstat & 1) == 0))
                    {
                        if ((cz[2] <= cz[0]) && (cz[3] <= cz[1]))
                        {
                            if (globparaceilclip)
                                for (x = x1; x <= x2; x++)
                                    if (uplc[x] > umost[x])
                                        if (umost[x] <= dmost[x])
                                        {
                                            umost[x] = uplc[x];
                                            if (umost[x] > dmost[x]) numhits--;
                                        }
                        }
                        else
                        {
                            wallmost(ref dwall, z, nextsectnum, (char)0);
                            if ((cz[2] > fz[0]) || (cz[3] > fz[1]))
                                for (i = x1; i <= x2; i++) if (dwall[i] > dplc[i]) dwall[i] = dplc[i];

                            if ((Engine.searchit == 2) && (Engine.searchx >= x1) && (Engine.searchx <= x2))
                                if (Engine.searchy <= dwall[Engine.searchx]) //wall
                                {
                                    Engine.searchsector = sectnum; Engine.searchwall = wallnum;
                                    Engine.searchstat = 0; Engine.searchit = 1;
                                }

                            globalorientation = (int)wal.cstat;
                            globalpicnum = wal.picnum;
                            if (globalpicnum >= MAXTILES) globalpicnum = 0;
                            globalxpanning = (int)wal.xpanning;
                            globalypanning = (int)wal.ypanning;
                            globalshiftval = (Engine.picsiz[globalpicnum] >> 4);
                            if (Engine.pow2long[globalshiftval] != Engine.tilesizy[globalpicnum]) globalshiftval++;
                            globalshiftval = 32 - globalshiftval;
                            if ((Engine.picanm[globalpicnum] & 192) != 0) globalpicnum += Engine.animateoffs((short)globalpicnum, (short)(wallnum + 16384));
                            globalshade = (int)wal.shade;
                            globvis = globalvisibility;
                            if (sec.visibility != 0) globvis = pragmas.mulscale4(globvis, (int)((byte)(sec.visibility + 16)));
                            globalpal = (int)wal.pal;
                            // jv
                            //if (Engine.palette.isLookupValid(globalpal) == false) globalpal = 0;	// JBF: fixes crash
                            // jv end
                            globalyscale = (wal.yrepeat << (globalshiftval - 19));
                            if ((globalorientation & 4) == 0)
                                globalzd = (((globalposz - nextsec.ceilingz) * globalyscale) << 8);
                            else
                                globalzd = (((globalposz - sec.ceilingz) * globalyscale) << 8);
                            globalzd += (globalypanning << 24);
                            if ((globalorientation & 256) != 0) { globalyscale = -globalyscale; globalzd = -globalzd; }

                            if (gotswall == 0) { gotswall = 1; prepwall(z, wal); }
                            wallscan(x1, x2, ref uplc, ref dwall, ref swall, ref lwall);

                            if ((cz[2] >= cz[0]) && (cz[3] >= cz[1]))
                            {
                                for (x = x1; x <= x2; x++)
                                    if (dwall[x] > umost[x])
                                        if (umost[x] <= dmost[x])
                                        {
                                            umost[x] = dwall[x];
                                            if (umost[x] > dmost[x]) numhits--;
                                        }
                            }
                            else
                            {
                                for (x = x1; x <= x2; x++)
                                    if (umost[x] <= dmost[x])
                                    {
                                        i = Math.Max(uplc[x], dwall[x]);
                                        if (i > umost[x])
                                        {
                                            umost[x] = (short)i;
                                            if (umost[x] > dmost[x]) numhits--;
                                        }
                                    }
                            }
                        }
                        if ((cz[2] < cz[0]) || (cz[3] < cz[1]) || (globalposz < cz[4]))
                        {
                            i = x2 - x1 + 1;
                            if (smostcnt + i < MAXYSAVES)
                            {
                                smoststart[smostwallcnt] = (short)smostcnt;
                                smostwall[smostwallcnt] = z;
                                smostwalltype[smostwallcnt] = 1;   //1 for umost
                                smostwallcnt++;
                                copybufbyte(x1, ref umost, smostcnt, ref smost, i);
                                smostcnt += i;
                            }
                        }
                    }
                    if (((sec.floorstat & 1) == 0) || ((nextsec.floorstat & 1) == 0))
                    {
                        if ((fz[2] >= fz[0]) && (fz[3] >= fz[1]))
                        {
                            if (globparaflorclip)
                                for (x = x1; x <= x2; x++)
                                    if (dplc[x] < dmost[x])
                                        if (umost[x] <= dmost[x])
                                        {
                                            dmost[x] = dplc[x];
                                            if (umost[x] > dmost[x]) numhits--;
                                        }
                        }
                        else
                        {
                            wallmost(ref uwall, z, nextsectnum, (char)1);
                            if ((fz[2] < cz[0]) || (fz[3] < cz[1]))
                                for (i = x1; i <= x2; i++) if (uwall[i] < uplc[i]) uwall[i] = uplc[i];

                            if ((Engine.searchit == 2) && (Engine.searchx >= x1) && (Engine.searchx <= x2))
                                if (Engine.searchy >= uwall[Engine.searchx]) //wall
                                {
                                    Engine.searchsector = sectnum; Engine.searchwall = wallnum;
                                    if ((wal.cstat & 2) > 0) Engine.searchwall = wal.nextwall;
                                    Engine.searchstat = 0; Engine.searchit = 1;
                                }

                            if ((wal.cstat & 2) > 0)
                            {
                                wallnum = wal.nextwall; wal = wall[wallnum];
                                globalorientation = (int)wal.cstat;
                                globalpicnum = wal.picnum;
                                if (globalpicnum >= MAXTILES) globalpicnum = 0;
                                globalxpanning = (int)wal.xpanning;
                                globalypanning = (int)wal.ypanning;
                                if ((Engine.picanm[globalpicnum] & 192) != 0) globalpicnum += Engine.animateoffs((short)globalpicnum, (short)(wallnum + 16384));
                                globalshade = (int)wal.shade;
                                globalpal = (int)wal.pal;
                                wallnum = thewall[z]; wal = wall[wallnum];
                            }
                            else
                            {
                                globalorientation = (int)wal.cstat;
                                globalpicnum = wal.picnum;
                                if (globalpicnum >= MAXTILES) globalpicnum = 0;
                                globalxpanning = (int)wal.xpanning;
                                globalypanning = (int)wal.ypanning;
                                if ((Engine.picanm[globalpicnum] & 192) != 0) globalpicnum += Engine.animateoffs((short)globalpicnum, (short)(wallnum + 16384));
                                globalshade = (int)wal.shade;
                                globalpal = (int)wal.pal;
                            }
                            // jv
                            //if (Engine.palette.isLookupValid(globalpal) == false) globalpal = 0;	// JBF: fixes crash
                            // jv end
                            globvis = globalvisibility;
                            if (sec.visibility != 0) globvis = pragmas.mulscale4(globvis, (int)((byte)(sec.visibility + 16)));
                            globalshiftval = (Engine.picsiz[globalpicnum] >> 4);
                            if (Engine.pow2long[globalshiftval] != Engine.tilesizy[globalpicnum]) globalshiftval++;
                            globalshiftval = 32 - globalshiftval;
                            globalyscale = (wal.yrepeat << (globalshiftval - 19));
                            if ((globalorientation & 4) == 0)
                                globalzd = (((globalposz - nextsec.floorz) * globalyscale) << 8);
                            else
                                globalzd = (((globalposz - sec.ceilingz) * globalyscale) << 8);
                            globalzd += (globalypanning << 24);
                            if ((globalorientation & 256) != 0) { globalyscale = -globalyscale; globalzd = -globalzd; }

                            if (gotswall == 0) { gotswall = 1; prepwall(z, wal); }
                            wallscan(x1, x2, ref uwall, ref dplc, ref swall, ref lwall);

                            if ((fz[2] <= fz[0]) && (fz[3] <= fz[1]))
                            {
                                for (x = x1; x <= x2; x++)
                                    if (uwall[x] < dmost[x])
                                        if (umost[x] <= dmost[x])
                                        {
                                            dmost[x] = uwall[x];
                                            if (umost[x] > dmost[x]) numhits--;
                                        }
                            }
                            else
                            {
                                for (x = x1; x <= x2; x++)
                                    if (umost[x] <= dmost[x])
                                    {
                                        i = Math.Min(dplc[x], uwall[x]);
                                        if (i < dmost[x])
                                        {
                                            dmost[x] = (short)i;
                                            if (umost[x] > dmost[x]) numhits--;
                                        }
                                    }
                            }
                        }
                        if ((fz[2] > fz[0]) || (fz[3] > fz[1]) || (globalposz > fz[4]))
                        {
                            i = x2 - x1 + 1;
                            if (smostcnt + i < MAXYSAVES)
                            {
                                smoststart[smostwallcnt] = (short)smostcnt;
                                smostwall[smostwallcnt] = z;
                                smostwalltype[smostwallcnt] = 2;   //2 for dmost
                                smostwallcnt++;
                                copybufbyte(x1, ref dmost, smostcnt, ref smost, i);
                                smostcnt += i;
                            }
                        }
                    }
                    if (numhits < 0) return;
                    if (((wal.cstat & 32) == 0) && ((gotsector[nextsectnum >> 3] & Engine.pow2char[nextsectnum & 7]) == 0))
                    {
                        if (umost[x2] < dmost[x2])
                            scansector((short)nextsectnum);
                        else
                        {
                            for (x = x1; x < x2; x++)
                                if (umost[x] < dmost[x])
                                { scansector((short)nextsectnum); break; }

                            //If can't see sector beyond, then cancel smost array and just
                            //store wall!
                            if (x == x2)
                            {
                                smostwallcnt = startsmostwallcnt;
                                smostcnt = startsmostcnt;
                                smostwall[smostwallcnt] = z;
                                smostwalltype[smostwallcnt] = 0;
                                smostwallcnt++;
                            }
                        }
                    }
                }
                if ((nextsectnum < 0) || (wal.cstat & 32) != 0)   //White/1-way wall
                {
                    globalorientation = (int)wal.cstat;
                    if (nextsectnum < 0) globalpicnum = wal.picnum;
                    else globalpicnum = wal.overpicnum;
                    if (globalpicnum >= MAXTILES) globalpicnum = 0;
                    globalxpanning = (int)wal.xpanning;
                    globalypanning = (int)wal.ypanning;
                    if ((Engine.picanm[globalpicnum] & 192) != 0) globalpicnum += Engine.animateoffs((short)globalpicnum, (short)(wallnum + 16384));
                    globalshade = (int)wal.shade;
                    globvis = globalvisibility;
                    if (sec.visibility != 0) globvis = pragmas.mulscale4(globvis, (int)((byte)(sec.visibility + 16)));
                    globalpal = (int)wal.pal;
                    // jv
                    //if (Engine.palette.isLookupValid(globalpal) == false) globalpal = 0;	// JBF: fixes crash
                    // jv end
                    globalshiftval = (Engine.picsiz[globalpicnum] >> 4);
                    if (Engine.pow2long[globalshiftval] != Engine.tilesizy[globalpicnum]) globalshiftval++;
                    globalshiftval = 32 - globalshiftval;
                    globalyscale = (wal.yrepeat << (int)(globalshiftval - 19));
                    if (nextsectnum >= 0)
                    {
                        if ((globalorientation & 4) == 0) globalzd = globalposz - nextsec.ceilingz;
                        else globalzd = globalposz - sec.ceilingz;
                    }
                    else
                    {
                        if ((globalorientation & 4) == 0) globalzd = globalposz - sec.ceilingz;
                        else globalzd = globalposz - sec.floorz;
                    }
                    globalzd = ((globalzd * globalyscale) << 8) + (globalypanning << 24);
                    if ((globalorientation & 256) != 0) { globalyscale = -globalyscale; globalzd = -globalzd; }

                    if (gotswall == 0) { gotswall = 1; prepwall(z, wal); }
                    wallscan(x1, x2, ref uplc, ref dplc, ref swall, ref lwall);

                    for (x = x1; x <= x2; x++)
                        if (umost[x] <= dmost[x])
                        { umost[x] = 1; dmost[x] = 0; numhits--; }
                    smostwall[smostwallcnt] = z;
                    smostwalltype[smostwallcnt] = 0;
                    smostwallcnt++;

                    if ((Engine.searchit == 2) && (Engine.searchx >= x1) && (Engine.searchx <= x2))
                    {
                        Engine.searchit = 1; Engine.searchsector = sectnum; Engine.searchwall = wallnum;
                        if (nextsectnum < 0) Engine.searchstat = 0; else Engine.searchstat = 4;
                    }
                }
            }
        }

        //
        // wallfront (internal)
        //
        private int wallfront(int l1, int l2)
        {
            walltype wal;
            int x11, y11, x21, y21, x12, y12, x22, y22, dx, dy, t1, t2;

            wal = wall[thewall[l1]]; x11 = wal.x; y11 = wal.y;
            wal = wall[wal.point2]; x21 = wal.x; y21 = wal.y;
            wal = wall[thewall[l2]]; x12 = wal.x; y12 = wal.y;
            wal = wall[wal.point2]; x22 = wal.x; y22 = wal.y;

            dx = x21 - x11; dy = y21 - y11;
            t1 = pragmas.dmulscale2(x12 - x11, dy, -dx, y12 - y11); //p1(l2) vs. l1
            t2 = pragmas.dmulscale2(x22 - x11, dy, -dx, y22 - y11); //p2(l2) vs. l1
            if (t1 == 0) { t1 = t2; if (t1 == 0) return (-1); }
            if (t2 == 0) t2 = t1;
            if ((t1 ^ t2) >= 0)
            {
                t2 = pragmas.dmulscale2(globalposx - x11, dy, -dx, globalposy - y11); //pos vs. l1

                if ((t2 ^ t1) >= 0)
                {
                    return 1;
                }
                return 0;
            }

            dx = x22 - x12; dy = y22 - y12;
            t1 = pragmas.dmulscale2(x11 - x12, dy, -dx, y11 - y12); //p1(l1) vs. l2
            t2 = pragmas.dmulscale2(x21 - x12, dy, -dx, y21 - y12); //p2(l1) vs. l2
            if (t1 == 0) { t1 = t2; if (t1 == 0) return (-1); }
            if (t2 == 0) t2 = t1;
            if ((t1 ^ t2) >= 0)
            {
                t2 = pragmas.dmulscale2(globalposx - x12, dy, -dx, globalposy - y12); //pos vs. l2
                if ((t2 ^ t1) < 0)
                {
                    return 1;
                }

                return 0;
            }
            return (-2);
        }

        private int bunchfront(int b1, int b2)
        {
            int x1b1, x2b1, x1b2, x2b2, b1f, b2f, i;

            b1f = bunchfirst[b1]; x1b1 = xb1[b1f]; x2b2 = xb2[bunchlast[b2]] + 1;
            if (x1b1 >= x2b2) return (-1);
            b2f = bunchfirst[b2]; x1b2 = xb1[b2f]; x2b1 = xb2[bunchlast[b1]] + 1;
            if (x1b2 >= x2b1) return (-1);

            if (x1b1 >= x1b2)
            {
                for (i = b2f; xb2[i] < x1b1; i = p2[i]) ;
                return (wallfront(b1f, i));
            }
            for (i = b1f; xb2[i] < x1b2; i = p2[i]) ;
            return (wallfront(i, b2f));
        }

        //
        // preparemirror
        //
        public void preparemirror(int dax, int day, int daz, short daang, int dahoriz, short dawall, short dasector, ref int tposx, ref int tposy, ref short tang)
        {
            int i, j, x, y, dx, dy;

            x = wall[dawall].x; dx = wall[wall[dawall].point2].x - x;
            y = wall[dawall].y; dy = wall[wall[dawall].point2].y - y;
            j = dx * dx + dy * dy; if (j == 0) return;
            i = (((dax - x) * dx + (day - y) * dy) << 1);
            tposx = (x << 1) + pragmas.scale(dx, i, j) - dax;
            tposy = (y << 1) + pragmas.scale(dy, i, j) - day;
            tang = (short)(((Engine.getangle(dx, dy) << 1) - daang) & 2047);

            inpreparemirror = true;
            inrendermirror = true;
        }


        //
        // completemirror
        //
        public void completemirror()
        {
            int i, dy, p;

            inrendermirror = false;

            //Can't reverse with uninitialized data
            if (inpreparemirror) { inpreparemirror = false; return; }
            if (mirrorsx1 > 0) mirrorsx1--;
            if (mirrorsx2 < Engine._device.windowx2 - Engine._device.windowx1 - 1) mirrorsx2++;
            if (mirrorsx2 < mirrorsx1) return; 

            //     Engine._device.BeginDrawing();
            p = Engine.frameplace + Engine.ylookup[Engine._device.windowy1 + mirrorsy1] + Engine._device.windowx1 + mirrorsx1;
            i = Engine._device.windowx2 - Engine._device.windowx1 - mirrorsx2 - mirrorsx1; mirrorsx2 -= mirrorsx1;
            for (dy = mirrorsy2 - mirrorsy1; dy >= 0; dy--)
            {
                // jv
                //	        copybufbyte((void*)(p+1),tempbuf,mirrorsx2+1);
                Array.Copy(Engine._device._screenbuffer.Pixels, p + 1, tempbufint, 0, mirrorsx2 + 1);
                // jv end
                tempbufint[mirrorsx2] = tempbufint[mirrorsx2 - 1];
                Engine.copybufreverse<int>(mirrorsx2, tempbufint, p + i, Engine._device._screenbuffer.Pixels, mirrorsx2 + 1);
                p += Engine.ylookup[1];
                // faketimerhandler();
            }
            //     Engine._device.EndDrawing();
        }

        //
        // drawrooms
        //
        public void drawrooms(int daposx, int daposy, int daposz, short daang, int dahoriz, short dacursectnum)
        {
            int i, j, z, cz = 0, fz = 0, closest;
            int shortptr1, shortptr2;

            Engine.beforedrawrooms = false;
            Engine.BeginDrawing();  //{{{

            globalposx = daposx; globalposy = daposy; globalposz = daposz;
            globalang = (short)(daang & 2047);

            globalhoriz = pragmas.mulscale16(dahoriz - 100, Engine._device.xdimenscale) + (Engine._device.ydimen >> 1);
            globaluclip = (0 - globalhoriz) * Engine._device.xdimscale;
            globaldclip = (Engine._device.ydimen - globalhoriz) * Engine._device.xdimscale;

            i = pragmas.mulscale16(Engine._device.xdimenscale, Engine._device.viewingrangerecip);
            globalpisibility = pragmas.mulscale16(parallaxvisibility, i);
            globalvisibility = pragmas.mulscale16(visibility, i);
            globalhisibility = pragmas.mulscale16(globalvisibility, Engine._device.xyaspect);
            globalcisibility = pragmas.mulscale8(globalhisibility, 320);

            globalcursectnum = dacursectnum;
            //totalclocklock = totalclock;

            cosglobalang = Engine.table.sintable[(globalang + 512) & 2047];
            singlobalang = Engine.table.sintable[globalang & 2047];
            cosviewingrangeglobalang = pragmas.mulscale16(cosglobalang, Engine._device.viewingrange);
            sinviewingrangeglobalang = pragmas.mulscale16(singlobalang, Engine._device.viewingrange);

            if ((Engine._device.xyaspect != Engine.oxyaspect) || (Engine._device.xdimen != Engine.oxdimen) || (Engine._device.viewingrange != Engine.oviewingrange))
                dosetaspect(false);

            //clearbufbyte(&gotsector[0],(int)((numsectors+7)>>3),0L);
            //gotsector.memset( 0 );
            Array.Clear(gotsector, 0, gotsector.Length);

            shortptr1 = Engine._device.windowx1;
            shortptr2 = Engine._device.windowx1;
            i = Engine._device.xdimen - 1;
            do
            {
                umost[i] = (short)(Engine._device.startumost[shortptr1 + i] - Engine._device.windowy1);
                dmost[i] = (short)(Engine._device.startdmost[shortptr2 + i] - Engine._device.windowy1);
                i--;
            } while (i != 0);
            umost[0] = (short)(Engine._device.startumost[shortptr1 + 0] - Engine._device.windowy1);
            dmost[0] = (short)(Engine._device.startdmost[shortptr2 + 0] - Engine._device.windowy1);



            //frameoffset = frameplace + viewoffset;
            frameoffset = Engine.frameplace + (Engine._device.windowy1 * Engine._device.bytesperline + Engine._device.windowx1);

            //if (smostwallcnt < 0)
            //	if (getkensmessagecrc(FP_OFF(kensmessage)) != 0x56c764d4)
            //		{ /* setvmode(0x3);*/ printOSD("Nice try.\n"); exit(0); }



            numhits = Engine._device.xdimen; numscans = 0; numbunches = 0;
            maskwallcnt = 0; smostwallcnt = 0; smostcnt = 0; spritesortcnt = 0;

            if (globalcursectnum >= MAXSECTORS)
                globalcursectnum -= MAXSECTORS;
            else
            {
                i = globalcursectnum;
                updatesector(globalposx, globalposy, ref globalcursectnum);
                if (globalcursectnum < 0) globalcursectnum = (short)i;
            }

            globparaceilclip = true;
            globparaflorclip = true;
            getzsofslope(globalcursectnum, globalposx, globalposy, ref cz, ref fz);
            if (globalposz < cz) globparaceilclip = false;
            if (globalposz > fz) globparaflorclip = false;

            scansector(globalcursectnum);



            if (inpreparemirror)
            {
                inpreparemirror = false;
                mirrorsx1 = Engine._device.xdimen - 1; mirrorsx2 = 0;
                for (i = numscans - 1; i >= 0; i--)
                {
                    if (wall[thewall[i]].nextsector < 0) continue;
                    if (xb1[i] < mirrorsx1) mirrorsx1 = xb1[i];
                    if (xb2[i] > mirrorsx2) mirrorsx2 = xb2[i];
                }

                for (i = 0; i < mirrorsx1; i++)
                    if (umost[i] <= dmost[i])
                    { umost[i] = 1; dmost[i] = 0; numhits--; }
                for (i = mirrorsx2 + 1; i < Engine._device.xdimen; i++)
                    if (umost[i] <= dmost[i])
                    { umost[i] = 1; dmost[i] = 0; numhits--; }

                drawalls(0);
                numbunches--;
                bunchfirst[0] = bunchfirst[numbunches];
                bunchlast[0] = bunchlast[numbunches];

                mirrorsy1 = Math.Min(umost[mirrorsx1], umost[mirrorsx2]);
                mirrorsy2 = Math.Max(dmost[mirrorsx1], dmost[mirrorsx2]);
            }

            while ((numbunches > 0) && (numhits > 0))
            {
                // jv
                //  Array.Clear(tempbuf, 0, (int)((numbunches + 3) >> 2));
                // clearbuf(0, ref tempbuf,(int)((numbunches+3)>>2),0L);
                // jv end
                tempbuf[0] = 1;

                closest = 0;              //Almost works, but not quite :(
                for (i = 1; i < numbunches; i++)
                {
                    if ((j = bunchfront(i, closest)) < 0)
                    {
                        tempbuf[i] = 0;
                        continue;
                    }
                    tempbuf[i] = 1;
                    if (j == 0)
                    {
                        tempbuf[closest] = 1;
                        closest = i;
                    }
                }

                for (i = 0; i < numbunches; i++) //Double-check
                {
                    if (tempbuf[i] != 0) continue;
                    if ((j = bunchfront(i, closest)) < 0) continue;
                    tempbuf[i] = 1;
                    if (j == 0) { tempbuf[closest] = 1; closest = i; i = 0; };
                }

                drawalls(closest);

                // if (automapping)
                // {
                //     for(z=bunchfirst[closest];z>=0;z=p2[z])
                //        show2dwall[thewall[z]>>3] |= pow2char[thewall[z]&7];
                // }

                numbunches--;
                bunchfirst[closest] = bunchfirst[numbunches];
                bunchlast[closest] = bunchlast[numbunches];
            }

            Engine.EndDrawing();
        }

        public void saveboard(System.IO.BinaryWriter fil, int daposx, int daposy, int daposz, short daang, short dacursectnum)
        {
            short i, j, numsprites;


            fil.Write(mapversion);

            fil.Write(daposx);
            fil.Write(daposy);
            fil.Write(daposz);
            fil.Write(daang);
            fil.Write(dacursectnum);

            fil.Write((short)numsectors);
            for (i = 0; i < numsectors; i++)
            {
                sector[i].Write(ref fil);
            }


            fil.Write((short)numwalls);
            for (i = 0; i < numwalls; i++)
            {
                wall[i].Write(ref fil);
            }

            numsprites = 0;
            for (j = 0; j < MAXSTATUS; j++)
            {
                i = (short)headspritestat[j];
                while (i != -1)
                {
                    numsprites++;
                    i = (short)nextspritestat[i];
                }
            }
            //write(fil,&numsprites,2);
            fil.Write((short)numsprites);

            for (j = 0; j < MAXSTATUS; j++)
            {
                i = (short)headspritestat[j];
                while (i != -1)
                {
                    sprite[i].Write(ref fil);
                    //write(fil,&sprite[i],sizeof(spritetype));
                    i = (short)nextspritestat[i];
                }
            }

            //  fil.Dispose();

        }

        public int loadboard(kFile fil, ref int daposx, ref int daposy, ref int daposz, ref short daang, ref short dacursectnum)
        {
            short numsprites;

            dosetaspect(true);

            fil.kreadint(out mapversion);

            Engine.Printf("...Using mapversion " + mapversion);

            initspritelists();

            daposx = fil.kreadint();
            daposy = fil.kreadint();
            daposz = fil.kreadint();
            daang = fil.kreadshort();
            dacursectnum = fil.kreadshort();

            // read in the map sectors
            numsectors = fil.kreadshort();
            for (int i = 0; i < numsectors; i++)
            {
                sector[i] = new sectortype(ref fil);
            }
            sector[MAXSECTORS] = new sectortype();

            // read in the wall sectors
            numwalls = fil.kreadshort();
            for (int i = 0; i < numwalls; i++)
            {
                wall[i] = new walltype(ref fil);
            }

            // read in the sprite sectors
            numsprites = fil.kreadshort();
            for (int i = 0; i < numsprites; i++)
            {
                sprite[i].Read(ref fil);
                // sprite[i].sectnum = MAXSECTORS;
                // sprite[i].statnum = MAXSTATUS;
            }

            for (int i = 0; i < numsprites; i++)
                insertsprite(sprite[i].sectnum, sprite[i].statnum);

            //Must be after loading sectors, etc!
            updatesector(daposx, daposy, ref dacursectnum);

            fil.Close();

            Engine.initPolymerMainThread = true;

            while(Engine.initPolymerMainThread)
            {
                System.Threading.Thread.Sleep(1);
            }

            return (0);
        }
    }
    struct linetype
    {
        public int x1, y1, x2, y2;
    };
    #region mapformat  
    //ceilingstat/floorstat:
    //   bit 0: 1 = parallaxing, 0 = not                                 "P"
    //   bit 1: 1 = groudraw, 0 = not
    //   bit 2: 1 = swap x&y, 0 = not                                    "F"
    //   bit 3: 1 = double smooshiness                                   "E"
    //   bit 4: 1 = x-flip                                               "F"
    //   bit 5: 1 = y-flip                                               "F"
    //   bit 6: 1 = Align texture to first wall of sector                "R"
    //   bits 7-8:                                                       "T"
    //          00 = normal floors
    //          01 = masked floors
    //          10 = transluscent masked floors
    //          11 = reverse transluscent masked floors
    //   bits 9-15: reserved

    //40 bytes
    public class sectortype
    {
        public short wallptr, wallnum;
        public int _ceilingz, _floorz;
        public short ceilingstat, floorstat;
        public short ceilingpicnum, ceilingheinum;
        public sbyte ceilingshade;
        public byte ceilingpal, ceilingxpanning, ceilingypanning;
        public short floorpicnum, floorheinum;
        public sbyte floorshade;
        public byte floorpal, floorxpanning, floorypanning;
        public byte visibility, filler;
        public short lotag, hitag, extra;
        public bool changed;
        public bool neighborChanged;
        public int ceilingz
        {
            get
            {
                return _ceilingz;
            }
            set
            {
                if(_ceilingz != value)
                    changed = true;

                _ceilingz = value;
                
            }
        }

        public int floorz
        {
            get
            {
                return _floorz;
            }
            set
            {
                if (_floorz != value)
                    changed = true;
                _floorz = value;
            }
        }

        public sectortype()
        {

        }

        public bool IsCeilParalaxed() { return (ceilingstat & 1) != 0; }
        public bool IsFloorParalaxed() { return (floorstat & 1) != 0; }

        public void copyto(ref sectortype sector)
        {
            if (sector == null)
                sector = new sectortype();

            sector.wallptr = wallptr;
            sector.wallnum = wallnum;

            sector.ceilingz = ceilingz;
            sector.floorz = floorz;

            sector.ceilingstat = ceilingstat;
            sector.floorstat = floorstat;

            sector.ceilingpicnum = ceilingpicnum;
            sector.ceilingheinum = ceilingheinum;

            sector.ceilingshade = ceilingshade;

            sector.ceilingpal = ceilingpal;
            sector.ceilingxpanning = ceilingxpanning;
            sector.ceilingypanning = ceilingypanning;

            sector.floorpicnum = floorpicnum;
            sector.floorheinum = floorheinum;

            sector.floorshade = floorshade;

            sector.floorpal = floorpal;
            sector.floorxpanning = floorxpanning;
            sector.floorypanning = floorypanning;

            sector.visibility = visibility;
            sector.filler = filler;

            sector.lotag = lotag;
            sector.hitag = hitag;
            sector.extra = extra;
        }

        public void Write(ref System.IO.BinaryWriter writer)
        {
            writer.Write(wallptr);
            writer.Write(wallnum);

            writer.Write(ceilingz);
            writer.Write(floorz);

            writer.Write(ceilingstat);
            writer.Write(floorstat);

            writer.Write(ceilingpicnum);
            writer.Write(ceilingheinum);

            writer.Write(ceilingshade);

            writer.Write(ceilingpal);
            writer.Write(ceilingxpanning);
            writer.Write(ceilingypanning);

            writer.Write(floorpicnum);
            writer.Write(floorheinum);

            writer.Write(floorshade);

            writer.Write(floorpal);
            writer.Write(floorxpanning);
            writer.Write(floorypanning);

            writer.Write(visibility);
            writer.Write(filler);

            writer.Write(lotag);
            writer.Write(hitag);
            writer.Write(extra);
        }

        public sectortype(ref kFile file)
        {
            wallptr = file.kreadshort();
            wallnum = file.kreadshort();

            ceilingz = file.kreadint();
            floorz = file.kreadint();

            ceilingstat = file.kreadshort();
            floorstat = file.kreadshort();

            ceilingpicnum = file.kreadshort();
            ceilingheinum = file.kreadshort();

            ceilingshade = file.kreadsbyte();

            ceilingpal = file.kreadbyte();
            ceilingxpanning = file.kreadbyte();
            ceilingypanning = file.kreadbyte();

            floorpicnum = file.kreadshort();
            floorheinum = file.kreadshort();

            floorshade = file.kreadsbyte();

            floorpal = file.kreadbyte();
            floorxpanning = file.kreadbyte();
            floorypanning = file.kreadbyte();

            visibility = file.kreadbyte();
            filler = file.kreadbyte();

            lotag = file.kreadshort();
            hitag = file.kreadshort();
            extra = file.kreadshort();
        }
    };

    //cstat:
    //   bit 0: 1 = Blocking wall (use with clipmove, getzrange)         "B"
    //   bit 1: 1 = bottoms of invisible walls swapped, 0 = not          "2"
    //   bit 2: 1 = align picture on bottom (for doors), 0 = top         "O"
    //   bit 3: 1 = x-flipped, 0 = normal                                "F"
    //   bit 4: 1 = masking wall, 0 = not                                "M"
    //   bit 5: 1 = 1-way wall, 0 = not                                  "1"
    //   bit 6: 1 = Blocking wall (use with hitscan / cliptype 1)        "H"
    //   bit 7: 1 = Transluscence, 0 = not                               "T"
    //   bit 8: 1 = y-flipped, 0 = normal                                "F"
    //   bit 9: 1 = Transluscence reversing, 0 = normal                  "T"
    //   bits 10-15: reserved

    //32 bytes
    public class walltype
    {
        public int _x, _y;
        public short point2, nextwall, nextsector, cstat;
        public short picnum, overpicnum;
        public sbyte shade;
        public byte pal, xrepeat, yrepeat, xpanning, ypanning;
        public short lotag, hitag, extra;
        public bool changed;
        public walltype()
        {
            changed = false;
        }

        public int x
        {
            get
            {
                return _x;
            }
            set
            {
                if (_x != value)
                    changed = true;
                _x = value;                
            }
        }

        public int y
        {
            get
            {
                return _y;
            }
            set
            {
                if (_y != value)
                    changed = true;

                _y = value;
            }
        }

        public void copyto(ref walltype wall)
        {
            if (wall == null)
                wall = new walltype();

            wall.x = x;
            wall.y = y;

            wall.point2 = point2;
            wall.nextwall = nextwall;
            wall.nextsector = nextsector;
            wall.cstat = cstat;

            wall.picnum = picnum;
            wall.overpicnum = overpicnum;

            wall.shade = shade;

            wall.pal = pal;
            wall.xrepeat = xrepeat;
            wall.yrepeat = yrepeat;
            wall.xpanning = xpanning;
            wall.ypanning = ypanning;

            wall.lotag = lotag;
            wall.hitag = hitag;
            wall.extra = extra;
        }

        public void Write(ref System.IO.BinaryWriter writer)
        {
            writer.Write(x);
            writer.Write(y);

            writer.Write(point2);
            writer.Write(nextwall);
            writer.Write(nextsector);
            writer.Write(cstat);

            writer.Write(picnum);
            writer.Write(overpicnum);

            writer.Write(shade);

            writer.Write(pal);
            writer.Write(xrepeat);
            writer.Write(yrepeat);
            writer.Write(xpanning);
            writer.Write(ypanning);

            writer.Write(lotag);
            writer.Write(hitag);
            writer.Write(extra);
        }

        public walltype(ref kFile file)
        {
            x = file.kreadint();
            y = file.kreadint();

            point2 = file.kreadshort();
            nextwall = file.kreadshort();
            nextsector = file.kreadshort();
            cstat = file.kreadshort();

            picnum = file.kreadshort();
            overpicnum = file.kreadshort();

            shade = file.kreadsbyte();

            pal = file.kreadbyte();
            xrepeat = file.kreadbyte();
            yrepeat = file.kreadbyte();
            xpanning = file.kreadbyte();
            ypanning = file.kreadbyte();

            lotag = file.kreadshort();
            hitag = file.kreadshort();
            extra = file.kreadshort();
        }
    };

    //cstat:
    //   bit 0: 1 = Blocking sprite (use with clipmove, getzrange)       "B"
    //   bit 1: 1 = transluscence, 0 = normal                            "T"
    //   bit 2: 1 = x-flipped, 0 = normal                                "F"
    //   bit 3: 1 = y-flipped, 0 = normal                                "F"
    //   bits 5-4: 00 = FACE sprite (default)                            "R"
    //             01 = WALL sprite (like masked walls)
    //             10 = FLOOR sprite (parallel to ceilings&floors)
    //   bit 6: 1 = 1-sided sprite, 0 = normal                           "1"
    //   bit 7: 1 = Real centered centering, 0 = foot center             "C"
    //   bit 8: 1 = Blocking sprite (use with hitscan / cliptype 1)      "H"
    //   bit 9: 1 = Transluscence reversing, 0 = normal                  "T"
    //   bits 10-14: reserved
    //   bit 15: 1 = Invisible sprite, 0 = not invisible

    //44 bytes
    public class spritetype
    {
        public int x, y, z;
        public short cstat, picnum;
        public sbyte shade;
        public byte pal, clipdist, filler;
        public byte xrepeat, yrepeat;
        public sbyte xoffset, yoffset;
        public short sectnum, statnum;
        public short ang, owner, xvel, yvel, zvel;
        public short lotag, hitag, extra;

        // jv
        public object obj;
        // jv end

        public spritetype()
        {

        }

        public void Copy(spritetype t)
        {
            x = t.x;
            y = t.y;
            z = t.z;
            cstat = t.cstat;
            picnum = t.picnum;
            shade = t.shade;
            pal = t.pal;
            clipdist = t.clipdist;
            filler = t.filler;
            xrepeat = t.xrepeat;
            yrepeat = t.yrepeat;
            xoffset = t.xoffset;
            yoffset = t.yoffset;
            sectnum = t.sectnum;
            statnum = t.statnum;
            ang = t.ang;
            owner = t.owner;
            xvel = t.xvel;
            yvel = t.yvel;
            zvel = t.zvel;
            lotag = t.lotag;
            hitag = t.hitag;
            extra = t.extra;
        }

        public void Write(ref System.IO.BinaryWriter writer)
        {
            writer.Write(x);
            writer.Write(y);
            writer.Write(z);

            writer.Write(cstat);
            writer.Write(picnum);
            writer.Write(shade);
            writer.Write(pal);
            writer.Write(clipdist);
            writer.Write(filler);
            writer.Write(xrepeat);
            writer.Write(yrepeat);
            writer.Write(xoffset);
            writer.Write(yoffset);
            writer.Write(sectnum);
            writer.Write(statnum);
            writer.Write(ang);
            writer.Write(owner);
            writer.Write(xvel);
            writer.Write(yvel);
            writer.Write(zvel);
            writer.Write(lotag);
            writer.Write(hitag);
            writer.Write(extra);
        }

        public void Read(ref kFile file)
        {
            x = file.kreadint();
            y = file.kreadint();
            z = file.kreadint();

            cstat = file.kreadshort();
            picnum = file.kreadshort();
            shade = file.kreadsbyte();
            pal = file.kreadbyte();
            clipdist = file.kreadbyte();
            filler = file.kreadbyte();
            xrepeat = file.kreadbyte();
            yrepeat = file.kreadbyte();
            xoffset = file.kreadsbyte();
            yoffset = file.kreadsbyte();
            sectnum = file.kreadshort();
            statnum = file.kreadshort();
            ang = file.kreadshort();
            owner = file.kreadshort();
            xvel = file.kreadshort();
            yvel = file.kreadshort();
            zvel = file.kreadshort();
            lotag = file.kreadshort();
            hitag = file.kreadshort();
            extra = file.kreadshort();
        }
    };

    public struct spritetype2
    {
        public int x, y, z;
        public short cstat, picnum;
        public sbyte shade;
        public byte pal, clipdist, filler;
        public byte xrepeat, yrepeat;
        public sbyte xoffset, yoffset;
        public short sectnum, statnum;
        public short ang, owner, xvel, yvel, zvel;
        public short lotag, hitag, extra;

        // jv
        public object obj;
        // jv end

        public void Copy(spritetype t)
        {
            x = t.x;
            y = t.y;
            z = t.z;
            cstat = t.cstat;
            picnum = t.picnum;
            shade = t.shade;
            pal = t.pal;
            clipdist = t.clipdist;
            filler = t.filler;
            xrepeat = t.xrepeat;
            yrepeat = t.yrepeat;
            xoffset = t.xoffset;
            yoffset = t.yoffset;
            sectnum = t.sectnum;
            statnum = t.statnum;
            ang = t.ang;
            owner = t.owner;
            xvel = t.xvel;
            yvel = t.yvel;
            zvel = t.zvel;
            lotag = t.lotag;
            hitag = t.hitag;
            extra = t.extra;
        }

        public void Copy(spritetype2 t)
        {
            x = t.x;
            y = t.y;
            z = t.z;
            cstat = t.cstat;
            picnum = t.picnum;
            shade = t.shade;
            pal = t.pal;
            clipdist = t.clipdist;
            filler = t.filler;
            xrepeat = t.xrepeat;
            yrepeat = t.yrepeat;
            xoffset = t.xoffset;
            yoffset = t.yoffset;
            sectnum = t.sectnum;
            statnum = t.statnum;
            ang = t.ang;
            owner = t.owner;
            xvel = t.xvel;
            yvel = t.yvel;
            zvel = t.zvel;
            lotag = t.lotag;
            hitag = t.hitag;
            extra = t.extra;
        }
    };
    #endregion
}
