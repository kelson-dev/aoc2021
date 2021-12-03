
namespace Tests.Day3;
using global::Day3;

public class Part1_AllOnesResultsInZeroBecauseZeroEpsilon : GenericCaseTest<int[], uint, Part1>
{
    public override int[][] Case => new int[][]
    {
        new int[] { 1, 1, 1, 1 },
        new int[] { 1, 1, 1, 1 },
        new int[] { 1, 1, 1, 1 },
    };

    public override uint Expected => 0;
}

public class Part1_8Times7 : GenericCaseTest<int[], uint, Part1>
{
    public override int[][] Case => new int[][]
    {
        new int[] { 1, 0, 0, 0 }, // 8
        new int[] { 0, 1, 1, 1 }, // least common
        new int[] { 1, 0, 0, 0 }, // 8
    };

    public override uint Expected => 8 * 7;
}

public class Part1_SampleCase : GenericCaseTest<int[], uint, Part1>
{
    public override int[][] Case => new int[][]
    {
        new int[] { 0, 0, 1, 0, 0 },
        new int[] { 1, 1, 1, 1, 0 },
        new int[] { 1, 0, 1, 1, 0 },
        new int[] { 1, 0, 1, 1, 1 },
        new int[] { 1, 0, 1, 0, 1 },
        new int[] { 0, 1, 1, 1, 1 },
        new int[] { 0, 0, 1, 1, 1 },
        new int[] { 1, 1, 1, 0, 0 },
        new int[] { 1, 0, 0, 0, 0 },
        new int[] { 1, 1, 0, 0, 1 },
        new int[] { 0, 0, 0, 1, 0 },
        new int[] { 0, 1, 0, 1, 0 },
    };

    public override uint Expected => 22 * 9;
}

public class Part2_SampleCase : GenericCaseTest<(int, uint), uint, Part2>
{
    public override (int, uint)[] Case => new (int, uint)[]
    {
        (5, 0b00100),
        (5, 0b11110),
        (5, 0b10110),
        (5, 0b10111),
        (5, 0b10101),
        (5, 0b01111),
        (5, 0b00111),
        (5, 0b11100),
        (5, 0b10000),
        (5, 0b11001),
        (5, 0b00010),
        (5, 0b01010),
    };

    public override uint Expected => 230;
}