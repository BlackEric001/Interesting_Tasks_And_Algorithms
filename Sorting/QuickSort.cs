using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    public class QuickSort
    {
        /// <summary>
        /// https://ru.wikipedia.org/wiki/%D0%91%D1%8B%D1%81%D1%82%D1%80%D0%B0%D1%8F_%D1%81%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static T[] Sort<T>(T[] arr, int left, int right) where T : struct, System.IComparable<T>
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                Sort(arr, left, pivot);
                Sort(arr, pivot + 1, right);
            }

            return arr;
        }

        public static int[] SortDesc(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = PartitionDesc(arr, left, right);

                SortDesc(arr, left, pivot);
                SortDesc(arr, pivot + 1, right);
            }

            return arr;
        }

        private static int PartitionDesc(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                while (arr[left] > pivot)
                {
                    left++;
                }

                while (arr[right] < pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    int tmp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = tmp;

                    left++;
                    right--;
                }
                else
                {
                    return right;
                }
            }
        }

        private static int Partition<T>(T[] arr, int left, int right) where T : struct, System.IComparable<T>
        {
            T pivot = arr[left];
            while (true)
            {
                while (arr[left].CompareTo(pivot) < 0)
                {
                    left++;
                }

                while (arr[right].CompareTo(pivot) > 0)
                {
                    right--;
                }

                if (left < right)
                {
                    T tmp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = tmp;

                    left++;
                    right--;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
