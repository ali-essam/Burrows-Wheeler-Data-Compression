using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Burrows_Wheeler_Data_Compression.External;

namespace BwdcTests
{
    /// <summary>
    /// Summary description for SuffixArrayTest
    /// </summary>
    [TestClass]
    public class SuffixArrayTest
    {
        string input1 = "GATAGACA";
        int[] output1 = { 7, 5, 3, 1, 6, 4, 0, 2 };
        string input2 = "abaaba$";
        int[] output2 = {6,5,2,3,0,4,1 };
        
        [TestMethod]
        public void ConstructTest()
        {
            int[] suffix1 = SuffixArray.Construct(StringToShortArr(input1));
            int[] suffix2 = SuffixArray.Construct(StringToShortArr(input2));
            CollectionAssert.AreEqual(output1, suffix1);
            CollectionAssert.AreEqual(output2, suffix2);
        }
        private short[] StringToShortArr(String input)
        {
            short[] ret = new short[input.Length];
            for (int i = 0; i < input.Length; i++)
                ret[i] = Convert.ToInt16(input[i]);
            return ret;
        }
    
    }
}
