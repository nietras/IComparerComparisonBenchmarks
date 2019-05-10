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

            var summary = BenchmarkRunner.Run<ComparerComparisonBenchmarkInt>();
        }
    }
}
