﻿using Shared;
using System;
using System.Linq;

namespace Sorting
{
    class Program
    {
        private const int ARRAY_SIZE = 50000;

        static void Main(string[] args)
        {
            Console.WriteLine("Сортировка массива различными способами!");
            Console.WriteLine();
            SortByDifferentAlgorithms();

            Console.WriteLine();

            Console.WriteLine("Часть 2. Сравниваем скорость алгоритмов.");
            PerformanceCompare(ARRAY_SIZE);

            Console.WriteLine("Часть 3. Сортируем большие размеры.");
            TestOnBigSizeCompare(ARRAY_SIZE * 1000);

            Console.WriteLine();
            Console.WriteLine("The End");
            Console.ReadLine();
        }

        private static void TestOnBigSizeCompare(int arraySize)
        {
            Console.WriteLine($"Генерим большой массив {arraySize} элементов, для сравнения по скорости");
            Console.WriteLine();
            var rnd = new Random();
            int[] bigArray = Enumerable.Repeat(0, arraySize).Select(i => rnd.Next(int.MinValue, int.MaxValue)).ToArray();
            //ConsoleEx.printArray("Несортированный большой массив", bigArray);

            Console.WriteLine("Начинаем сортировку:");

            //Quick Sort
            RunQuickSort(arraySize, bigArray);

            //QuickSortDesc
            RunQuickSortDesc(arraySize, bigArray);

            //Linq Sort
            RunLinqSort(arraySize, bigArray);

            Console.WriteLine();
        }

        private static int[] RunLinqSort(int arraySize, int[] bigArray)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var ls = bigArray.OrderBy(x => x).ToArray();
            watch.Stop();
            Console.WriteLine($"LinqSort {arraySize} elements = {watch.ElapsedMilliseconds} ms");

            return ls;
        }

        private static int[] RunQuickSort(int arraySize, int[] bigArray)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var qs = QuickSort.Sort((int[])bigArray.Clone(), 0, bigArray.Length - 1);
            watch.Stop();
            Console.WriteLine($"QuickSort {arraySize} elements = {watch.ElapsedMilliseconds} ms");

            return qs;
        }

        private static int[] RunQuickSortDesc(int arraySize, int[] bigArray)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var qs = QuickSort.SortDesc((int[])bigArray.Clone(), 0, bigArray.Length - 1);
            watch.Stop();
            Console.WriteLine($"QuickSortDesc {arraySize} elements = {watch.ElapsedMilliseconds} ms");

            return qs;
        }

        /// <summary>
        /// #TODO
        /// 1. Add Desc QuickSort
        /// 2. Add decimal QuickSort
        /// 3. Add RadixSort
        /// </summary>
        private static void SortByDifferentAlgorithms()
        {
            int[] array = { -1, 123, 5, 7, 4000, 8, 567, 987, 311, 900, 0, -1/*, 311*/ };

            ConsoleEx.printArray("Несортированный массив:", array);
            Console.WriteLine();

            var sortedArr = RunBubbleSort(array.Length, array);
            ConsoleEx.printArray("Массив отсортированный пузырьком:", sortedArr);

            Console.WriteLine();

            sortedArr = RunQuickSort(array.Length, array);
            ConsoleEx.printArray("Массив отсортированный быстрой сортировкой:", sortedArr);

            sortedArr = RunQuickSortDesc(array.Length, array);
            ConsoleEx.printArray("Массив отсортированный быстрой сортировкой desc:", sortedArr);
        }

        private static void PerformanceCompare(int arraySize)
        {
            Console.WriteLine($"Генерим большой массив {arraySize} элементов, для сравнения по скорости");
            Console.WriteLine();
            var rnd = new Random();
            int[] bigArray = Enumerable.Repeat(0, arraySize).Select(i => rnd.Next(int.MinValue, int.MaxValue)).ToArray();
            //ConsoleEx.printArray("Несортированный большой массив", bigArray);

            Console.WriteLine("Начинаем сортировку:");

            //Quick Sort
            RunQuickSort(arraySize, bigArray);

            //QuickSortDesc
            RunQuickSortDesc(arraySize, bigArray);

            //Bubble Sort
            RunBubbleSort(arraySize, bigArray);

            //Linq Sort
            RunLinqSort(arraySize, bigArray);

            Console.WriteLine();
        }

        private static int[] RunBubbleSort(int arraySize, int[] bigArray)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var bs = BubbleSort.Sort((int[])bigArray.Clone());
            watch.Stop();
            Console.WriteLine($"BubbleSort {arraySize} elements = {watch.ElapsedMilliseconds} ms");

            return bs;
        }
    }
}
