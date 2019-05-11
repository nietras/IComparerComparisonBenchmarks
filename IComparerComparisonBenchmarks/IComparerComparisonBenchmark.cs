﻿using System;
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

    public class ComparableClassInt32 : IComparable<ComparableClassInt32>
    {
        public readonly int Value;

        public ComparableClassInt32(int value)
        {
            Value = value;
        }

        public int CompareTo(ComparableClassInt32 other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }

    public readonly struct ComparableClassInt32TComparer : IComparer<ComparableClassInt32>
    {
        public int Compare(ComparableClassInt32 x, ComparableClassInt32 y) => x.CompareTo(y);
    }

    public class ComparerComparisonBenchmarkComparableClassInt32 : ComparerComparisonBenchmark<ComparableClassInt32, ComparableClassInt32TComparer>
    {
        // TODO: We have to get it from the Comparer too
        static readonly Comparison<ComparableClassInt32> m_openComparisonFromCompareToOpen = (Comparison<ComparableClassInt32>)
            Delegate.CreateDelegate(
                typeof(Comparison<ComparableClassInt32>),
                typeof(ComparableClassInt32).GetMethod("CompareTo", new Type[] { typeof(ComparableClassInt32) }));

        public ComparerComparisonBenchmarkComparableClassInt32()
            : base(new ComparableClassInt32TComparer())
        {
            m_pivot = new ComparableClassInt32(m_random.Next(-20, 20));
            m_array = Enumerable.Range(0, 100).Select(_ => new ComparableClassInt32(m_random.Next(-100, 100))).ToArray();
        }

        [Benchmark()]
        public int Comparison_FromCompareToOpen() => RunComparison(m_openComparisonFromCompareToOpen);
    }

    public readonly struct StringTComparer : IComparer<string>
    {
        public int Compare(string x, string y) => x.CompareTo(y);
    }

    public readonly struct ComparableTComparer<T> 
        : IComparer<T>
        where T : IComparable<T>
    {
        public int Compare(T x, T y) => x.CompareTo(y);
    }

    public readonly struct ComparisonTComparer<T>
        : IComparer<T>
        where T : IComparable<T>
    {
        readonly Comparison<T> m_comparison;

        public ComparisonTComparer(Comparison<T> comparison)
        {
            m_comparison = comparison;
        }

        public int Compare(T x, T y) => m_comparison(x, y);
    }

    public sealed class ComparisonComparer<T>
        : IComparer<T>
        where T : IComparable<T>
    {
        readonly Comparison<T> m_comparison;

        public ComparisonComparer(Comparison<T> comparison)
        {
            m_comparison = comparison;
        }

        public int Compare(T x, T y) => m_comparison(x, y);
    }

    public class ComparerComparisonBenchmarkString : ComparerComparisonBenchmark<string, StringTComparer>
    {
        // TODO: We have to get it from the Comparer too
        static readonly Comparison<string> m_openComparisonFromCompareToOpen = (Comparison<string>)
            Delegate.CreateDelegate(
                typeof(Comparison<string>), 
                typeof(string).GetMethod("CompareTo", new Type[] { typeof(string) }));

        public ComparerComparisonBenchmarkString()
            : base(new StringTComparer())
        {
            m_pivot = m_random.Next(200, 300).ToString("D3");
            m_array = Enumerable.Range(0, 100).Select(_ => m_random.Next(100, 400).ToString("D3")).ToArray();
        }

        [Benchmark()]
        public int Comparison_FromCompareToOpen() => RunComparison(m_openComparisonFromCompareToOpen);
    }

    [MemoryDiagnoser]
    [DisassemblyDiagnoser(recursiveDepth: 2)]
    public abstract class ComparerComparisonBenchmark<T, TComparer>
        where TComparer : IComparer<T>
        where T : IComparable<T>
    {
        protected static readonly Random m_random = new Random(42);

        readonly IComparer<T> m_icomparer = Comparer<T>.Default;
        readonly Comparer<T> m_comparer = Comparer<T>.Default;
        readonly Comparison<T> m_comparisonFromIComparer;
        readonly Comparison<T> m_comparisonFromComparer;
        readonly ComparisonComparer<T> m_comparisonComparer;
        readonly ComparisonTComparer<T> m_comparisonTComparer;
        readonly TComparer m_tcomparer;
        readonly ComparableTComparer<T> m_comparableTComparer = new ComparableTComparer<T>();


        protected T m_pivot;
        protected T[] m_array;

        public ComparerComparisonBenchmark(TComparer tcomparer)
        {
            m_comparisonFromIComparer = m_icomparer.Compare;
            m_comparisonFromComparer = m_comparer.Compare;
            m_comparisonComparer = new ComparisonComparer<T>(m_comparisonFromComparer);
            m_comparisonTComparer = new ComparisonTComparer<T>(m_comparisonFromComparer);
            m_tcomparer = tcomparer;
        }

        [Benchmark(Baseline = true)]
        public int IComparer() => RunIComparer(m_icomparer);

        [Benchmark()]
        public int Comparer() => RunComparer(m_comparer);

        [Benchmark()]
        public int ComparisonComparer() => RunComparer(m_comparer);

        [Benchmark()]
        public int TComparer_TComparer() => RunTComparer(m_tcomparer);

        [Benchmark()]
        public int TComparer_IComparer() => RunTComparer(m_icomparer);

        [Benchmark()]
        public int TComparer_Comparer() => RunTComparer(m_comparer);

        [Benchmark()]
        public int TComparer_Comparable() => RunTComparer(m_comparableTComparer);

        [Benchmark()]
        public int ComparisonComparer_IComparer() => RunIComparer(m_comparisonComparer);

        [Benchmark()]
        public int ComparisonComparer_TComparer() => RunTComparer(m_comparisonTComparer);

        [Benchmark()]
        public int Comparison_FromIComparer() => RunComparison(m_comparisonFromIComparer);

        [Benchmark()]
        public int Comparison_FromComparer() => RunComparison(m_comparisonFromComparer);

        [Benchmark()]
        public int Comparison_CreateFromIComparer() => RunComparison(m_icomparer.Compare);

        [Benchmark()]
        public int Comparison_CreateFromComparer() => RunComparison(m_comparer.Compare);

        protected int RunIComparer(IComparer<T> comparer)
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += comparer.Compare(m_pivot, m_array[i]);
            }
            return sum;
        }

        protected int RunComparer(Comparer<T> comparer)
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += comparer.Compare(m_pivot, m_array[i]);
            }
            return sum;
        }

        protected int RunComparison(Comparison<T> comparison)
        {
            int sum = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                sum += comparison(m_pivot, m_array[i]);
            }
            return sum;
        }

        protected int RunTComparer<TComp>(TComp comparer)
            where TComp : IComparer<T>
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
