using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Burrows_Wheeler_Data_Compression;

namespace BwdcTests
{
    [TestClass]
    public class BWCompressionTest
    {
        public static readonly byte[] F1 = { 5, 7, 9, 7, 45, 255, 77, 99, 64, 52, 15, 17, 44, 123, 58, 58, 7, 7, 9, 64, 5, 255, 15, 1, 1, 1, 1, 3 };
        public static readonly byte[] F2 = { 52, 76, 7, 8, 9, 1, 99, 99, 99, 99, 99, 99, 99, 87, 4, 4, 43, 2, 2, 1, 1, 10, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 14, 17, 18, 15, 11, 1, 1, 1, 2 };

        [TestMethod]
        public void TestCompressDecompress()
        {
            byte[] f1compressed = BWCompression.Compress(F1);
            byte[] f1decompressed = BWCompression.Decompress(f1compressed);
            CollectionAssert.AreEqual(F1, f1decompressed);

            byte[] f2compressed = BWCompression.Compress(F2);
            byte[] f2decompressed = BWCompression.Decompress(f2compressed);
            CollectionAssert.AreEqual(F2, f2decompressed);
        }
    }
}
