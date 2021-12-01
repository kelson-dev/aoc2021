namespace Common;

public readonly struct IntegerLinesInput : IInputSource<IntegerLinesInput, int>
{
    public IEnumerable<int> Load(string name)
    {
        List<int> values = new(128);
        using var stream = File.OpenRead(Path.Combine("Inputs", name));
        using var reader = new StreamReader(stream);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (int.TryParse(line, out int value))
                yield return value;
            else yield break;
        }
    }
}
