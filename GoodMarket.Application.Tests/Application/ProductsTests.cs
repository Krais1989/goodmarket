using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GoodMarket.Application.Tests.Application
{
    public class ProductsTests
    {
        private readonly ITestOutputHelper _output;

        public ProductsTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ReverseSortList()
        {
            var list = new LinkedList<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Print(list);
            ReverseLinkedList(list);
            Print(list);
        }

        private void Print<T>(IEnumerable<T> list)
        {
            var sb = new StringBuilder();
            foreach (var elem in list)
                sb.Append(" ").Append(elem);
            _output.WriteLine(sb.ToString());
        }

        private void ReverseLinkedList<T>(LinkedList<T> list)
        {
            foreach (var l in list)
            {
            }
        }
    }
}
