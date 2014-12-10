using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burrows_Wheeler_Data_Compression.Tools
{
    public static class BurrowsWheelerTransform
    {
        public static byte[] Transform(byte[] input)
        {
            byte[] output = new byte[input.Length + 4];
            List<RotatableByte> robs = new List<RotatableByte>(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                robs.Add(new RotatableByte(input, i));
            }
            RotatableByte S0 = robs.ElementAt(0);
            robs.Sort();
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = robs.ElementAt(i).At(input.Length - 1);
            }
            int I = robs.IndexOf(S0);
            byte[] ibyte = IntToByteArr(I);
            ibyte.CopyTo(output, input.Length);
            return output;
        }

        public static byte[] InverseTransform(byte[] input)
        {
            throw new NotImplementedException();
        }

        private static byte[] IntToByteArr(int i)
        {
            return BitConverter.GetBytes(i);
        }
    }
}
