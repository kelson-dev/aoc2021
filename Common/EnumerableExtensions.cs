namespace Common;

public static class EnumerableExtensions
{
    private static IEnumerable<int> EnumerateRange(Range range)
    {
        var start = range.Start.IsFromEnd ? int.MaxValue - range.Start.Value : range.Start.Value;
        var end = range.End.IsFromEnd ? int.MaxValue - range.End.Value : range.End.Value;
        for (int i = 0; i < end - start; i++)
            yield return start + i;
    }

    public static IEnumerator<int> GetEnumerator(this Range range) => EnumerateRange(range).GetEnumerator();
}
