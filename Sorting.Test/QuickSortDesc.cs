using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Sorting.Test
{
    public class QuickSortDesc
    {
        [Fact]
        public void TestNull()
        {
            var res = QuickSort.SortDesc(null, 0, 0);

            Assert.Null(res);
        }

        [Theory]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 1, 1, 1 })]
        [InlineData(new int[] { 3, 2, 3 })]
        [InlineData(new int[] { 3, 2, 1 })]
        [InlineData(new int[] { 1, 2, 3, 1 })]
        [InlineData(new int[] { -1, 123, 5, 7, 4000, 8, 567, 987, 311, 900, 0, -1 })]
        [InlineData(new int[] { -1, 123, 5, 7, 4000, 8, 567, 987, 311, 900, 0, -1, 311 })]
        public void Test(int[] arr)
        {
            var res = QuickSort.SortDesc((int[])arr.Clone(), 0, arr.Length - 1);

            Assert.Equal(arr.OrderByDescending(x => x), res);
        }
    }
}
