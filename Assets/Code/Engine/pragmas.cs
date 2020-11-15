// This file has been modified from Ken Silverman's original release
// (byte) Jonathon Fowler (jonof@edgenetwk.com)

// Ported to XNA/C# (byte) Justin Marshall.  This is nasty and very digusting since its all very quick porting,
// I feel for Jonathon and TerminX who had to port this crap from assembly :/. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Build
{
    [StructLayout(LayoutKind.Explicit)]
    struct longfloat
    {
        [FieldOffset(0)]
        public float f;
        [FieldOffset(0)]
        public int i;
    }
    public static class pragmas
    {
        private static ushort[] sqrtable = new ushort[4096];
        private static ushort[] shlookup = new ushort[4096 + 256];
        private static int dmvallocal = 0;
        private static int[] reciptable = new int[2048];
        private static int[] doscolors = new int[16];

#if BUILD_INTEROPSERVICES
        private static object recriptablegchandle;
#endif

        public static void drawpixel(int pbase, int a)
        {
            Engine._device._screenbuffer.Pixels[pbase] = doscolors[a];
        }

        public static void drawpixelpal(int pbase, int a)
        {
            Engine._device._screenbuffer.Pixels[pbase] = a;
        }

        public static int dmval
        {
            get
            {
                return dmvallocal;
            }
        }

        private static void initksqrt()
        {
            int i, j, k;

            j = 1; k = 0;
            for (i = 0; i < 4096; i++)
            {
                if (i >= j) { j <<= 2; k++; }
                sqrtable[i] = (ushort)(msqrtasm((i << 18) + 131072) << 1);
                shlookup[i] = (ushort)((k << 1) + ((10 - k) << 8));
                if (i < 256)
                    shlookup[i + 4096] = (ushort)(((k + 6) << 1) + ((10 - (k + 6)) << 8));
            }
        }

        public static void InitPragmas()
        {

            initksqrt();

            for (int i = 0; i < 2048; i++) 
                reciptable[i] = (int)divscale30( 2048, i + 2048);
            /*
            for (int i = 0; i < 16; i++)
            {
                System.Windows.Media.Color color = Color.FromArgb(0, 0, 0, 0);
                switch (i)
                {
                    case 0: color = Colors.Black; break;
                    case 1: color = Colors.Blue; break;
                    case 2: color = Colors.Green; break;
                    case 3: color = Color.FromArgb(0xFF, 0, 0xFF, 0xFF); break;
                    case 4: color = Colors.Red; break;
                    case 5: color = Colors.Purple; break;
                    case 6: color = Color.FromArgb(0xFF, 168, 84, 0 ); break;
                    case 7: color = Colors.White; break;
                    case 8: color = Colors.Gray; break;
                    case 9: color = Color.FromArgb(0xFF,00, 0xFF, 0xFF); break;
                    case 10: color = Color.FromArgb(0xFF, 0x00, 0xFF, 0x00); break;
                    case 11: color = Color.FromArgb(0xFF, 0x00, 0xFF, 0xFF); break;
                    case 12: color = Color.FromArgb(0xFF, 252, 82, 82); break;
                    case 13: color = Color.FromArgb(0xFF, 255, 0, 255); break;
                    case 14: color = Colors.Yellow; break;
                    case 15: color = Colors.White; break;
                    default:
                         throw new Exception("dos color not implemented");
                }

                doscolors[i] = (255 << 24) | ((byte)(color.R) << 16) | (byte)(color.G) << 8 | (byte)(color.B);
            }

#if BUILD_INTEROPSERVICES
            recriptablegchandle = GCServices.Alloc(reciptable, GCHandleType.Pinned);
            Utility.lib.InitTables((int *)GCServices.AddrOfPinnedObject(recriptablegchandle).ToPointer());
#endif
*/
        }

        public static int mulscale1(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 1);
        }

        public static int mulscale2(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 2);
        }

        public static int mulscale3(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 3);
        }

        public static int mulscale4(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 4);
        }

        public static int mulscale5(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 5);
        }

        public static int mulscale6(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 6);
        }

        public static int mulscale7(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 7);
        }

        public static int mulscale8(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 8);
        }

        public static int mulscale9(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 9);
        }

        public static int mulscale10(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 10);
        }
        public static int mulscale11(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 11);
        }
        public static int mulscale12(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 12);
        }
        public static int mulscale13(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 13);
        }
        public static int mulscale14(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 14);
        }
        public static int mulscale15(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 15);
        }
        public static int mulscale16(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 16);
        }
        public static int mulscale18(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 18);
        }
        public static int mulscale19(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 19);
        }
        public static int mulscale20(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 20);
        }
        public static int mulscale21(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 21);
        }
        public static int mulscale22(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 22);
        }
        public static int mulscale23(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 24);
        }
        public static int mulscale24(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 24);
        }
        public static int mulscale27(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 27);
        }
        public static int mulscale28(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 28);
        }
        public static int mulscale30(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 30);
        }
        public static int mulscale31(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 31);
        }
        public static int mulscale32(int eax, int edx)
        {
            return (int)(((Int64)(eax) * (Int64)(edx)) >> 32);
        }

        public static int divscale12(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 12) / (Int64)(ebx));
        }


        public static int divscale14(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 14) / (Int64)(ebx));
        }

        public static int divscale15(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 15) / (Int64)(ebx));
        }

        public static int divscale16(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 16) / (Int64)(ebx));
        }

        public static int divscale17(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 17) / (Int64)(ebx));
        }

        public static int divscale18(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 18) / (Int64)(ebx));
        }

        public static int divscale19(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 19) / (Int64)(ebx));
        }

        public static int divscale20(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 20) / (Int64)(ebx));
        }

        public static int divscale21(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 21) / (Int64)(ebx));
        }

        public static int divscale22(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 22) / (Int64)(ebx));
        }
        public static int divscale24(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 24) / (Int64)(ebx));
        }

        public static int divscale26(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 26) / (Int64)(ebx));
        }

        public static int divscale28(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 28) / (Int64)(ebx));
        }

        public static int divscale30(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 30) / (Int64)(ebx));
        }

        public static int divscale32(int eax, int ebx)
        {
            return (int)(((Int64)(eax) << 32) / (Int64)(ebx));
        }

        public static int dmulscale2(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 2);
        }

        public static int dmulscale3(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 3);
        }

        public static int dmulscale6(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 6);
        }

        public static int dmulscale8(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 8);
        }

        public static int dmulscale9(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 9);
        }

        public static int dmulscale10(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 10);
        }

        public static int dmulscale12(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 12);
        }

        public static int dmulscale14(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 14);
        }

        public static int dmulscale15(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 15);
        }

        public static int dmulscale16(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 16);
        }

        public static int dmulscale17(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 17);
        }

        public static int dmulscale18(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 18);
        }

        public static int dmulscale24(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 24);
        }

        public static int dmulscale25(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 25);
        }

        public static int dmulscale32(int eax, int edx, int esi, int edi)
        {
            return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> 32);
        }

        //   public static int tmulscale(int a, int eax, int edx, int ebx, int ecx, int esi, int edi)
        //   {
        //       return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(ebx) * (Int64)(ecx)) + ((Int64)(esi) * (Int64)(edi))) >> a);
        //   }

        public static int ksqrt(int num)
        {
            return ((int)nsqrtasm((uint)num));
        }

        private static longfloat f;

        public static int krecipasm(int i)
        { // Ken did this
            f.i = 0;
            f.f = (float)i;
            i = f.i;
            // float f = (float)i; i = f;
            return ((reciptable[((int)i >> 12) & 2047] >> (int)((((int)i - 0x3f800000) >> 23) & 31)) ^ ((int)i >> 31));
        }


        public static int nsqrtasm(uint a)
        {
            // JBF 20030901: This was a damn lot simpler to reverse engineer than
            // msqrtasm was. Really, it was just like simplifying an algebra equation.
            UInt16 c;

            if ((a & 0xff000000) != 0)  			// test eax, 0xff000000  /  jnz short over24
            {
                c = shlookup[(a >> 24) + 4096];	// mov ebx, eax
                // over24: shr ebx, 24
                // mov cx, word ptr shlookup[ebx*2+8192]
            }
            else
            {
                c = shlookup[a >> 12];		// mov ebx, eax
                // shr ebx, 12
                // mov cx, word ptr shlookup[ebx*2]
                // jmp short under24
            }
            a >>= c & 0xff;				// under24: shr eax, cl
            a = (a & 0xffff0000) | (sqrtable[a]);	// mov ax, word ptr sqrtable[eax*2]
            a >>= ((c & 0xff00) >> 8);		// mov cl, ch
            // shr eax, cl
            return (int)a;
        }
        public static void qinterpolatedown16(int start, ref int[] lptr, int num, int val, int add)
        {
            // gee, I wonder who could have provided this...
            int i;
            for (i = 0; i < num; i++) { lptr[start + i] = (val >> 16); val += add; }
        }


        public static void qinterpolatedown16short(int start, ref short[] sptr, int num, int val, int add)
        {
            // ...maybe the same person who provided this too?
            int i;
            for (i = 0; i < num; i++) { sptr[i + start] = (short)(val >> 16); val += add; }
        }



        public static int msqrtasm(int c)
        {
            int a, b;

            a = 0x40000000;		// mov eax, 0x40000000
            b = 0x20000000;		// mov ebx, 0x20000000
            do  				// begit:
            {
                if (c >= a)  		// cmp ecx, eax	 /  jl skip
                {
                    c -= a;		// sub ecx, eax
                    a += b * 4;	// lea eax, [eax+ebx*4]
                }			// skip:
                a -= b;			// sub eax, ebx
                a >>= 1;		// shr eax, 1
                b >>= 2;		// shr ebx, 2
            }
            while (b != 0);			// jnz begit
            if (c >= a)			// cmp ecx, eax
                a++;			// sbb eax, -1
            a >>= 1;			// shr eax, 1
            return a;
        }

        public static void swaplong<T>(ref T a, ref T b) { T t = b; b = a; a = t; }

        public static int mul3(int a) { return (a << 1) + a; }
        public static int mul5(int a) { return (a << 2) + a; }
        public static int mul9(int a) { return (a << 3) + a; }

        public static int divmod(int a, int b) { dmvallocal = a % b; return a / b; }
        public static int moddiv(int a, int b) { dmvallocal = a / b; return a % b; }

        public static int klabs(int a) { if (a < 0) return -a; return a; }
        public static int ksgn(int a) { if (a > 0) return 1; if (a < 0) return -1; return 0; }

        public static int sgn(int i1)
        {
            return ksgn(i1);
        }

        public static int umin(int a, int b) { if ((int)a < (int)b) return a; return b; }
        public static int umax(int a, int b) { if ((int)a < (int)b) return b; return a; }
        public static int kmin(int a, int b) { if ((int)a < (int)b) return a; return b; }
        public static int kmax(int a, int b) { if ((int)a < (int)b) return b; return a; }

        public static int sqr(int eax) { return (eax) * (eax); }
        public static int scale(int eax, int edx, int ecx) { return (int)(((Int64)(eax) * (Int64)(edx)) / (Int64)(ecx)); }
        public static int mulscale(int eax, int edx, int ecx) { return (int)(((Int64)(eax) * (Int64)(edx)) >> (byte)(ecx)); }
        public static int divscale(int eax, int ebx, int ecx) { return (int)(((Int64)(eax) << (byte)(ecx)) / (Int64)(ebx)); }
        //public static int dmulscale(int eax, int edx, int esi, int edi, int ecx) { return (int)((((Int64)(eax) * (Int64)(edx)) + ((Int64)(esi) * (Int64)(edi))) >> (byte)(ecx)); }
    }

}
