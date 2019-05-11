using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
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
            //Hacker.OpenInstanceGenericDelegate_For_GenericInterfaceMethod();

            var summaryComparableClassInt32 = BenchmarkRunner.Run<ComparerComparisonBenchmarkComparableClassInt32>();
            var summaryInt = BenchmarkRunner.Run<ComparerComparisonBenchmarkInt>();
            //var summaryString = BenchmarkRunner.Run<ComparerComparisonBenchmarkString>();
        }
    }

    public static class Hacker
    {
        public static void OpenInstanceGenericDelegate_For_GenericInterfaceMethod<T>()
        {
            var dynamicMethod = new DynamicMethod("Mutate",
            typeof(void), new Type[] { typeof(object), typeof(T) }, typeof(Hacker).Module);
            var il = dynamicMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);           // object
            il.Emit(OpCodes.Unbox, typeof(T));  // T&
            il.Emit(OpCodes.Ldarg_1);           // T& + T (argument value)
            il.Emit(OpCodes.Stobj, typeof(T));  // empty
            il.Emit(OpCodes.Ret);               // empty

            var del = (Action<object, T>)dynamicMethod.CreateDelegate(typeof(Action<object, T>));
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
