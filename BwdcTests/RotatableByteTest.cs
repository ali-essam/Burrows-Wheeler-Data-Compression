using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Burrows_Wheeler_Data_Compression.Tools;

namespace BwdcTests
{
    [TestClass]
    public class RotatableByteTest
    {
        private static readonly byte[] barry = new byte[] { 1, 2, 3 };
        private static readonly RotatableByte rob0 = new RotatableByte(barry, 0);
        private static readonly RotatableByte rob2 = new RotatableByte(barry, 2);
        [TestMethod]
        public void TestAt()
        {
            Assert.AreEqual<byte>(rob0.At(1), 2);
            Assert.AreEqual<byte>(rob2.At(2), 2);
        }

        [TestMethod]
        public void TestCompare()
        {
            int c00 = rob0.CompareTo(rob0);
            int c02 = rob0.CompareTo(rob2);
            int c20 = rob2.CompareTo(rob0);
            Assert.AreEqual<int>(0, c00);
            Assert.IsTrue(c02 < 0);
            Assert.IsTrue(c20 > 0);
        }
    }
}
