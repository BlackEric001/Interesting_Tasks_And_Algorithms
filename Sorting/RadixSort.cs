using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sorting
{
    public class RadixSort
    {
        public static long[] SortL(long[] arr)
        {
            if (arr == null || arr.Length == 0)
                return arr;

            int i, j;
            var tmp = new long[arr.Length];
            for (int shift = sizeof(long)*8 - 1; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < arr.Length; ++i)
                {
                    var move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        arr[i - j] = arr[i];
                    else
                        tmp[j++] = arr[i];
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);
            }

            return arr;
        }        
    }
}
