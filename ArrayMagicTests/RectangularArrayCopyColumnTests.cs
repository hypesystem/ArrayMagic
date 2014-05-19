using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayMagic;

namespace ArrayMagicTests
{
    [TestClass]
    public class RectangularArrayCopyColumnTests
    {
        [TestMethod]
        public void RectArrayCopyColumn_1x1Rect_Column()
        {
            int[,] rect_arr = new int[1, 1];
            rect_arr[0, 0] = 1;

            var col = rect_arr.CopyColumn(0);

            Assert.AreEqual(1, col[0]);
        }

        [TestMethod]
        public void RectArrayCopyColumn_2x1Rect_Column()
        {
            int[,] rect_arr = new int[2, 1];
            rect_arr[0, 0] = 1;
            rect_arr[1, 0] = 2;

            var col = rect_arr.CopyColumn(0);
            Assert.AreEqual(1, col[0]);
            Assert.AreEqual(2, col[1]);
        }
    }
}
