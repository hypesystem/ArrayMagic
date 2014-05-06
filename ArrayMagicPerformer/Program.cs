using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayMagic;
using System.Diagnostics;

namespace ArrayMagicPerformer
{
    class Program
    {
        static Action<int[,]> setupRowOf100000_RowCopy, setupRowOf100000_Row, setupRowOf100000_EnumerateRow;
        static Action<int[]> sumRowOf100000_RowCopy;
        static Action<IList<int>> sumRowOf100000_Row;
        static Action<IEnumerable<int>> sumRowOf100000_EnumerateRow;
        static Action<int[], IEnumerable<int>> randomAccess3000_RowCopy;
        static Action<IList<int>, IEnumerable<int>> randomAccess3000_Row;
        static Action<IEnumerable<int>, IEnumerable<int>> randomAccess3000_EnumerateRow;

        static void Main(string[] args)
        {
            var rectarr = GenerateRectangularArrayOf100000();
            var rands = GenerateRandomNumbers();

            SetUpActions();

            Time100Actions("CopyRow Setup", setupRowOf100000_RowCopy, rectarr);
            Time100Actions("Row Setup", setupRowOf100000_Row, rectarr);
            Time100Actions("EnumerateRow Setup", setupRowOf100000_EnumerateRow, rectarr);

            var copyRow = rectarr.CopyRow(0);
            var row = rectarr.Row(0);
            var enumerateRow = rectarr.EnumerateRow(0);

            Time100Actions("CopyRow Sum", sumRowOf100000_RowCopy, copyRow);
            Time100Actions("Row Sum", sumRowOf100000_Row, row);
            Time100Actions("EnumerateRow Sum", sumRowOf100000_EnumerateRow, enumerateRow);

            Time100Actions("CopyRow Random Access", randomAccess3000_RowCopy, copyRow, rands);
            Time100Actions("Row Random Access", randomAccess3000_Row, row, rands);
            Time100Actions("EnumerateRow Random Access", randomAccess3000_EnumerateRow, enumerateRow, rands);

            Console.ReadKey();
        }

        static int[,] GenerateRectangularArrayOf100000()
        {
            var rand = new Random();

            int[,] result = new int[1, 100000];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = rand.Next(int.MaxValue);
                }
            }
            return result;
        }

        static IEnumerable<int> GenerateRandomNumbers()
        {
            var rand = new Random();

            for (int i = 0; i < 3000; i++)
            {
                yield return rand.Next(100000);
            }
        }

        static void SetUpActions()
        {
            setupRowOf100000_RowCopy = x => x.CopyRow(0);
            setupRowOf100000_Row = x => x.Row(0);
            setupRowOf100000_EnumerateRow = x => x.EnumerateRow(0);

            sumRowOf100000_RowCopy = x =>
            {
                int result = 0;
                foreach (int i in x)
                    result += i;
            };

            sumRowOf100000_Row = x =>
            {
                int result = 0;
                foreach (int i in x)
                    result += i;
            };

            sumRowOf100000_EnumerateRow = x =>
            {
                int result = 0;
                foreach (int i in x)
                    result += i;
            };

            randomAccess3000_RowCopy = (x, y) =>
            {
                int z;
                foreach (int i in y)
                    z = x[i];
            };

            randomAccess3000_Row = (x, y) =>
            {
                int z;
                foreach (int i in y)
                    z = x[i];
            };

            randomAccess3000_EnumerateRow = (x, y) =>
            {
                int z;
                foreach (int i in y)
                    z = x.ElementAt(i);
            };
        }

        static void Time100Actions<T>(string name, Action<T> action, T arg)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("   Running test " + name + " ...");

            double sum_time = 0d;
            for (int i = 0; i < 100; i++)
            {
                var stopwatch = Stopwatch.StartNew();
                action(arg);
                stopwatch.Stop();
                sum_time += stopwatch.Elapsed.TotalMilliseconds;
            }

            Console.WriteLine("100 tests in " + sum_time + "ms averaging " + (sum_time / 100) + "ms per test");
            Console.WriteLine("------------------------------------------");
        }

        static void Time100Actions<T, P>(string name, Action<T, P> action, T arg1, P arg2)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("   Running test " + name + " ...");

            double sum_time = 0d;
            for (int i = 0; i < 100; i++)
            {
                var stopwatch = Stopwatch.StartNew();
                action(arg1,arg2);
                stopwatch.Stop();
                sum_time += stopwatch.Elapsed.TotalMilliseconds;
            }

            Console.WriteLine("100 tests in " + sum_time + "ms averaging " + (sum_time / 100) + "ms per test");
            Console.WriteLine("------------------------------------------");
        }
    }
}
