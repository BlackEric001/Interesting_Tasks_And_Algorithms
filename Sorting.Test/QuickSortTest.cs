using System;
using System.Linq;
using Xunit;

namespace Sorting.Test
{
    public class QuickSortTest
    {
        [Fact]
        public void TestNull()
        {
            var res = QuickSort.Sort(null, 0, 0);

            Assert.Null(res);
        }

        [Theory]
        [InlineData(new int[] { })]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 1, 2, 3})]
        [InlineData(new int[] { 1, 1, 1 })]
        [InlineData(new int[] { 3, 2, 3 })]
        [InlineData(new int[] { 3, 2, 1 })]
        [InlineData(new int[] { 1, 2, 3, 1 })]
        [InlineData(new int[] { -1, 123, 5, 7, 4000, 8, 567, 987, 311, 900, 0, -1 })]
        [InlineData(new int[] { -1, 123, 5, 7, 4000, 8, 567, 987, 311, 900, 0, -1, 311 })]
        public void Test(int[] arr)
        {
            var res = QuickSort.Sort((int[])arr.Clone(), 0, arr.Length - 1);

            Assert.Equal(arr.OrderBy(x => x), res);
        }
    }
}
