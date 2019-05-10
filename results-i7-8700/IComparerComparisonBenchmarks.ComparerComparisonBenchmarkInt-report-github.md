``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.437 (1809/October2018Update/Redstone5)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.0.100-preview-009812
  [Host]     : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT


```
|                         Method |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|   OpenComparison_FromCompareTo | 214.9 ns | 1.1573 ns | 1.0826 ns |  0.91 |    0.01 |      - |     - |     - |         - |
|                      IComparer | 235.1 ns | 1.6061 ns | 1.4237 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                       Comparer | 199.8 ns | 0.6662 ns | 0.5906 ns |  0.85 |    0.01 |      - |     - |     - |         - |
|            TComparer_TComparer | 107.5 ns | 2.5287 ns | 2.4835 ns |  0.46 |    0.01 |      - |     - |     - |         - |
|            TComparer_IComparer | 239.5 ns | 5.2939 ns | 6.5014 ns |  1.02 |    0.03 |      - |     - |     - |         - |
|             TComparer_Comparer | 239.4 ns | 4.7531 ns | 4.6682 ns |  1.02 |    0.02 |      - |     - |     - |         - |
|           TComparer_Comparable | 106.1 ns | 1.5005 ns | 1.4036 ns |  0.45 |    0.01 |      - |     - |     - |         - |
|       Comparison_FromIComparer | 198.6 ns | 0.4660 ns | 0.3639 ns |  0.85 |    0.01 |      - |     - |     - |         - |
|        Comparison_FromComparer | 198.1 ns | 1.7512 ns | 1.6381 ns |  0.84 |    0.01 |      - |     - |     - |         - |
| Comparison_CreateFromIComparer | 273.4 ns | 0.9553 ns | 0.8469 ns |  1.16 |    0.01 | 0.0100 |     - |     - |      64 B |
|  Comparison_CreateFromComparer | 213.1 ns | 0.6746 ns | 0.6310 ns |  0.91 |    0.01 | 0.0100 |     - |     - |      64 B |
