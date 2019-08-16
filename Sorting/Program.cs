using System;
using System.Linq;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 123, 5, 7, 4000, 8, 567, 987, 311, 900, 0, -1 };

            Console.WriteLine("Сортировка массива!");
            Console.WriteLine();
            printArray("Несортированный массив", array);
            Console.WriteLine();

            var sortedArr = BubbleSort.Sort((int[])array.Clone());
            printArray("Массив отсортированный пузырьком", sortedArr);

            Console.WriteLine();

            sortedArr = QuickSort.Sort((int[])array.Clone(), 0, array.Length - 1);
            printArray("Массив отсортированный быстрой сортировкой", sortedArr);

            Console.WriteLine();

            Console.WriteLine("Часть 2. Сравниваем скорость алгоритмов.");
            const int ARRAY_SIZE = 50000;
            Console.WriteLine($"Генерим большой массив {ARRAY_SIZE} элементов, для сравнения по скорости");
            Console.WriteLine();
            var rnd = new Random();
            int[] bigArray = Enumerable.Repeat(0, ARRAY_SIZE).Select(i => rnd.Next(int.MinValue, int.MaxValue)).ToArray();
            //printArray("Несортированный большой массив", bigArray);

            Console.WriteLine("Начинаем сортировку:");

            //Quick Sort
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var qs = QuickSort.Sort((int[])bigArray.Clone(), 0, bigArray.Length - 1);
            watch.Stop();
            Console.WriteLine($"QuickSort {ARRAY_SIZE} elements = {watch.ElapsedMilliseconds} ms");

            //Bubble Sort
            watch = System.Diagnostics.Stopwatch.StartNew();
            var bs = BubbleSort.Sort((int[])bigArray.Clone());
            watch.Stop();
            Console.WriteLine($"BubbleSort {ARRAY_SIZE} elements = {watch.ElapsedMilliseconds} ms");

            //Linq Sort
            watch = System.Diagnostics.Stopwatch.StartNew();
            var ls = bigArray.OrderBy(x => x).ToArray();
            watch.Stop();
            Console.WriteLine($"LinqSort {ARRAY_SIZE} elements = {watch.ElapsedMilliseconds} ms");

            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("The End");
            Console.ReadLine();
        }

        private static void printArray(string message, int[] array)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }
            Console.WriteLine(string.Join(", ", array.Select(x => x.ToString()).ToArray()));
        }
    }
}
