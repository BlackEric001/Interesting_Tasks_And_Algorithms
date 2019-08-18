using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Sorting.Test
{
    public class QuickSortDescTest
    {
        [Fact]
        public void TestNull()
        {
            var res = QuickSort.SortDesc(null, 0, 0);

            Assert.Null(res);
        }

        [Theory]
        [InlineData(new int[] {  })]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 1, 1, 1 })]
        [InlineData(new int[] { 3, 2, 3 })]
        [InlineData(new int[] { 3, 2, 1 })]
        [InlineData(new int[] { 1, 2, 3, 1 })]
        [InlineData(new int[] { -1, 123, 5, 7, 4000, 8, 567, 987, 311, 900, 0, -1 })]
        [InlineData(new int[] { -1, 123, 5, 7, 4000, 8, 567, 987, 311, 900, 0, -1, 311 })]
        [InlineData(new int[] { 1, 5, 1, 2, 10, 6, 9, 8, 3, 7, 4 })]
        [InlineData(new int[] { 4, 4, 4, 4, 4, 4, 4, 3, 4, 4, 4, 4, 4, 4, 4, 4 })]
        public void Test(int[] arr)
        {
            var res = QuickSort.SortDesc((int[])arr.Clone(), 0, arr.Length - 1);

            Assert.Equal(arr.OrderByDescending(x => x), res);
        }
    }
}
