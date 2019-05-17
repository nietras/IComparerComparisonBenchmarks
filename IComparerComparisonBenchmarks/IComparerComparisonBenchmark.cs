using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;

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
            m_array = Enumerable.Range(0, Length).Select(_ => m_random.Next(-100, 100)).ToArray();
        }

        [Benchmark(OperationsPerInvoke = Length)]
        public int OpenComparison_FromCompareTo() => RunOpenComparison(m_openComparisonFromCompareToOpen);

        [MethodImpl(MethodImplOptions.NoInlining)]
        int RunOpenComparison(OpenComparison<int> openComparison)
        {
            var pivot = m_pivot;
            var local = m_array;
            int sum = 0;
            for (int i = 0; i < local.Length; i++)
            {
                int value = pivot;
                sum += openComparison(ref value, local[i]);
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

    public readonly struct OpenComparerDelegateObjectTComparer : IComparer<object>
    {
        readonly IComparer m_comparer;
        readonly Func<IComparer, object, object, int> m_compare;

        public OpenComparerDelegateObjectTComparer(
            IComparer comparer,
            Func<IComparer, object, object, int> compare)
        {
            m_comparer = comparer;
            m_compare = compare;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public int Compare(object x, object y) => m_compare(m_comparer, x, y);
    }

    public readonly struct ObjectComparisonTComparer : IComparer<object>
    {
        readonly Comparison<object> m_comparison;

        public ObjectComparisonTComparer(Comparison<object> comparison)
        {
            m_comparison = comparison;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public int Compare(object x, object y) => m_comparison(x, y);
    }

    public class ComparerComparisonBenchmarkComparableClassInt32 : ComparerComparisonBenchmark<ComparableClassInt32, ComparableClassInt32TComparer>
    {
        // TODO: We have to get it from the Comparer too
        static readonly Comparison<ComparableClassInt32> m_openComparisonFromCompareToOpen = (Comparison<ComparableClassInt32>)
            Delegate.CreateDelegate(
                typeof(Comparison<ComparableClassInt32>),
                typeof(ComparableClassInt32).GetMethod("CompareTo", new Type[] { typeof(ComparableClassInt32) }));

        static readonly Func<IComparer, object, object, int> m_openComparerObjectAsObject =
            Unsafe.As<Func<IComparer, object, object, int>>(Comparisons<ComparableClassInt32>.OpenComparerDelegate);

        static readonly ObjectComparisonTComparer m_objectComparisonTComparer = new ObjectComparisonTComparer(
            Unsafe.As<Comparison<object>>(Comparisons<ComparableClassInt32>.ComparisonForComparable));

        public ComparerComparisonBenchmarkComparableClassInt32()
            : base(new ComparableClassInt32TComparer())
        {
            m_pivot = new ComparableClassInt32(m_random.Next(-20, 20));
            m_array = Enumerable.Range(0, Length).Select(_ => new ComparableClassInt32(m_random.Next(-100, 100))).ToArray();
        }

        [Benchmark(OperationsPerInvoke = Length)]
        public int Comparison_FromCompareToOpen() => RunComparison(m_openComparisonFromCompareToOpen);

        [Benchmark(OperationsPerInvoke = Length)]
        public int ObjectComparisonTComparer_AsObject() =>
            RunTComparerObject(m_objectComparisonTComparer);

        [Benchmark(OperationsPerInvoke = Length)]
        public int OpenComparerDelegate_TComparer_AsObject() =>
            RunTComparerObject(new OpenComparerDelegateObjectTComparer(m_comparer, m_openComparerObjectAsObject));

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected int RunTComparerObject<TComp>(TComp comparer)
            where TComp : IComparer<object>
        {
            var pivot = m_pivot;
            var local = m_array;
            int sum = 0;
            for (int i = 0; i < local.Length; i++)
            {
                sum += comparer.Compare(pivot, local[i]);
            }
            return sum;
        }
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
            m_array = Enumerable.Range(0, Length).Select(_ => m_random.Next(100, 400).ToString("D3")).ToArray();
        }

        [Benchmark(OperationsPerInvoke = Length)]
        public int Comparison_FromCompareToOpen() => RunComparison(m_openComparisonFromCompareToOpen);
    }

    [MemoryDiagnoser]
    [DisassemblyDiagnoser(recursiveDepth: 3, printAsm: true, printIL: true, printSource: true)]
    [InliningDiagnoser]
    public abstract class ComparerComparisonBenchmark<T, TComparer>
        where TComparer : IComparer<T>
        where T : IComparable<T>
    {
        protected const int Length = 500;
        protected static readonly Random m_random = new Random(42);

        readonly IComparer<T> m_icomparer = Comparer<T>.Default;
        protected readonly Comparer<T> m_comparer = Comparer<T>.Default;
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

        [Benchmark(Baseline = true, OperationsPerInvoke = Length)]
        public int IComparer() => RunIComparer(m_icomparer);

        [Benchmark(OperationsPerInvoke = Length)]
        public int Comparer() => RunComparer(m_comparer);

        [Benchmark(OperationsPerInvoke = Length)]
        public int TComparer_TComparer() => RunTComparer(m_tcomparer);

        [Benchmark(OperationsPerInvoke = Length)]
        public int TComparer_IComparer() => RunTComparer(m_icomparer);

        [Benchmark(OperationsPerInvoke = Length)]
        public int TComparer_Comparer() => RunTComparer(m_comparer);

        [Benchmark(OperationsPerInvoke = Length)]
        public int TComparer_Comparable() => RunTComparer(m_comparableTComparer);

        [Benchmark(OperationsPerInvoke = Length)]
        public int ComparisonComparer_IComparer() => RunIComparer(m_comparisonComparer);

        [Benchmark(OperationsPerInvoke = Length)]
        public int ComparisonComparer_TComparer() => RunTComparer(m_comparisonTComparer);

        [Benchmark(OperationsPerInvoke = Length)]
        public int Comparison_FromIComparer() => RunComparison(m_comparisonFromIComparer);

        [Benchmark(OperationsPerInvoke = Length)]
        public int Comparison_FromComparer() => RunComparison(m_comparisonFromComparer);

        [Benchmark(OperationsPerInvoke = Length)]
        public int Comparison_CreateFromIComparer() => RunComparison(m_icomparer.Compare);

        [Benchmark(OperationsPerInvoke = Length)]
        public int Comparison_CreateFromComparer() => RunComparison(m_comparer.Compare);

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected int RunIComparer(IComparer<T> comparer)
        {
            var pivot = m_pivot;
            var local = m_array;
            int sum = 0;
            for (int i = 0; i < local.Length; i++)
            {
                sum += comparer.Compare(pivot, local[i]);
            }
            return sum;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected int RunComparer(Comparer<T> comparer)
        {
            var pivot = m_pivot;
            var local = m_array;
            int sum = 0;
            for (int i = 0; i < local.Length; i++)
            {
                sum += comparer.Compare(pivot, local[i]);
            }
            return sum;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected int RunComparison(Comparison<T> comparison)
        {
            var pivot = m_pivot;
            var local = m_array;
            int sum = 0;
            for (int i = 0; i < local.Length; i++)
            {
                sum += comparison(pivot, local[i]);
            }
            return sum;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected int RunTComparer<TComp>(TComp comparer)
            where TComp : IComparer<T>
        {
            var pivot = m_pivot;
            var local = m_array;
            int sum = 0;
            for (int i = 0; i < local.Length; i++)
            {
                sum += comparer.Compare(pivot, local[i]);
            }
            return sum;
        }
    }
}
