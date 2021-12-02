namespace Day2;

public record struct SubCommand(SubCommand.SubDirection Direction, int Distance)
{
    public enum SubDirection
    {
        None,
        Forward,
        Down,
        Up
    }

    private static SubDirection ParseDirection(ReadOnlySpan<char> text)
    {
        if (text.Equals("forward", StringComparison.OrdinalIgnoreCase))
            return SubDirection.Forward;
        else if (text.Equals("down", StringComparison.OrdinalIgnoreCase))
            return SubDirection.Down;
        else if (text.Equals("up", StringComparison.OrdinalIgnoreCase))
            return SubDirection.Up;
        else 
            return SubDirection.None;
    }


    public static bool TryParse(string text, out SubCommand command)
    {
        command = new(SubDirection.None, 0);
        var span = text.AsSpan();
        int split = span.IndexOf(' ');
        var dir_text = span[..split];
        var dist_text = span[(split + 1)..];
        SubDirection dir = ParseDirection(dir_text);
        if (dir == SubDirection.None)
            return false;

        if (!int.TryParse(dist_text, out int distance))
            return false;
            
        command = new(dir, distance);
        return true;
    }
}