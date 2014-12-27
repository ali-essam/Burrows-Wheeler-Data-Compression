using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Burrows_Wheeler_Data_Compression.Tools;

namespace Burrows_Wheeler_Data_Compression
{
    public class BWCompression
    {
        public static byte[] Compress(byte[] Data)
        {
            byte[] bw = BurrowsWheelerTransform.Transform(Data);
            byte[] mtf = MoveToFrontCoding.Encode(bw);
            byte[] hf = HuffmanCoding.Encode(mtf);
            return hf;
        }

        public static byte[] Decompress(byte[] data)
        {
            byte[] dhf = HuffmanCoding.Decode(data);
            byte[] imtf = MoveToFrontCoding.Decode(dhf);
            byte[] ibw = BurrowsWheelerTransform.InverseTransform(imtf);
            return ibw;
        }
    }
}
