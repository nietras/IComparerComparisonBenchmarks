``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.437 (1809/October2018Update/Redstone5)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.0.100-preview-009812
  [Host]     : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT


```
|                         Method |      Mean |     Error |     StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |----------:|----------:|-----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|   Comparison_FromCompareToOpen | 295.81 ns | 2.2349 ns |  1.8662 ns | 295.80 ns |  0.52 |    0.01 |      - |     - |     - |         - |
|                      IComparer | 570.22 ns | 6.6628 ns |  6.2324 ns | 568.19 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                       Comparer | 405.85 ns | 7.8728 ns |  9.9566 ns | 410.20 ns |  0.71 |    0.02 |      - |     - |     - |         - |
|            TComparer_TComparer |  95.74 ns | 0.5370 ns |  0.4761 ns |  95.75 ns |  0.17 |    0.00 |      - |     - |     - |         - |
|            TComparer_IComparer | 541.17 ns | 1.6367 ns |  1.5310 ns | 540.99 ns |  0.95 |    0.01 |      - |     - |     - |         - |
|             TComparer_Comparer | 550.60 ns | 3.2782 ns |  2.9060 ns | 550.83 ns |  0.97 |    0.01 |      - |     - |     - |         - |
|           TComparer_Comparable | 573.29 ns | 4.1964 ns |  3.7200 ns | 572.08 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|       Comparison_FromIComparer | 436.85 ns | 8.6082 ns | 12.3457 ns | 444.42 ns |  0.76 |    0.02 |      - |     - |     - |         - |
|        Comparison_FromComparer | 406.41 ns | 3.9844 ns |  3.7270 ns | 406.53 ns |  0.71 |    0.01 |      - |     - |     - |         - |
| Comparison_CreateFromIComparer | 647.24 ns | 6.5523 ns |  5.4715 ns | 648.91 ns |  1.13 |    0.02 | 0.0095 |     - |     - |      64 B |
|  Comparison_CreateFromComparer | 599.03 ns | 8.4911 ns |  7.9426 ns | 598.66 ns |  1.05 |    0.02 | 0.0095 |     - |     - |      64 B |
