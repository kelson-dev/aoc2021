namespace Benchmarks;

using BenchmarkDotNet.Attributes;
using Common;
using System;

public class Day6Benchmark
{
    public static readonly ushort[] SampleData = new ushort[] { 3, 4, 3, 1, 2 };
    public static readonly ushort[] PuzzleData = new ushort[] {
        4,1,1,4,1,2,1,4,1,3,4,4,1,5,5,1,3,1,1,1,4,4,3,1,5,3,1,2,5,1,1,5,1,1,4,1,1,1,1,2,1,5,3,4,4,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,5,1,1,1,4,1,2,3,5,1,2,2,4,1,4,4,4,1,2,5,1,2,1,1,1,1,1,1,4,1,1,4,3,4,2,1,3,1,1,1,
        3,5,5,4,3,4,1,5,1,1,1,2,2,1,3,1,2,4,1,1,3,3,1,3,3,1,1,3,1,5,1,1,3,1,1,1,5,4,1,1,1,1,4,1,1,3,5,4,3,1,1,5,4,1,1,2,5,4,2,1,4,1,1,1,1,3,1,1,1,1,4,1,1,1,1,2,4,1,1,1,1,3,1,1,5,1,1,1,1,1,1,4,2,1,3,1,1,1,2,4,
        2,3,1,4,1,2,1,4,2,1,4,4,1,5,1,1,4,4,1,2,2,1,1,1,1,1,1,1,1,1,1,1,4,5,4,1,3,1,3,1,1,1,5,3,5,5,2,2,1,4,1,4,2,1,4,1,2,1,1,2,1,1,5,4,2,1,1,1,2,4,1,1,1,1,2,1,1,5,1,1,2,2,5,1,1,1,1,1,2,4,2,3,1,2,1,5,4,5,1,4
    };

    private readonly ulong[] SampleData_Adults;
    private readonly ulong SampleData_InitialPop;
    private readonly ulong[] PuzzleData_Adults;
    private readonly ulong PuzzleData_InitialPop;

    public Day6Benchmark()
    {
        SampleData_Adults = new ulong[7];
        for (int i = 0; i < SampleData.Length; i++)
        {
            SampleData_InitialPop++;
            SampleData_Adults[i % 7]++;
        }
        PuzzleData_Adults = new ulong[7];
        for (int i = 0; i < PuzzleData.Length; i++)
        {
            PuzzleData_InitialPop++;
            PuzzleData_Adults[i % 7]++;
        }
    }

    [Params(80, 256)]
    public int Count { get; set; }

    [Benchmark]
    public ulong SimulateSampleData() => global::Day6.LampfishSim<One>.Simulate(Count, SampleData_InitialPop, SampleData_Adults.AsSpan(), stackalloc ulong[9]);

    [Benchmark]
    public ulong SimulatePuzzleData() => global::Day6.LampfishSim<One>.Simulate(Count, PuzzleData_InitialPop, PuzzleData_Adults.AsSpan(), stackalloc ulong[9]);
}
