``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.437 (1809/October2018Update/Redstone5)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.0.100-preview-009812
  [Host]     : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT


```
|                         Method |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|   Comparison_FromCompareToOpen | 299.94 ns |  6.520 ns |  5.780 ns |  0.53 |    0.01 |      - |     - |     - |         - |
|                      IComparer | 565.13 ns |  2.313 ns |  1.932 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                       Comparer | 412.30 ns |  8.117 ns | 10.554 ns |  0.72 |    0.02 |      - |     - |     - |         - |
|            TComparer_TComparer |  97.98 ns |  1.983 ns |  2.204 ns |  0.17 |    0.00 |      - |     - |     - |         - |
|            TComparer_IComparer | 540.01 ns |  8.191 ns |  7.662 ns |  0.96 |    0.01 |      - |     - |     - |         - |
|             TComparer_Comparer | 550.02 ns |  3.565 ns |  3.335 ns |  0.97 |    0.01 |      - |     - |     - |         - |
|           TComparer_Comparable | 578.65 ns |  8.345 ns |  7.806 ns |  1.02 |    0.01 |      - |     - |     - |         - |
|       Comparison_FromIComparer | 411.88 ns |  8.177 ns | 11.193 ns |  0.73 |    0.02 |      - |     - |     - |         - |
|        Comparison_FromComparer | 411.64 ns |  7.854 ns |  8.404 ns |  0.73 |    0.02 |      - |     - |     - |         - |
| Comparison_CreateFromIComparer | 603.10 ns |  4.560 ns |  4.266 ns |  1.07 |    0.01 | 0.0095 |     - |     - |      64 B |
|  Comparison_CreateFromComparer | 595.37 ns | 10.105 ns |  9.453 ns |  1.05 |    0.02 | 0.0095 |     - |     - |      64 B |
