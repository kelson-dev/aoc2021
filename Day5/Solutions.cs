namespace Day5;
using Common;

public readonly struct Part1 : ISolution<LineSegment, int>
{
    public int InputDay => 5;

    public int Evaluate(IEnumerable<LineSegment> inputs)
    {
        var map = new Dictionary<(int x, int y), int>();
        foreach (var input in inputs)
            if (!input.IsDiagonal)
                input.AddTo(map);
        return map.Values.Where(i => i >= 2).Count();
    }
}

public readonly struct Part2 : ISolution<LineSegment, int>
{
    public int InputDay => 5;

    public int Evaluate(IEnumerable<LineSegment> inputs)
    {
        var map = new Dictionary<(int x, int y), int>();
        foreach (var input in inputs)
                input.AddTo(map);
        return map.Values.Where(i => i >= 2).Count();
    }
}