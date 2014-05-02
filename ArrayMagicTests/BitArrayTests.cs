using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayMagic;

namespace ArrayMagicTests
{
    [TestClass]
    public class BitArrayTests
    {
        [TestMethod]
        public void TestIntegerOddFromBits()
        {
            var bytes = BitConverter.GetBytes(1337);
            bool[] bits = bytes.ToBitArray();

            //bit #0 is 1 => number is odd.
            Assert.IsTrue(bits[0]);
        }
    }
}
