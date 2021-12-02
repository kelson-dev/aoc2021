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

    public delegate bool TryMap<U, V>(U value, out V result);

    public static IEnumerable<V> SelectWhere<U, V>(this IEnumerable<U> source, TryMap<U, V> map)
    {
        foreach (var value in source)
            if (map(value, out var result))
                yield return result;
    }
}
