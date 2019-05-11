``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.437 (1809/October2018Update/Redstone5)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.0.100-preview-009812
  [Host]     : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT


```
|                         Method |      Mean |     Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |----------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|   Comparison_FromCompareToOpen | 301.78 ns | 7.4012 ns |  7.6005 ns |  0.54 |    0.01 |      - |     - |     - |         - |
|                      IComparer | 559.65 ns | 4.2414 ns |  3.7599 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                       Comparer | 408.97 ns | 8.1018 ns | 12.8503 ns |  0.72 |    0.03 |      - |     - |     - |         - |
|            TComparer_TComparer |  96.32 ns | 1.3409 ns |  1.1887 ns |  0.17 |    0.00 |      - |     - |     - |         - |
|            TComparer_IComparer | 551.50 ns | 1.2216 ns |  1.1427 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|             TComparer_Comparer | 549.33 ns | 4.6896 ns |  4.3867 ns |  0.98 |    0.01 |      - |     - |     - |         - |
|           TComparer_Comparable | 591.81 ns | 5.0977 ns |  4.5190 ns |  1.06 |    0.01 |      - |     - |     - |         - |
|   ComparisonComparer_IComparer | 604.11 ns | 4.6548 ns |  4.3541 ns |  1.08 |    0.01 |      - |     - |     - |         - |
|   ComparisonComparer_TComparer | 686.06 ns | 1.8991 ns |  1.6835 ns |  1.23 |    0.01 |      - |     - |     - |         - |
|       Comparison_FromIComparer | 452.56 ns | 0.8230 ns |  0.7698 ns |  0.81 |    0.01 |      - |     - |     - |         - |
|        Comparison_FromComparer | 410.48 ns | 7.5514 ns | 10.5860 ns |  0.73 |    0.02 |      - |     - |     - |         - |
| Comparison_CreateFromIComparer | 592.26 ns | 8.6422 ns |  8.0839 ns |  1.06 |    0.02 | 0.0095 |     - |     - |      64 B |
|  Comparison_CreateFromComparer | 595.92 ns | 6.6257 ns |  6.1977 ns |  1.06 |    0.01 | 0.0095 |     - |     - |      64 B |
