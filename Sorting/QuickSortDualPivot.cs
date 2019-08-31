using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    /// <summary>
    /// https://www.geeksforgeeks.org/dual-pivot-quicksort/
    /// </summary>
    public class QuickSortDualPivot
    {
        public static T[] Sort<T>(T[] arr, int left, int right) where T : struct, System.IComparable<T>
        {
            if (left < right)
            {
                (int lpivot, int rpivot) = Partition(arr, left, right);

                Sort(arr, left, lpivot - 1);
                Sort(arr, lpivot + 1, rpivot - 1);
                Sort(arr, rpivot + 1, right);
            }

            return arr;
        }

        private static (int, int) Partition<T>(T[] arr, int left, int right) where T : struct, System.IComparable<T>
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
                    return (left, right);
                }
            }
        }
    }
}
