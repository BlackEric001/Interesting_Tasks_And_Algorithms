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
            var res = QuickSort.Sort((decimal[])null, 0, 0);

            Assert.Null(res);
        }

        [Theory]
        [InlineData(new int[] { })]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 1, 2, 3})]
        [InlineData(new int[] { 1, 1, 1 })]
        [InlineData(new int[] { 3, 2, 3 })]
        [InlineData(new float[] { 3, 2, 1 })]
        [InlineData(new double[] { 1.0, 2.0, 3.0, 1.0 })]
        [InlineData(new double[] { -1.0, 123.0, 5.0, 7.1, 4000.1, 8.1, 567.1, 987.1, 311.1, 900.1, 0.1, -1.1 })]
        [InlineData(new int[] { -1, 123, 5, 7, 4000, 8, 567, 987, 311, 900, 0, -1, 311 })]
        [InlineData(new int[] { 1, 5, 1, 2, 10, 6, 9, 8, 3, 7, 4 })]
        [InlineData(new Int64[] { 4, 4, 4, 4, 4, 4, 4, 3, 4, 4, 4, 4, 4, 4, 4, 4 })]
        public void Test<T>(T[] arr) where T: struct, IComparable<T>
        {
            var res = QuickSort.Sort((T[])arr.Clone(), 0, arr.Length - 1);

            Assert.Equal(arr.OrderBy(x => x), res);
        }

        [Fact]
        public void TestDecimal()
        {
            decimal[] arr = new decimal[] { 1.1m, 2.1m, -22.2344455m};
            var res = QuickSort.Sort((decimal[])arr.Clone(), 0, arr.Length - 1);

            Assert.Equal(arr.OrderBy(x => x), res);
        }
    }
}
