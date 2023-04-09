``` ini

BenchmarkDotNet=v0.13.5, OS=elementary 7
11th Gen Intel Core i9-11900H 2.50GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2


```
|         Method |     Mean |     Error |    StdDev |     Gen0 |     Gen1 |     Gen2 | Allocated |
|--------------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|
|       ListTest | 3.010 ms | 0.0278 ms | 0.0246 ms | 496.0938 | 496.0938 | 496.0938 |   6.58 MB |
| EnumerableTest | 2.032 ms | 0.0042 ms | 0.0037 ms | 378.9063 |        - |        - |   4.58 MB |
