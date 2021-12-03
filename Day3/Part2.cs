namespace Day3;
using Common;
using System.Collections.Generic;

public readonly record struct Part2 : ISolution<(int, uint), uint>
{
    public int InputDay => 3;

    // Partician numbers into 2 sets based on the state of 'bit'
    // Return both sets with the largest first
    private (HashSet<uint>, HashSet<uint>) Split(HashSet<uint> numbers, int bit)
    {
        uint mask = 1u << bit;
        var (set, unset) = (new HashSet<uint>(), new HashSet<uint>());
        foreach (var num in numbers)
            ((num & mask) == 0 ? unset : set).Add(num);
        return set.Count >= unset.Count ? (set, unset) : (unset, set);
    }

    public uint Evaluate(IEnumerable<(int, uint)> inputs)
    {
        var numbers = new HashSet<uint>();
        var width = -1;
        foreach (var (number_of_bits, number) in inputs)
        {
            if (width == -1)
                width = number_of_bits;
            numbers.Add(number);
        }

        var index = width - 1;
        var (o2, co2) = Split(numbers, index--);
        // continue splitting the larger set down to 1 item
        while (o2.Count > 1 && index >= 0)
            (o2, _) = Split(o2, index--);
        index = width - 2;
        // continue splitting the smaller set down to 1 item
        while (co2.Count > 1 && index >= 0)
            (_, co2) = Split(co2, index--);
        return o2.Single() * co2.Single();
    }
}