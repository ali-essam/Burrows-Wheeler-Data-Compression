using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Burrows_Wheeler_Data_Compression.Tools;
using System.Text;
namespace BwdcTests
{
    [TestClass]
    public class BurrowsWheelerTransformTest
    {
        private static readonly String STR = "this is a test.";
        private static readonly String STR_TRANSFORMED = "ssat tt hiies .";
        private static readonly byte[] IBytes = new byte[] { 14, 0, 0, 0 };
        private static readonly byte[] STR_TRANSFORMED_BYTEARR = new byte[STR_TRANSFORMED.Length + 4];

        [TestInitialize]
        public void Init()
        {
            byte[] output = StringToByteArr(STR_TRANSFORMED);
            output.CopyTo(STR_TRANSFORMED_BYTEARR, 0);
            IBytes.CopyTo(STR_TRANSFORMED_BYTEARR, STR_TRANSFORMED.Length);
        }

        [TestMethod]
        public void TestTransform()
        {
            byte[] output = BurrowsWheelerTransform.Transform(StringToByteArr(STR));
            Assert.AreEqual<String>(ByteArrToString(STR_TRANSFORMED_BYTEARR), ByteArrToString(output));
        }

        [TestMethod]
        public void TestInverseTransform()
        {
            throw new NotImplementedException();
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
