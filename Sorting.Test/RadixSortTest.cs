using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Sorting.Test
{
    public class RadixSortTest
    {
        [Fact]
        public void TestNullL()
        {
            var res = RadixSort.SortL(null);

            Assert.Null(res);
        }

        [Fact]
        public void TestNullInt()
        {
            var res = RadixSort.SortInt(null);

            Assert.Null(res);
        }

        [Theory]
        [InlineData(new long[] { })]
        [InlineData(new long[] { 1 })]
        [InlineData(new long[] { long.MaxValue, 1, 2, 3, long.MinValue })]
        [InlineData(new long[] { 1, 1, 1 })]
        [InlineData(new long[] { 3, 2, int.MaxValue, 3 })]
        [InlineData(new long[] { 3, 2, 1 })]
        [InlineData(new long[] { 1, 2, 3, 1 })]
        [InlineData(new long[] { -1, 123, 5, 7, 4000, 8, 567, 987, 311, 900, 0, -1 })]
        [InlineData(new long[] { -1, 123, 5, 7, 4000, 8, 567, 987, 311, 900, 0, -1, 311 })]
        [InlineData(new long[] { 1, 5, 1, 2, 10, 6, 9, 8, 3, 7, 4 })]
        [InlineData(new long[] { 4, 4, 4, 4, 4, 4, 4, 3, 4, 4, 4, 4, 4, 4, 4, 4 })]
        public void TestL(long[] arr)
        {
            var res = RadixSort.SortL((long[])arr.Clone());

            Assert.Equal(arr.OrderBy(x => x), res);
        }

        [Theory]
        [InlineData(new int[] { })]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { int.MaxValue, 1, 2, 3, int.MinValue })]
        [InlineData(new int[] { 1, 1, 1 })]
        [InlineData(new int[] { 3, 2, int.MaxValue, 3 })]
        [InlineData(new int[] { 3, 2, 1 })]
        [InlineData(new int[] { 1, 2, 3, 1 })]
        [InlineData(new int[] { -1, 123, 5, 7, 4000, 8, 567, 987, 311, 900, 0, -1 })]
        [InlineData(new int[] { -1, 123, 5, 7, 4000, 8, 567, 987, 311, 900, 0, -1, 311 })]
        [InlineData(new int[] { 1, 5, 1, 2, 10, 6, 9, 8, 3, 7, 4 })]
        [InlineData(new int[] { 4, 4, 4, 4, 4, 4, 4, 3, 4, 4, 4, 4, 4, 4, 4, 4 })]
        public void TestInt(int[] arr)
        {
            var res = RadixSort.SortInt((int[])arr.Clone());

            Assert.Equal(arr.OrderBy(x => x), res);
        }
    }
}
