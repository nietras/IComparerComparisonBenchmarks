``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.437 (1809/October2018Update/Redstone5)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.0.100-preview-009812
  [Host]     : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT


```
|                         Method |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|   OpenComparison_FromCompareTo | 219.0 ns | 0.9005 ns | 0.8423 ns |  0.90 |      - |     - |     - |         - |
|                      IComparer | 243.2 ns | 1.9207 ns | 1.7966 ns |  1.00 |      - |     - |     - |         - |
|                       Comparer | 198.6 ns | 0.4204 ns | 0.3510 ns |  0.82 |      - |     - |     - |         - |
|            TComparer_TComparer | 105.3 ns | 0.3031 ns | 0.2835 ns |  0.43 |      - |     - |     - |         - |
|            TComparer_IComparer | 242.3 ns | 0.2348 ns | 0.1833 ns |  1.00 |      - |     - |     - |         - |
|             TComparer_Comparer | 244.2 ns | 2.1004 ns | 1.9647 ns |  1.00 |      - |     - |     - |         - |
|           TComparer_Comparable | 105.4 ns | 0.2813 ns | 0.2493 ns |  0.43 |      - |     - |     - |         - |
|   ComparisonComparer_IComparer | 284.6 ns | 2.1544 ns | 2.0152 ns |  1.17 |      - |     - |     - |         - |
|   ComparisonComparer_TComparer | 278.6 ns | 2.5180 ns | 2.2322 ns |  1.15 |      - |     - |     - |         - |
|       Comparison_FromIComparer | 200.7 ns | 0.8566 ns | 0.7594 ns |  0.83 |      - |     - |     - |         - |
|        Comparison_FromComparer | 200.2 ns | 1.4703 ns | 1.3753 ns |  0.82 |      - |     - |     - |         - |
| Comparison_CreateFromIComparer | 278.2 ns | 0.9319 ns | 0.8717 ns |  1.14 | 0.0100 |     - |     - |      64 B |
|  Comparison_CreateFromComparer | 214.8 ns | 0.6863 ns | 0.6420 ns |  0.88 | 0.0100 |     - |     - |      64 B |
