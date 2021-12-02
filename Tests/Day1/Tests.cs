namespace Tests.Day1;

using global::Day1;
using System.Collections.Generic;

public class Part1Tests : GenericSolutionTest<int, int, Part1>
{
    public override IEnumerable<(int[], int[])> Cases()
    {
        yield return (new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }, new int[] { 7 });
        yield return (new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 6 });
        yield return (new int[] { 6, 5, 4, 3, 2, 1, 0 }, new int[] { 0 });
        yield return (new int[] { 0 }, new int[] { 0 });
        yield return (new int[] { 0, 0, 0, 1, 1, 1, 0, 0, 0 }, new int[] { 1 });
    }
}

public class Part2Tests : GenericSolutionTest<int, int, Part2>
{
    public override IEnumerable<(int[], int[])> Cases()
    {
        yield return (new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }, new int[] { 5 });
        yield return (new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 4 });
        yield return (new int[] { 6, 5, 4, 3, 2, 1, 0 }, new int[] { 0 });
        yield return (new int[] { 0 }, new int[] { 0 });
        yield return (new int[] { 0, 0, 0, 1, 1, 1, 0, 0, 0 }, new int[] { 3 });
    }
}