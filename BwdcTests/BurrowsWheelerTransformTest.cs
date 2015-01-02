using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Burrows_Wheeler_Data_Compression.Tools;
using System.Text;
namespace BwdcTests
{
    [TestClass]
    public class BurrowsWheelerTransformTest
    {
        private static readonly String STR1 = "abaaba";
        private static readonly String STR_TRANSFORMED1 = "abbaaa";
        private static readonly byte[] IBytes1 = new byte[] { 4, 0, 0, 0 };
        private static readonly byte[] STR_TRANSFORMED_BYTEARR1 = new byte[STR_TRANSFORMED1.Length + 4];

        private static readonly String STR2 = "caba";
        private static readonly String STR_TRANSFORMED2 = "abca";
        private static readonly byte[] IBytes2 = new byte[] { 4, 0, 0, 0 };
        private static readonly byte[] STR_TRANSFORMED_BYTEARR2 = new byte[STR_TRANSFORMED2.Length + 4];

        [TestInitialize]
        public void Init()
        {
            byte[] output1 = StringToByteArr(STR_TRANSFORMED1);
            output1.CopyTo(STR_TRANSFORMED_BYTEARR1, 0);
            IBytes1.CopyTo(STR_TRANSFORMED_BYTEARR1, STR_TRANSFORMED1.Length);

            byte[] output2 = StringToByteArr(STR_TRANSFORMED2);
            output2.CopyTo(STR_TRANSFORMED_BYTEARR2, 0);
            IBytes2.CopyTo(STR_TRANSFORMED_BYTEARR2, STR_TRANSFORMED2.Length);
        }

        [TestMethod]
        public void TestTransform()
        {
            byte[] output1 = BurrowsWheelerTransform.Transform(StringToByteArr(STR1));
            Assert.AreEqual<String>(ByteArrToString(STR_TRANSFORMED_BYTEARR1), ByteArrToString(output1));

            byte[] output2 = BurrowsWheelerTransform.Transform(StringToByteArr(STR2));
            Assert.AreEqual<String>(ByteArrToString(STR_TRANSFORMED_BYTEARR2), ByteArrToString(output2));
        }

        [TestMethod]
        public void TestInverseTransform()
        {
            byte[] output1 = BurrowsWheelerTransform.InverseTransform(STR_TRANSFORMED_BYTEARR1);
            Assert.AreEqual<String>(STR1, ByteArrToString(output1));

            byte[] output2 = BurrowsWheelerTransform.InverseTransform(STR_TRANSFORMED_BYTEARR2);
            Assert.AreEqual<String>(STR2, ByteArrToString(output2));
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
