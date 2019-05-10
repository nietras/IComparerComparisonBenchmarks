``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.437 (1809/October2018Update/Redstone5)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.0.100-preview-009812
  [Host]     : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT


```
|                         Method |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|   OpenComparison_FromCompareTo | 214.8 ns | 0.8574 ns | 0.7601 ns |  0.90 |    0.01 |      - |     - |     - |         - |
|                      IComparer | 238.4 ns | 1.8921 ns | 1.6773 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                       Comparer | 201.1 ns | 3.1639 ns | 2.8047 ns |  0.84 |    0.01 |      - |     - |     - |         - |
|            TComparer_TComparer | 105.8 ns | 0.8068 ns | 0.7547 ns |  0.44 |    0.00 |      - |     - |     - |         - |
|            TComparer_IComparer | 240.1 ns | 2.7365 ns | 2.5597 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|             TComparer_Comparer | 244.7 ns | 3.2373 ns | 3.0281 ns |  1.03 |    0.02 |      - |     - |     - |         - |
|           TComparer_Comparable | 106.5 ns | 2.2041 ns | 1.9539 ns |  0.45 |    0.01 |      - |     - |     - |         - |
|       Comparison_FromIComparer | 199.3 ns | 0.4095 ns | 0.3197 ns |  0.84 |    0.01 |      - |     - |     - |         - |
|        Comparison_FromComparer | 200.4 ns | 1.8194 ns | 1.7019 ns |  0.84 |    0.01 |      - |     - |     - |         - |
| Comparison_CreateFromIComparer | 275.8 ns | 0.7717 ns | 0.6841 ns |  1.16 |    0.01 | 0.0100 |     - |     - |      64 B |
|  Comparison_CreateFromComparer | 213.9 ns | 0.6353 ns | 0.5632 ns |  0.90 |    0.01 | 0.0100 |     - |     - |      64 B |
