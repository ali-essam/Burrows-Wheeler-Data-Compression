using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Burrows_Wheeler_Data_Compression.Tools;

namespace BwdcTests
{
    [TestClass]
    public class HuffmanCodingTest
    {
        public static readonly byte[] DECODED1 = { 0, 1, 0, 0, 0, 2 };
        public static readonly string ENCODED1 = "000110100000000000000010000000010000100000000000000000000000000001000110";

        public static readonly byte[] DECODED2 = { 0, 1, 1, 1, 0, 0, 2, 3, 1, 0 };
        public static readonly string ENCODED2 = "011101000000000000000011000000100000000100010010000000000000000000000000000111001010110000000000";

        
        [TestMethod]
        public void TestEncode()
        {
            byte[] output1 = HuffmanCoding.Encode(DECODED1);
            byte[] expoutput1 = BitStringToByteArray(ENCODED1);
            CollectionAssert.AreEqual(expoutput1, output1);

            byte[] output2 = HuffmanCoding.Encode(DECODED2);
            byte[] expoutput2 = BitStringToByteArray(ENCODED2);
            CollectionAssert.AreEqual(expoutput2, output2);
        }

        [TestMethod]
        public void TestDecode()
        {
            byte[] encoded1 = BitStringToByteArray(ENCODED1);
            byte[] decoded1 = HuffmanCoding.Decode(encoded1);
            CollectionAssert.AreEqual(DECODED1, decoded1);

            byte[] encoded2 = BitStringToByteArray(ENCODED2);
            byte[] decoded2 = HuffmanCoding.Decode(encoded2);
            CollectionAssert.AreEqual(DECODED2, decoded2);
        }

        private static byte[] BitStringToByteArray(String input)
        {
            int numOfBytes = input.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; ++i)
            {
                bytes[i] = Convert.ToByte(input.Substring(8 * i, 8), 2);
            }
            return bytes;
        }
    }
}
