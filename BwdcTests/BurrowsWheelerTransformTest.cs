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

        [TestMethod]
        public void TestTransform()
        {
            byte[] output = BurrowsWheelerTransform.Transform(StringToByteArr(STR));
            Assert.AreEqual<String>(STR_TRANSFORMED, ByteArrToString(output));
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
