using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace IComparerComparisonBenchmarks
{
    [MemoryDiagnoser]
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
        public int IComparer() => RunIComparer(m_icomparer);

        [Benchmark()]
        public int Comparer() => RunComparer(m_comparer);

        [Benchmark()]
        public int TComparer_IntComparer() => RunTComparer(new IntComparer());

        [Benchmark()]
        public int TComparer_IComparer() => RunTComparer(m_icomparer);

        [Benchmark()]
        public int TComparer_Comparer() => RunTComparer(m_comparer);

        [Benchmark()]
        public int Comparison_FromIComparer() => RunComparison(m_comparisonFromIComparer);

        [Benchmark()]
        public int Comparison_FromComparer() => RunComparison(m_comparisonFromComparer);

        [Benchmark()]
        public int Comparison_CreateFromIComparer() => RunComparison(m_icomparer.Compare);

        [Benchmark()]
        public int Comparison_CreateFromComparer() => RunComparison(m_comparer.Compare);

        int RunIComparer(IComparer<int> comparer)
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += comparer.Compare(0, m_array[i]);
            }
            return sum;
        }

        int RunComparer(Comparer<int> comparer)
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += comparer.Compare(0, m_array[i]);
            }
            return sum;
        }

        int RunComparison(Comparison<int> comparison)
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += comparison(0, m_array[i]);
            }
            return sum;
        }

        int RunTComparer<TComparer>(TComparer comparer)
            where TComparer : IComparer<int>
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += comparer.Compare(0, m_array[i]);
            }
            return sum;
        }

        readonly struct IntComparer : IComparer<int>
        {
            public int Compare(int x, int y) => x.CompareTo(y);
        }
    }
}
