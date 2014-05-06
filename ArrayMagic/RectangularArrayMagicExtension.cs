using System;
using System.Collections.Generic;

namespace ArrayMagic
{
    public static class RectangularArrayMagicExtension
    {
        /// <summary>
        /// Get a row of a
        /// </summary>
        /// <typeparam name="T">Type of rectangular array</typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T[] CopyRow<T>(this T[,] arr, int row)
        {
            if (row > arr.GetLength(0))
                throw new ArgumentOutOfRangeException("No such row in array.", "row");

            var result = new T[arr.GetLength(1)];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = arr[row, i];
            }
            return result;
        }

        public static IList<T> Row<T>(this T[,] arr, int row)
        {
            if (row > arr.GetLength(0))
                throw new ArgumentOutOfRangeException("No such row in array.", "row");

            return new RectangularArrayRow<T>(arr, row);
        }

        public static IEnumerable<T> EnumerateRow<T>(this T[,] arr, int row)
        {
            if (row > arr.GetLength(0))
                throw new ArgumentOutOfRangeException("No such row in array.", "row");

            for (int i = 0; i < arr.GetLength(1); i++)
                yield return arr[row, i];
        }
    }
}
