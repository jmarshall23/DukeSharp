using System;
using System.IO;
using System.Collections.Generic;

namespace Build
{
    public class bGrpArchive
    {
        private BinaryReader grpFile;
        public BinaryReader grpBuffer;

        

        public List<bGrpLump> lumps;

        private int KENGRP_HEADERSIZE = 16;
        private int KENGRP_LUMPSIZE = 16;

        private const string GRPIDEN = "KenSilverman";

        public struct bGrpLump
        {
            public string lumpName; // 12 bytes
            public int lumpOffset;
            public int lumpSize;
        };

        public bGrpArchive(string grpFilePath)
        {
            Init(null, grpFilePath);
        }

        public bGrpArchive(Stream grpFileStream)
        {
            Init(grpFileStream, "");
        }

        private void WriteLump(BinaryWriter grpwriter, bGrpLump lump)
        {
            for (int i = 0; i < 12; i++)
            {
                if (i >= lump.lumpName.Length)
                {
                    grpwriter.Write((byte)0);
                }
                else
                {
                    grpwriter.Write(lump.lumpName[i]);
                }
            }

            grpwriter.Write(lump.lumpSize);
        }

        private void AddLumpToGrp(int lumpnum, MemoryStream stream)
        {
            BinaryWriter grpwriter = new BinaryWriter(new MemoryStream());

            grpwriter.Write(GRPIDEN.ToCharArray());
            grpwriter.Write((int)lumps.Count);

            // Write out all the lumps
            for (int i = 0; i < lumps.Count; i++)
            {
                WriteLump(grpwriter, lumps[i]);
            }

            for (int i = 0; i < lumps.Count; i++)
            {
                if (i == lumpnum)
                {
                    grpwriter.Write(stream.ToArray());
                }
                else
                {
                    grpBuffer.BaseStream.Position = lumps[i].lumpOffset;
                    grpwriter.Write(grpBuffer.ReadBytes(lumps[i].lumpSize));
                }
            }

            grpBuffer = null;
            Init(grpwriter.BaseStream, "");
        }

        private void DeleteLump(int lumpnum)
        {
            BinaryWriter grpwriter = new BinaryWriter(new MemoryStream());

            grpwriter.Write(GRPIDEN.ToCharArray());
            grpwriter.Write((int)lumps.Count-1);

            // Write out all the lumps
            for (int i = 0; i < lumps.Count; i++)
            {
                if (i == lumpnum)
                {
                    continue;
                }
                else
                {
                    WriteLump(grpwriter, lumps[i]);
                }
            }

            for (int i = 0; i < lumps.Count; i++)
            {
                if (i == lumpnum)
                {
                    continue;
                }
                else
                {
                    grpBuffer.BaseStream.Position = lumps[i].lumpOffset;
                    grpwriter.Write(grpBuffer.ReadBytes(lumps[i].lumpSize));
                }
            }

            grpBuffer = null;
            Init(grpwriter.BaseStream, "");
        }

        public void DeleteFileFromGrp(string filename)
        {
            for (int i = 0; i < lumps.Count; i++)
            {
                if (lumps[i].lumpName == filename)
                {
                    DeleteLump(i);
                }
            }
        }

        public void WriteFileToGrp(string filename, MemoryStream stream)
        {
            bGrpLump lump;
            filename = filename.ToLower();
            // Check to see if this is a new file or if we are replacing an older one.
            for (int i = 0; i < lumps.Count; i++)
            {
                if (lumps[i].lumpName == filename)
                {
                    lump = lumps[i];
                    lump.lumpSize = (int)stream.Length;
                    lumps[i] = lump;

                    AddLumpToGrp(i, stream);
                    return;
                }
            }

            lump.lumpOffset = -1;
            lump.lumpName = filename;
            lump.lumpSize = (int)stream.Length;
            lumps.Add(lump);

            AddLumpToGrp(lumps.Count - 1, stream);
            
        }

        public byte[] ReadFile(string filename)
        {
            filename = filename.ToLower();
            for (int i = 0; i < lumps.Count; i++)
            {
                if (lumps[i].lumpName == filename)
                {
                    grpBuffer.BaseStream.Position = lumps[i].lumpOffset;
                    return grpBuffer.ReadBytes(lumps[i].lumpSize);
                }
            }

            return null;
        }

        private void Init(Stream memstream, string grpFilePath)
        {
            int numFilesInGrp;
            Engine.Printf("bGrpArchive::Init: Loading " + grpFilePath);

            if (memstream != null)
            {
                grpFile = new BinaryReader(memstream);
            }
            else
            {
                grpFile = new BinaryReader(new MemoryStream(Engine.filesystem.ReadContentFile(grpFilePath)));
            }
            if (grpFile == null)
            {
                throw new Exception("bGrpArchive::Init Failed to load " + grpFilePath);
            }

            grpFile.BaseStream.Position = 0;
            grpBuffer = new BinaryReader(new MemoryStream(grpFile.ReadBytes((int)grpFile.BaseStream.Length)));

            // Dispose of the HD binary reader since its now loaded into memory.
            grpFile.Dispose();

            // Check the file header to ensure its a valid grp file.
            Engine.Printf("...Checking Integrity");
            string header = new string(grpBuffer.ReadChars(12));
            if (header != GRPIDEN)
            {
                throw new Exception("bGrpArchive::Init Invalid Archive");
            }

            numFilesInGrp = grpBuffer.ReadInt32();
            Engine.Printf("..." + numFilesInGrp + " files");

            int offset = KENGRP_HEADERSIZE + (KENGRP_LUMPSIZE * numFilesInGrp);

            if (lumps == null)
            {
                lumps = new List<bGrpLump>();
            }
            lumps.Clear();
            for (int i = 0; i < numFilesInGrp; i++)
            {
                bGrpLump newlump = new bGrpLump();
                newlump.lumpName = new string(grpBuffer.ReadChars(12)).ToLower().Trim('\0');
                newlump.lumpSize = grpBuffer.ReadInt32();
                newlump.lumpOffset = offset;

                lumps.Add(newlump);

                offset += lumps[i].lumpSize;
            }
        }
    }
}
