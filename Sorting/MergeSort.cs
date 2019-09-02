using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    /// <summary>
    /// https://ru.wikipedia.org/wiki/%D0%A1%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0_%D1%81%D0%BB%D0%B8%D1%8F%D0%BD%D0%B8%D0%B5%D0%BC
    /// </summary>
    public class MergeSort
    {
        public static T[] Sort<T>(T[] arr, int low, int high) where T : struct, System.IComparable<T>
        {
            if (low >= high)
            {
                return arr;
            }

            int mid = (low + high) / 2;
            Sort(arr, low, mid);
            Sort(arr, mid + 1, high);

            Merge(arr, low, mid, high, () => 1);

            return arr;
        }

        private static void Merge<T>(T[] a, int low, int mid, int high, Func<int> c) where T : struct, System.IComparable<T>
        {
            T[] temp = new T[high - low + 1];

            int i = low;
            int j = mid + 1;
            int n = 0;

            while (i <= mid || j <= high)
            {
                if (i > mid)
                {
                    temp[n] = a[j];
                    j++;
                }
                else
                if (j > high)
                {
                    temp[n] = a[i];
                    i++;
                }
                else
                if ( c() == -1 ? a[i].CompareTo(a[j]) > 0 : a[i].CompareTo(a[j]) < 0)
                {
                    temp[n] = a[i];
                    i++;
                }
                else
                {
                    temp[n] = a[j];
                    j++;
                }
                n++;
            }

            for (int k = low; k <= high; k++)
            {
                a[k] = temp[k - low];
            }
        }

        public static T[] SortDesc<T>(T[] arr, int low, int high) where T : struct, System.IComparable<T>
        {
            if (low >= high)
            {
                return arr;
            }

            int mid = (low + high) / 2;
            SortDesc(arr, low, mid);
            SortDesc(arr, mid + 1, high);

            Merge(arr, low, mid, high, () => -1);

            return arr;
        }
    }
}
