using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Build
{
    public class EndianBinaryReader : BinaryReader
    {
        bool swap = false;

        public EndianBinaryReader(Stream stream)
            : base(stream)
        {

        }

        public void SetLittleEdian()
        {
            swap = !BitConverter.IsLittleEndian;
        }

        public void SetBigEdian()
        {
            swap = BitConverter.IsLittleEndian;
        }

        private byte[] Swap(int size)
        {
            byte[] data = ReadBytes(size);
            if (swap)
            {
                Array.Reverse(data, 0, size);
            }
            return data;
        }

        public override double ReadDouble()
        {
            return BitConverter.ToDouble(Swap(sizeof(double)), 0);
        }

        public override short ReadInt16()
        {
            return BitConverter.ToInt16(Swap(sizeof(short)), 0);
        }
        public override int ReadInt32()
        {
            return BitConverter.ToInt32(Swap(sizeof(int)), 0);
        }

        public override long ReadInt64()
        {
            return BitConverter.ToInt64(Swap(sizeof(long)), 0);
        }

        public override float ReadSingle()
        {
            return BitConverter.ToSingle(Swap(sizeof(float)), 0);
        }
        public override ushort ReadUInt16()
        {
            return BitConverter.ToUInt16(Swap(sizeof(ushort)), 0);
        }

        public override uint ReadUInt32()
        {
            return BitConverter.ToUInt32(Swap(sizeof(uint)), 0);
        }
        public override ulong ReadUInt64()
        {
            return BitConverter.ToUInt64(Swap(sizeof(ulong)), 0);
        }
    }
}
