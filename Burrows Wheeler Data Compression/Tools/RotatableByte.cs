using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burrows_Wheeler_Data_Compression.Tools
{
    public class RotatableByte : IComparable
    {
        private byte[] arr;
        public int startIndex { get; private set; }
        public int Length { get { return arr.Length; } }

        public RotatableByte(byte[] arr, int startIndex)
        {
            this.arr = arr;
            this.startIndex = startIndex;
        }

        public byte At(int index)
        {
            return arr[(startIndex + index) % Length];
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            RotatableByte other = obj as RotatableByte;
            for (int i = 0; i < Length; i++)
            {
                if (this.At(i) != other.At(i))
                    return this.At(i) - other.At(i);
            }
            return 0;
        }
    }
}
