using System;
using System.Collections.Generic;
using System.Reflection;
using BenchmarkDotNet.Running;

namespace IComparerComparisonBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summaryComparableClassInt32 = BenchmarkRunner.Run<ComparerComparisonBenchmarkComparableClassInt32>();
            var summaryInt = BenchmarkRunner.Run<ComparerComparisonBenchmarkInt>();
            //var summaryString = BenchmarkRunner.Run<ComparerComparisonBenchmarkString>();
        }
    }
}
