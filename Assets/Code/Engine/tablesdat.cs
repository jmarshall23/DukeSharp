using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Build
{
    public class bTable
    {
        public short[] sintable = new short[2048];
        public short[] radarang = new short[1280];
        public byte[] textfont = new byte[1024];
        public byte[] smalltextfont = new byte[1024];
        public byte[] britable = new byte[1024];

        public bTable()
        {
            int i;
            kFile fil;

            Engine.Printf("Loading Tables.dat...");
            if ((fil = Engine.filesystem.kopen4load("tables.dat")) != null)
            {
                fil.kread(ref sintable, 2048);
                fil.kread(ref radarang, 640);

                for (i = 0; i < 640; i++)
                    radarang[1279 - i] = (short)-radarang[i];

                fil.kread<byte>(ref textfont, 0, 1024);
                fil.kread<byte>(ref smalltextfont, 0, 1024);
                fil.kread<byte>(ref britable, 0, 1024);
            }
            else
            {
                throw new Exception("bTable::bTable: tables.dat not found");
            }
        }
    }
}
