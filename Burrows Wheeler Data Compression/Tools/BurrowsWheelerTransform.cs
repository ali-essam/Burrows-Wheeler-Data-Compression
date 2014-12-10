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
            byte[] output = new byte[input.Length];
            List<RotatableByte> robs = new List<RotatableByte>(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                robs.Add(new RotatableByte(input, i));
            }
            robs.Sort();
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = robs.ElementAt(i).At(input.Length - 1);
            }
            return output;
        }

        public static byte[] InverseTransform(byte[] input)
        {
            throw new NotImplementedException();
        }
    }
}
