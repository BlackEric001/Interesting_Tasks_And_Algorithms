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

            var sortedArr = BubbleSort((int[])array.Clone());
            printArray("Массив отсортированный пузырьком", sortedArr);

            Console.WriteLine();

            sortedArr = QuickSort((int[])array.Clone(), 0, array.Length - 1);
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
            var qs = QuickSort((int[])bigArray.Clone(), 0, bigArray.Length - 1);
            watch.Stop();
            Console.WriteLine($"QuickSort {ARRAY_SIZE} elements = {watch.ElapsedMilliseconds} ms");

            //Bubble Sort
            watch = System.Diagnostics.Stopwatch.StartNew();
            var bs = BubbleSort((int[])bigArray.Clone());
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

        /// <summary>
        /// https://ru.wikipedia.org/wiki/%D0%A1%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0_%D0%BF%D1%83%D0%B7%D1%8B%D1%80%D1%8C%D0%BA%D0%BE%D0%BC
        /// </summary>
        /// <param name="arr"></param>
        private static int[] BubbleSort(int[] arr)
        {
            int temp;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            return arr;
        }

        /// <summary>
        /// https://ru.wikipedia.org/wiki/%D0%91%D1%8B%D1%81%D1%82%D1%80%D0%B0%D1%8F_%D1%81%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static int[] QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    QuickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }

            return arr;
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right])
                    {
                        return right;
                    }

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
