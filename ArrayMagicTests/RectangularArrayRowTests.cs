using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayMagic;

namespace ArrayMagicTests
{
    [TestClass]
    public class RectangularArrayRowTests
    {
        int[,] rectarr;

        [TestInitialize]
        public void Initialize()
        {
            rectarr = new int[3, 10];

            //    row  column
            //      |  |
            //      |  |
            rectarr[1, 4] = 1337;
            rectarr[2, 4] = 42;
            rectarr[0, 9] = 9001;
        }

        [TestMethod]
        public void TestArrayRowCopy()
        {
            var row = rectarr.CopyRow(1);

            Assert.AreEqual(1337, row[4]);
        }

        [TestMethod]
        public void TestArrayRowReferenceRead()
        {
            var row = rectarr.Row(1);

            Assert.AreEqual(1337, row[4]);
        }

        [TestMethod]
        public void TestArrayRowReferenceWrite()
        {
            var row = rectarr.Row(2);

            row[4] = 7913;

            Assert.AreEqual(7913, rectarr[2, 4]);
        }
    }
}
