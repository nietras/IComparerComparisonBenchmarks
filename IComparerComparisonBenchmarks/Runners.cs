using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace IComparerComparisonBenchmarks
{
    public static class Runners<T>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int RunIComparer(T pivot, T[] items, IComparer<T> comparer)
        {
            int sum = 0;
            for (int i = 0; i < items.Length; i++)
            {
                sum += comparer.Compare(pivot, items[i]);
            }
            return sum;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int RunComparer(T pivot, T[] items, Comparer<T> comparer)
        {
            int sum = 0;
            for (int i = 0; i < items.Length; i++)
            {
                sum += comparer.Compare(pivot, items[i]);
            }
            return sum;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int RunComparison(T pivot, T[] items, Comparison<T> comparison)
        {
            int sum = 0;
            for (int i = 0; i < items.Length; i++)
            {
                sum += comparison(pivot, items[i]);
            }
            return sum;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int RunTComparer<TComparer>(T pivot, T[] items, TComparer comparer) 
            where TComparer : IComparer<T>
        {
            int sum = 0;
            for (int i = 0; i < items.Length; i++)
            {
                sum += comparer.Compare(pivot, items[i]);
            }
            return sum;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int RunTComparerObject<TComp>(T pivot, T[] items, TComp comparer)
            where TComp : IComparer<object>
        {
            int sum = 0;
            for (int i = 0; i < items.Length; i++)
            {
                sum += comparer.Compare(pivot, items[i]);
            }
            return sum;
        }
    }
}
