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
            var comparer = Comparer<string>.Default;
            var getCompareMethodPointer = Hacker.CreateGetComparerMethodPointer<string>();
            var methodPointer = getCompareMethodPointer(comparer);
            var openCompare = Hacker.OpenInstanceGenericDelegate_For_GenericInterfaceMethod<string>(methodPointer);

            var test0 = openCompare(comparer, "a", "a");
            var test1 = openCompare(comparer, "b", "a");
            var test2 = openCompare(comparer, "a", "b");

            Comparison<string> comparison = string.Compare;
            var asObjectComparison = Unsafe.As<Comparison<object>>(comparison);
            var t0 = asObjectComparison("a", "b");
            var t1 = asObjectComparison("b", "a");


            var summaryComparableClassInt32 = BenchmarkRunner.Run<ComparerComparisonBenchmarkComparableClassInt32>();
            var summaryInt = BenchmarkRunner.Run<ComparerComparisonBenchmarkInt>();
            //var summaryString = BenchmarkRunner.Run<ComparerComparisonBenchmarkString>();
        }
    }

    public static class Hacker
    {
        public class SomeType
        {
            public virtual void DoNothing<T>()
            {
                Console.WriteLine(typeof(T));
            }
        }

        public abstract class MyAction
        {
            public abstract void Invoke(SomeType type);
        }
        public static Func<IComparer<T>, IntPtr> CreateGetComparerMethodPointer<T>()
        {
            MethodInfo method = typeof(IComparer<T>)
                .GetMethod("Compare", new Type[] { typeof(T), typeof(T) });

            var dynamicMethod = new DynamicMethod("Ldvirtftn",
                typeof(IntPtr), new Type[] { typeof(IComparer<T>) }, typeof(Hacker).Module);
            var il = dynamicMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);            // object
            il.Emit(OpCodes.Ldvirtftn, method);  // IntPtr method pointer
            il.Emit(OpCodes.Ret);                // Method pointer

            var del = (Func<IComparer<T>, IntPtr>)dynamicMethod.CreateDelegate(typeof(Func<IComparer<T>, IntPtr>));
            return del;
        }

        public static Func<IComparer<T>, T, T, int> OpenInstanceGenericDelegate_For_GenericInterfaceMethod<T>(IntPtr methodPointer)
        {
            var parameterTypes = new Type[] { typeof(IComparer<T>), typeof(T), typeof(T) };
            var dynamicMethod = new DynamicMethod("calli",
                typeof(int), parameterTypes, typeof(Hacker).Module);
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
            //var dynamicMethod = new DynamicMethod("Mutate",
            //typeof(void), new Type[] { typeof(object), typeof(T) }, typeof(Hacker).Module);
            //var il = dynamicMethod.GetILGenerator();
            //il.Emit(OpCodes.Ldarg_0);           // object
            //il.Emit(OpCodes.Unbox, typeof(T));  // T&
            //il.Emit(OpCodes.Ldarg_1);           // T& + T (argument value)
            //il.Emit(OpCodes.Stobj, typeof(T));  // empty
            //il.Emit(OpCodes.Ret);               // empty

            //var del = (Action<object, T>)dynamicMethod.CreateDelegate(typeof(Action<object, T>));
            //return del;


            //var assemblyName = new AssemblyName(Guid.NewGuid().ToString());
            //var assemblyBuilder = AssemblyBuilder
            //    .DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            // https://stackoverflow.com/questions/7136615/open-delegate-for-generic-interface-method
            //TypeBuilder builder = AppDomain.CurrentDomain
            //.DefineDynamicAssembly(new AssemblyName(MethodBase.GetCurrentMethod().DeclaringType.Name),
            //                       AssemblyBuilderAccess.RunAndCollect)
            //.DefineDynamicModule("Module").DefineType("MyType",
            //                                  TypeAttributes.AnsiClass | TypeAttributes.AutoClass | TypeAttributes.Class |
            //                                  TypeAttributes.Public | TypeAttributes.Sealed,
            //                                  typeof(MyAction));
            //var ilgen = builder.DefineMethod("Invoke",
            //                                 MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Final |
            //                                 MethodAttributes.Virtual,
            //                                 CallingConventions.HasThis,
            //                                 typeof(void), new[] { typeof(SomeType) }).GetILGenerator();
            //ilgen.Emit(OpCodes.Ldarg_1);
            //ilgen.Emit(OpCodes.Dup);
            //ilgen.Emit(OpCodes.Ldvirtftn, typeof(SomeType).GetMethod("DoNothing").MakeGenericMethod(typeof(int)));
            //ilgen.Emit(OpCodes.Calli, SignatureHelper.GetMethodSigHelper(CallingConventions.HasThis, typeof(void)));
            //ilgen.Emit(OpCodes.Ret);
            //MyAction action = Activator.CreateInstance(builder.CreateType()) as MyAction;
            //action.Invoke(new SomeType());
        }
    }
}
