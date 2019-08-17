using System;
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
        [InlineData(new int[]{1, 2, 3})]
        public void Test(int[] arr)
        {
            var res = QuickSort.Sort(arr, 0, arr.Length - 1);

            Assert.Equal(new int[] { 1, 2, 3}, res);
        }
    }
}
