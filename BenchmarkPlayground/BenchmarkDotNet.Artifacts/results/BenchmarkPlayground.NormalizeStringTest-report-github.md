```

BenchmarkDotNet v0.13.8, Windows 11 (10.0.22621.2283/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 6.0.317
  [Host]     : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2


```
| Method                        | Mean     | Error   | StdDev  | Gen0   | Allocated |
|------------------------------ |---------:|--------:|--------:|-------:|----------:|
| NormalizeStringWithStringList | 204.9 ns | 1.93 ns | 1.80 ns | 0.0644 |     808 B |
| NormalizeString               | 171.3 ns | 2.48 ns | 2.32 ns | 0.0610 |     768 B |
