using System;
using System.Linq;
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

            rectarr[0, 0] = 0;
            rectarr[0, 1] = 1;
            rectarr[0, 2] = 2;
            rectarr[0, 3] = 4;
            rectarr[0, 4] = 8;
            rectarr[0, 5] = 16;
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

        [TestMethod]
        public void TestArrayEnumerateRow()
        {
            var row = rectarr.EnumerateRow(0);

            var i = row.First();
            Assert.AreEqual(0, i);

            i = row.Skip(1).First();
            Assert.AreEqual(1, i);

            i = row.Skip(2).First();
            Assert.AreEqual(2, i);

            i = row.Skip(3).First();
            Assert.AreEqual(4, i);
        }
    }
}
