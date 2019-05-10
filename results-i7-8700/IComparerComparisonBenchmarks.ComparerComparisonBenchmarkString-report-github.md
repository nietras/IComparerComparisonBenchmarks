``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.437 (1809/October2018Update/Redstone5)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.0.100-preview-009812
  [Host]     : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT


```
|                         Method |     Mean |     Error |    StdDev | Ratio | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |---------:|----------:|----------:|------:|------:|------:|------:|----------:|
|   Comparison_FromCompareToOpen | 7.431 us | 0.0120 us | 0.0112 us |  0.99 |     - |     - |     - |         - |
|                      IComparer | 7.471 us | 0.0089 us | 0.0084 us |  1.00 |     - |     - |     - |         - |
|                       Comparer | 7.632 us | 0.0082 us | 0.0077 us |  1.02 |     - |     - |     - |         - |
|            TComparer_TComparer | 7.610 us | 0.0102 us | 0.0096 us |  1.02 |     - |     - |     - |         - |
|            TComparer_IComparer | 7.476 us | 0.0411 us | 0.0385 us |  1.00 |     - |     - |     - |         - |
|             TComparer_Comparer | 7.593 us | 0.0023 us | 0.0021 us |  1.02 |     - |     - |     - |         - |
|           TComparer_Comparable | 7.408 us | 0.0097 us | 0.0091 us |  0.99 |     - |     - |     - |         - |
|       Comparison_FromIComparer | 7.529 us | 0.0056 us | 0.0050 us |  1.01 |     - |     - |     - |         - |
|        Comparison_FromComparer | 7.667 us | 0.0857 us | 0.0802 us |  1.03 |     - |     - |     - |         - |
| Comparison_CreateFromIComparer | 7.590 us | 0.0198 us | 0.0165 us |  1.02 |     - |     - |     - |      64 B |
|  Comparison_CreateFromComparer | 7.580 us | 0.0086 us | 0.0076 us |  1.01 |     - |     - |     - |      64 B |
