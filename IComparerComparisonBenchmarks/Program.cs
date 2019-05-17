using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
            //var getCompareMethodPointer = CompareHelper.CreateGetComparerMethodPointer<string>();
            //var methodPointer = getCompareMethodPointer(comparer);
            var openCompare = Comparisons<string>.OpenComparerDelegate; // CompareHelper.OpenInstanceGenericDelegate_For_GenericInterfaceMethod<string>(methodPointer);

            var comparer = Comparer<string>.Default;

            var test0 = openCompare(comparer, "a", "a");
            var test1 = openCompare(comparer, "b", "a");
            var test2 = openCompare(comparer, "a", "b");

            Comparison<string> comparison = string.Compare;
            var asObjectComparison = Unsafe.As<Comparison<object>>(comparison);
            var t0 = asObjectComparison("a", "b");
            var t1 = asObjectComparison("b", "a");

            var summaryComparableClassInt32 = BenchmarkRunner.Run<ComparerComparisonBenchmarkComparableClassInt32>();
            //var summaryInt = BenchmarkRunner.Run<ComparerComparisonBenchmarkInt>();
            //var summaryString = BenchmarkRunner.Run<ComparerComparisonBenchmarkString>();
        }
    }

    public static class Comparisons<T>
    {
        public static readonly Func<IComparer<T>, T, T, int> OpenComparerDelegate =
            CompareHelper.CreateOpenComparerDelegate<T>();
    }

    public static class CompareHelper
    {
        public static Func<IComparer<T>, T, T, int> CreateOpenComparerDelegate<T>()
        {
            var comparer = Comparer<T>.Default;
            var getCompareMethodPointer = CreateGetComparerMethodPointer<T>();
            var methodPointer = getCompareMethodPointer(comparer);
            var openCompare = OpenInstanceGenericDelegate_For_GenericInterfaceMethod<T>(methodPointer);
            return openCompare;
        }

        public static Func<IComparer<T>, IntPtr> CreateGetIComparerMethodPointer<T>()
        {
            MethodInfo method = typeof(IComparer<T>)
                .GetMethod("Compare", new Type[] { typeof(T), typeof(T) });

            var dynamicMethod = new DynamicMethod("Ldvirtftn",
                typeof(IntPtr), new Type[] { typeof(IComparer<T>) }, typeof(CompareHelper).Module);
            var il = dynamicMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);            // object
            il.Emit(OpCodes.Ldvirtftn, method);  // IntPtr method pointer
            il.Emit(OpCodes.Ret);                // Method pointer

            var del = (Func<IComparer<T>, IntPtr>)dynamicMethod.CreateDelegate(typeof(Func<IComparer<T>, IntPtr>));
            return del;
        }

        public static Func<Comparer<T>, IntPtr> CreateGetComparerMethodPointer<T>()
        {
            MethodInfo method = typeof(Comparer<T>)
                .GetMethod("Compare", new Type[] { typeof(T), typeof(T) });

            var dynamicMethod = new DynamicMethod("Ldvirtftn",
                typeof(IntPtr), new Type[] { typeof(Comparer<T>) }, typeof(CompareHelper).Module);
            var il = dynamicMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);            // object
            il.Emit(OpCodes.Ldvirtftn, method);  // IntPtr method pointer
            il.Emit(OpCodes.Ret);                // Method pointer

            var del = (Func<Comparer<T>, IntPtr>)dynamicMethod.CreateDelegate(typeof(Func<Comparer<T>, IntPtr>));
            return del;
        }

        public static Func<IComparer<T>, T, T, int> OpenInstanceGenericDelegate_For_GenericInterfaceMethod<T>(IntPtr methodPointer)
        {
            var parameterTypes = new Type[] { typeof(IComparer<T>), typeof(T), typeof(T) };
            var dynamicMethod = new DynamicMethod("calli",
                typeof(int), parameterTypes, typeof(CompareHelper).Module);
            var il = dynamicMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);            // comparer
            il.Emit(OpCodes.Ldarg_1);            // T
            il.Emit(OpCodes.Ldarg_2);            // T
            il.Emit(OpCodes.Ldc_I8, (long)methodPointer);
            il.Emit(OpCodes.Conv_I);
            il.EmitCalli(OpCodes.Calli, CallingConventions.HasThis, 
                typeof(int), new Type[] { typeof(T), typeof(T) }, null);
            //il.Emit(OpCodes.Calli);              // 
            il.Emit(OpCodes.Ret);                // 

            var del = (Func<IComparer<T>, T, T, int>)dynamicMethod.CreateDelegate(typeof(Func<IComparer<T>, T, T, int>));
            return del;
            // https://stackoverflow.com/questions/7136615/open-delegate-for-generic-interface-method
        }
    }
}
