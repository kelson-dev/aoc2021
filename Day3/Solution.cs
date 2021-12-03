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

public readonly record struct Part2 : ISolution<(int width, uint value), uint>
{
    public int InputDay => 3;

    private (HashSet<uint> mostCommon, HashSet<uint> leastCommon) Split(HashSet<uint> numbers, int bit)
    {
        int set_count = 0;
        uint mask = 1u << bit;
        foreach (var num in numbers)
            set_count += (int)((num & mask) >> bit);
        int unset_count = numbers.Count - set_count;
        int common = set_count >= unset_count ? 1 : 0;
        var (most, least) = (new HashSet<uint>(), new HashSet<uint>());
        foreach (var num in numbers)
            (((num & mask) >> bit ) == common ? most : least).Add(num);
        return (most, least);
    }

    public uint Evaluate(IEnumerable<(int width, uint value)> inputs)
    {
        var numbers = new HashSet<uint>();
        var width = 0;
        foreach (var (bits, value) in inputs)
        {
            width = bits;
            numbers.Add(value);
        }

        var w = width - 1;
        var (o2, co2) = Split(numbers, w--);
        while (o2.Count > 1 && w >= 0)
            (o2, _) = Split(o2, w--);
        w = width - 2;
        while (co2.Count > 1 && w >= 0)
            (_, co2) = Split(co2, w--);
        return o2.Single() * co2.Single();
    }
}