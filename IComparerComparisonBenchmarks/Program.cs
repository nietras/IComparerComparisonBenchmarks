using System;
using BenchmarkDotNet.Running;

namespace IComparerComparisonBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<IComparerComparisonBenchmark>();
        }
    }
}
