using System;
using System.Text;
using Burrows_Wheeler_Data_Compression.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BwdcTests
{
    [TestClass]
    public class MoveToFrontCodingTest
    {
        private static readonly String Input1 ="abbbaabbbaccabbaaabc";
        private static readonly byte[] Output1 = { 97, 98, 0, 0, 1, 0, 1, 0, 0, 1, 99, 0, 1, 2, 0, 1, 0, 0, 1, 2 };

        private static readonly String Input2 = "0123456789";
        private static readonly byte[] Output2={48,49,50,51,52,53,54,55,56,57};

        [TestMethod] 
        public void TestEncode()
        {
            byte[] encoded1 = MoveToFrontCoding.Encode( StringToByteArr(Input1));
            Assert.AreEqual(ByteArrToString(Output1),ByteArrToString(encoded1));

            byte[] encoded2 = MoveToFrontCoding.Encode(StringToByteArr(Input2));
            Assert.AreEqual(ByteArrToString(Output2), ByteArrToString(encoded2));
        }

        [TestMethod]
        public void TestDecode()
        {
            byte[] decoded1 = MoveToFrontCoding.Decode(Output1);
            Assert.AreEqual(Input1, ByteArrToString(decoded1));

            byte[] decoded2 = MoveToFrontCoding.Decode(Output2);
            Assert.AreEqual(Input2, ByteArrToString(decoded2));
        }

        private string ByteArrToString(byte[] input)
        {
            return new String(Encoding.ASCII.GetChars(input));
        }

        private byte[] StringToByteArr(String input)
        {
            return Encoding.ASCII.GetBytes(input);
        }

    }
}
