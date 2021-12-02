namespace Common;

public readonly struct LinesInput : IInputSource<LinesInput, string>
{
    public IEnumerable<string> Load(string name)
    {
        using var stream = File.OpenRead(Path.Combine("Inputs", name));
        using var reader = new StreamReader(stream);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line is not null)
                yield return line;
            else yield break;
        }
    }
}