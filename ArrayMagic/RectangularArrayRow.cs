using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayMagic
{
    /// <summary>
    /// A wrapper that acts as a reference to a row in a rectangular array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RectangularArrayRow<T> : IList<T>
    {
        private T[,] _arr;
        private int _row;

        public RectangularArrayRow(T[,] arr, int row)
        {
            if (row > arr.GetLength(0))
                throw new ArgumentOutOfRangeException("No such row in array.", "row");

            _arr = arr;
            _row = row;
        }

        #region supported list behavior

        public int Count
        {
            get
            {
                return _arr.GetLength(1);
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                _arr[_row, i] = default(T);
            }
        }

        public T this[int i]
        {
            get
            {
                return _arr[_row, i];
            }
            set
            {
                _arr[_row, i] = value;
            }
        }

        public int IndexOf(T element)
        {
            int result = Array.BinarySearch(_arr.CopyRow(_row), element);
            return result < 0 ? -1 : result;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) > -1;
        }

        public void CopyTo(T[] new_array, int index)
        {
            if (new_array == null) throw new ArgumentNullException("Array provided is null", "new_array");
            if (index < 0) throw new ArgumentOutOfRangeException("Index cannot be less than 0", "index");

            for (int i = 0; i < Count; i++)
            {
                new_array[i + index] = this[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new RectangularArrayRowEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region enumerator

        class RectangularArrayRowEnumerator<Q> : IEnumerator<Q>
        {
            private RectangularArrayRow<Q> _row;
            private int _i = 0;

            public RectangularArrayRowEnumerator(RectangularArrayRow<Q> row)
            {
                _row = row;
            }

            public void Reset()
            {
                _i = 0;
            }

            public bool MoveNext()
            {
                return ++_i < _row.Count;
            }

            public Q Current
            {
                get
                {
                    try
                    {
                        return _row[_i];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                //nothing to dispose
            }
        }

        #endregion

        #region unsupported list behavior

        public void RemoveAt(int i)
        {
            throw new NotSupportedException();
        }

        public void Insert(int i, T element)
        {
            throw new NotSupportedException();
        }

        public bool Remove(T element)
        {
            throw new NotSupportedException();
        }

        public void Add(T element)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
