using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run(typeof(Benchmarks.Day6Benchmark).Assembly);