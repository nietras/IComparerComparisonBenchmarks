using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace IComparerComparisonBenchmarks
{
    public delegate int OpenComparison<T>(ref T x, T y) where T : struct;

    public readonly struct IntTComparer : IComparer<int>
    {
        public int Compare(int x, int y) => x.CompareTo(y);
    }

    public class ComparerComparisonBenchmarkInt : ComparerComparisonBenchmark<int, IntTComparer>
    {
        // For value types we do not actually needed the open one
        // and these do not match the Comparison<T> signature due to `ref`
        // https://stackoverflow.com/questions/4326736/how-can-i-create-an-open-delegate-from-a-structs-instance-method?rq=1
        public static OpenComparison<int> m_openComparisonFromCompareToOpen = (OpenComparison<int>)
            Delegate.CreateDelegate(
                typeof(OpenComparison<int>),
                typeof(int).GetMethod("CompareTo", new Type[] { typeof(int) })
            );

        public ComparerComparisonBenchmarkInt()
            : base(new IntTComparer())
        {
            m_pivot = m_random.Next(-20, 20);
            m_array = Enumerable.Range(0, 100).Select(_ => m_random.Next(-100, 100)).ToArray();
        }

        [Benchmark()]
        public int OpenComparison_FromCompareTo() => RunOpenComparison(m_openComparisonFromCompareToOpen);

        int RunOpenComparison(OpenComparison<int> openComparison)
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                int value = m_pivot;
                sum += openComparison(ref value, m_array[i]);
            }
            return sum;
        }
    }

    [MemoryDiagnoser]
    public abstract class ComparerComparisonBenchmark<T, TComparer>
        where TComparer : IComparer<T>
    {
        protected static readonly Random m_random = new Random(42);

        readonly IComparer<T> m_icomparer = Comparer<T>.Default;
        readonly Comparer<T> m_comparer = Comparer<T>.Default;
        readonly Comparison<T> m_comparisonFromIComparer;
        readonly Comparison<T> m_comparisonFromComparer;
        readonly TComparer m_tcomparer;

        //var stringCompareToMethodInfo = typeof(string).GetMethod("CompareTo", new Type[] { typeof(string) });
        //var open = (Func<string, string, T>)
        //    Delegate.CreateDelegate(typeof(Func<string, string, T>), stringCompareToMethodInfo);

        protected T m_pivot;
        protected T[] m_array;

        public ComparerComparisonBenchmark(TComparer tcomparer)
        {
            m_comparisonFromIComparer = m_icomparer.Compare;
            m_comparisonFromComparer = m_comparer.Compare;
            m_tcomparer = tcomparer;
        }

        [Benchmark(Baseline = true)]
        public int IComparer() => RunIComparer(m_icomparer);

        [Benchmark()]
        public int Comparer() => RunComparer(m_comparer);

        [Benchmark()]
        public int TComparer_TComparer() => RunTComparer(m_tcomparer);

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

        int RunIComparer(IComparer<T> comparer)
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += comparer.Compare(m_pivot, m_array[i]);
            }
            return sum;
        }

        int RunComparer(Comparer<T> comparer)
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += comparer.Compare(m_pivot, m_array[i]);
            }
            return sum;
        }

        int RunComparison(Comparison<T> comparison)
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += comparison(m_pivot, m_array[i]);
            }
            return sum;
        }

        int RunTComparer<TComparer>(TComparer comparer)
            where TComparer : IComparer<T>
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += comparer.Compare(m_pivot, m_array[i]);
            }
            return sum;
        }
    }
}
