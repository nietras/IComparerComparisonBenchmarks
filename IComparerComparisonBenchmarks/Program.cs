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
            // https://stackoverflow.com/questions/7136615/open-delegate-for-generic-interface-method
            // 
            //MethodInfo method = typeof(IComparer<string>)
            //    .GetMethod("Compare", new Type[] { typeof(string), typeof(string) });
            //var openCompare = (Func<IComparer<string>, string, string, bool>)
            //    Delegate.CreateDelegate(typeof(Func<IComparer<string>, string, string, bool>), null, method);

            var summaryComparableClassInt32 = BenchmarkRunner.Run<ComparerComparisonBenchmarkComparableClassInt32>();
            var summaryInt = BenchmarkRunner.Run<ComparerComparisonBenchmarkInt>();
            //var summaryString = BenchmarkRunner.Run<ComparerComparisonBenchmarkString>();
        }
    }
}
