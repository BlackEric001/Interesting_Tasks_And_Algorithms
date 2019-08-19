using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    public class RadixSort
    {
        /// <summary>
        /// A utility function to get maximum value in arr[] 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static int GetMax(int[] arr)
        {
            int mx = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > mx)
                    mx = arr[i];
            }

            return mx;
        }

        /// <summary>
        /// A function to do counting sort of arr[] according to 
        /// the digit represented by exp. (e.g. 300 is represented by 100)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="exp"></param>
        private static void CountSort(int[] arr, int exp)
        {
            int[] output = new int[arr.Length]; // output array 
            int i;
            int[] count = new int[10];
            Array.Fill(count, 0);

            // Store count of occurrences in count[] 
            for (i = 0; i < arr.Length; i++)
                count[(arr[i] / exp) % 10]++;

            // Change count[i] so that count[i] now contains 
            // actual position of this digit in output[] 
            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build the output array 
            for (i = arr.Length - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now 
            // contains sorted numbers according to current digit 
            for (i = 0; i < arr.Length; i++)
                arr[i] = output[i];
        }

        /// <summary>
        /// The main function to that sorts array using Radix Sort 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] Sort(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return arr;

            // Find the maximum number to know number of digits 
            int m = GetMax(arr);

            // Do counting sort for every digit. Note that instead 
            // of passing digit number, exp is passed. exp is 10^i 
            // where i is current digit number 
            for (int exp = 1; m / exp > 0; exp *= 10)
                CountSort(arr, exp);

            return arr;
        }
    }
}
