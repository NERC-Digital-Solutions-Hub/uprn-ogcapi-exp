using BenchmarkDotNet.Running;
using NDSH.Apps.Benchmarks;

internal class Program {
  private static void Main(string[] args) {
    BenchmarkRunner.Run<SetPropertyBenchmarks>();
  }
}
