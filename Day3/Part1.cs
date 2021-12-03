namespace Day3;
using Common;
using System.Collections.Generic;

public readonly record struct Part1 : ISolution<int[], uint>
{
    public int InputDay => 3;

    public uint Evaluate(IEnumerable<int[]> inputs)
    {
        int[]? counts = null;
        int lines = 0;
        foreach (var vec in inputs)
        {
            lines++;
            counts ??= new int[vec.Length];
            for (int i = 0; i < vec.Length; i++)
                counts[i] += vec[i];
        }
        int half = lines / 2;
        uint gamma = 0;
        int len = counts?.Length ?? 0;
        for (int bit = 0; bit < len; bit++)
            gamma |= (counts![len - bit - 1] > half ? 1u : 0u) << bit;
        uint epsilon = ~gamma & (~0u >> (32 - len));
        return gamma * epsilon;
    }
}