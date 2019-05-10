using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace IComparerComparisonBenchmarks
{
    //[CoreJob]
    public class IComparerComparisonBenchmark
    {
        static readonly Random m_random = new Random(42);
        readonly int[] m_array = Enumerable.Range(0, 100).Select(_ => m_random.Next(-100, 100)).ToArray();

        readonly IComparer<int> m_icomparer = Comparer<int>.Default;
        readonly Comparer<int> m_comparer = Comparer<int>.Default;
        readonly Comparison<int> m_comparisonFromIComparer;
        readonly Comparison<int> m_comparisonFromComparer;

        public IComparerComparisonBenchmark()
        {
            m_comparisonFromIComparer = m_icomparer.Compare;
            m_comparisonFromComparer = m_comparer.Compare;
        }

        [Benchmark(Baseline = true)]
        public int IComparer()
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += m_icomparer.Compare(0, m_array[i]);
            }
            return sum;
        }

        [Benchmark()]
        public int Comparer()
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += m_comparer.Compare(0, m_array[i]);
            }
            return sum;
        }

        [Benchmark()]
        public int Comparison_FromIComparer()
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += m_comparisonFromIComparer(0, m_array[i]);
            }
            return sum;
        }

        [Benchmark()]
        public int Comparison_FromComparer()
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += m_comparisonFromComparer(0, m_array[i]);
            }
            return sum;
        }
    }
}
