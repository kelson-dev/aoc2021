namespace Day5;
using Common;

public readonly struct LineSegmentsInput : IInputSource<LineSegmentsInput, LineSegment>
{
    public IEnumerable<LineSegment> Load(string name) =>
        default(LinesInput)
            .Load(name)
            .SelectWhere<string, LineSegment>(LineSegment.TryParse);
}

public readonly record struct LineSegment(int StartX, int StartY, int EndX, int EndY)
{
    public bool IsHorizontal => StartY == EndY;
    public bool IsVertical => StartX == EndX;
    public bool IsDiagonal => !(IsHorizontal || IsVertical);

    public (int dx, int dy) Direction => (EndX.CompareTo(StartX), EndY.CompareTo(StartY));

    public int RangeX => Math.Abs(StartX - EndX);
    public int RangeY => Math.Abs(StartY - EndY);
    public int Range => Math.Max(RangeX, RangeY);

    public void AddTo(IDictionary<(int x, int y), int> map)
    {
        var (x, y) = (StartX, StartY);
        var (dx, dy) = Direction;
        for (int i = 0; i <= Range; i++)
        {
            map[(x, y)] = map.TryGetValue((x, y), out var value) ? value + 1 : 1;
            x += dx;
            y += dy;
        }
    }

    public static bool TryParse(string line, out LineSegment value)
    {
        const StringSplitOptions TrimRemoveEmpty = StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries;
        value = default;
        string[] points = line.Split("->", TrimRemoveEmpty);
        if (points.Length != 2)
            return false;

        var a = points[0].Split(",", TrimRemoveEmpty);
        if (a.Length != 2
            || !int.TryParse(a[0], out var sx)
            || !int.TryParse(a[1], out var sy))
            return false;

        var b = points[1].Split(",", TrimRemoveEmpty);
        if (b.Length != 2
         || !int.TryParse(b[0], out var ex)
         || !int.TryParse(b[1], out var ey))
            return false;

        value = new LineSegment(sx, sy, ex, ey);
        return true;
    }
}
