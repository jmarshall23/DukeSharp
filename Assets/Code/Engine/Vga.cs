using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices;

using Unity;
using UnityEngine;

namespace Build
{
    public class VGATexture2D
    {
        public Texture2D _texture;
        public int[] Pixels;

        private int _width;

        private int _height;

        public VGATexture2D(int width, int height)
        {
            _texture = new Texture2D(width, height, TextureFormat.BGRA32, false);
            Pixels = new int[width * height];

            _width = width;
            _height = height;
        }

        public void Present()
        {
            GCHandle handle = GCHandle.Alloc(Pixels, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                _texture.LoadRawTextureData(pointer, _width * _height * 4);
                _texture.Apply();
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }
        }
    }

    //
    // VgaDevice
    //
    public class VgaDevice
    {
        public int xdim;
        public int ydim;
        public VGATexture2D _screenbuffer;
       // public int[] _tempscreenbuffer;
        //private Rectangle _screenrect;
#if BUILD_INTEROPSERVICES
        private object _screenbufferptr;
#endif
        public bPalette _palette;
        bPalette _paletteold;
        Thread renderthread;
        int numblits = 0;

        public const int MAXXDIM = 1600;
        public const int MAXYDIM = 1200;
        public int halfxdim16, midydim16;
        public int viewingrange, viewingrangerecip, yxaspect, xyaspect, xdimenscale, xdimscale;
        public int xdimen, ydimen;
        public short[] startumost = new short[MAXXDIM];
        public short[] startdmost = new short[MAXXDIM];
        public int bytesperline;
        public int imageSize;

        private bool haswork = false;

        public int xres
        {
            get
            {
                return xdim;
            }
        }

        public int yres
        {
            get
            {
                return ydim;
            }
        }

        //
        // BackendRenderThreadWorker
        //
        private void BackendRenderThreadWorker()
        {
            while (true)
            {
                if (haswork)
                {

                    haswork = false;
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
        }

        //
        // Init
        //
        public void Init(int width, int height)
        {
            xdim = width;
            ydim = height;

            _screenbuffer = new VGATexture2D(width, height);

            //_screenbufferptr = GCServices.Alloc(_screenbuffer.Pixels, System.Runtime.InteropServices.GCHandleType.Pinned);

          //  _screenrect = new Rectangle(0, 0, width, height);

            Engine.frameplace = 0;

	        bytesperline = xres;

           // _screenbuffer.Clear();
        
          //  _tempscreenbuffer = new int[_screenbuffer.Pixels.Length];
	
	        imageSize = bytesperline*yres;
        }

        public void BeginDrawing()
        {
            //setview(0, 0, xdim - 1, ydim - 1);
            Engine.frameplace = 0;
        }

        public void EndDrawing()
        {

        }

        public int windowx1, windowx2, windowy1, windowy2, wx1, wx2, wy1, wy2;
        public int halfxdimen, xdimenrecip;

        //
        // setview
        //
        
        public void setview(int x1, int y1, int x2, int y2)
        {
	        int i;

	        windowx1 = x1; wx1 = (x1<<12);
	        windowy1 = y1; wy1 = (y1<<12);
	        windowx2 = x2; wx2 = ((x2+1)<<12);
	        windowy2 = y2; wy2 = ((y2+1)<<12);

	        xdimen = (x2-x1)+1; halfxdimen = (xdimen>>1);
	        xdimenrecip = pragmas.divscale32( 1,xdimen);
	        ydimen = (y2-y1)+1;

            halfxdim16 = xres >> 1;
            midydim16 = pragmas.scale(200, yres, 480);

	        setaspect(65536,(int)pragmas.divscale16( ydim*320,xdim*200));

	        for(i=0;i<windowx1;i++) 
            { 
                startumost[i] = 1; 
                startdmost[i] = 0; 
            }
	        for(i=windowx1;i<=windowx2;i++)
		    {
                startumost[i] = (short)windowy1;
                startdmost[i] = (short)(windowy2 + 1);
            }
	        for(i=windowx2+1;i<xdim;i++) 
            { 
                startumost[i] = 1;
                startdmost[i] = 0; 
            }

	        /*
	        begindrawing();	//{{{
	        viewoffset = windowy1*bytesperline + windowx1;
	        enddrawing();	//}}}
	        */
        }

        /*
        public void SetScreenPixel(int pbase, byte val)
        {
           // int pdat = val * 3;

            _screenbuffer.Pixels[pbase] = _palette._palettebuffer[val];//(255 << 24) | ((byte)(_palette[pdat + 0] * 4) << 16) | (byte)(_palette[pdat + 1] * 4) << 8 | (byte)(_palette[pdat + 2] * 4);


            //_screenbuffer[pbase].R = (byte)(_palette[pdat + 0] * 4);
            //_screenbuffer[pbase].G = (byte)(_palette[pdat + 1] * 4);
            //_screenbuffer[pbase].B = (byte)(_palette[pdat + 2] * 4);
           // _screenbuffer[pbase].A = 255;
        }
        */

        //
        // SetScreenBufferFromPixelData
        //
        /*
        private void SetScreenBufferFromPixelData()
        {
            byte[] pixels = lpPixels.buffer;

            int pitch = ydim;
           

            
            for (int i = 0; i < _screenbuffer.Length; i++)
            {
                int pdat = pixels[i] * 3;
                _screenbuffer[i].R = (byte)(_palette[pdat + 0] * 4);
                _screenbuffer[i].G = (byte)(_palette[pdat + 1] * 4);
                _screenbuffer[i].B = (byte)(_palette[pdat + 2] * 4);
                _screenbuffer[i].A = 255;
            }
            
        }
        */
        //
        // setaspect
        //
        private void setaspect(int daxrange, int daaspect)
        {
            viewingrange = daxrange;
            viewingrangerecip = pragmas.divscale32( 1, daxrange);

            yxaspect = daaspect;
            xyaspect = pragmas.divscale32( 1, yxaspect);
            xdimenscale = pragmas.scale(xdimen, yxaspect, 320);
            xdimscale = pragmas.scale(320, xyaspect, xdimen);
        }

        //
        // SetPalette
        //
        public void SetPalette(bPalette palette)
        {
            if (palette == _palette)
                return;

            _paletteold = _palette;
            _palette = palette;
        }

        public void RestorePalette()
        {
            _palette = _paletteold;
        }

        //
        // Present
        //
        private int skipframe = 0;
        public void Present()
        {
            _screenbuffer.Present();
        }
    }
}
