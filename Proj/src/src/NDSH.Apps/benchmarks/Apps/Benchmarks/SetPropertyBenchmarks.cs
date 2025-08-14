using BenchmarkDotNet.Attributes;
using NDSH.Apps.Benchmarks.Models;

namespace NDSH.Apps.Benchmarks {
  /// <summary>
  /// The benchmarks for property setters.
  /// </summary>
  public class SetPropertyBenchmarks {
    private static readonly string?[] DifferentCities = ["Manchester", "Leeds", "Durham", "Athens", null];
    private static readonly string?[] SameCities = ["Durham", "Durham", "Durham", "Durham"];

    /// <summary>
    /// The number of iterations used to calculate benchmark statistics.
    /// </summary>
    private const int Iterations = 10_000_000;

    /// <summary>
    /// The cities to use for the benchmark.
    /// </summary>
    [ParamsSource(nameof(CitiesParams))]
    public string?[] Cities = null!;

    /// <summary>
    /// The cities parameters to use for the benchmark.
    /// </summary>
    public IEnumerable<string?[]> CitiesParams {
      get {
        yield return DifferentCities;
        yield return SameCities;
      }
    }

    /// <summary>
    /// The benchmark for setting a property which first checks if the value is not null or the same as the current value
    /// using <see cref="object.Equals(object?)"/>.
    /// </summary>
    [Benchmark]
    public void CI_Address_Type1_NotNullAndEquals() {
      CI_Address_Type1 address = new();
      for (int i = 0; i < Iterations; i++) {
        address.City = Cities[i % Cities.Length];
      }
    }

    /// <summary>
    /// The benchmark for setting a property using <see cref="ObservableModel.SetProperty{T}(ref T, T, string)"/>.
    /// This approach uses the <see cref="EqualityComparer{T}"/> to compare the current value with the new value.
    /// </summary>
    [Benchmark]
    public void CI_Address_Type2_ObservableModel_SetProperty() {
      CI_Address_Type2 address = new();
      for (int i = 0; i < Iterations; i++) {
        address.City = Cities[i % Cities.Length];
      }
    }
  }
}
/*
 BENCHMARK RESULTS:
|--------------------------------------------- |---------- |---------:|---------:|---------:|
| CI_Address_Type1_NotNullAndEquals            | String[4] | 12.43 ms | 0.045 ms | 0.040 ms | // DifferentCities
| CI_Address_Type2_ObservableModel_SetProperty | String[4] | 12.35 ms | 0.042 ms | 0.039 ms | // DifferentCities
| CI_Address_Type1_NotNullAndEquals            | String[5] | 23.16 ms | 0.445 ms | 0.416 ms | // SameCities
| CI_Address_Type2_ObservableModel_SetProperty | String[5] | 15.16 ms | 0.299 ms | 0.388 ms | // SameCities

CONCLUSION:
The ObservableModel.SetProperty method can be faster than the manual null and equality check.
This difference is more noticeable when the values are the same. 
*/
