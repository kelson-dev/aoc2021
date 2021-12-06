namespace Common;

public readonly struct CommaDelimitedDigitsInput : IInputSource<CommaDelimitedDigitsInput, ushort>
{
    public IEnumerable<ushort> Load(string name)
    {
        using var stream = File.OpenRead(Path.Combine("Inputs", name));
        using var reader = new StreamReader(stream);
        char[] pair = new char[2];
        while (!reader.EndOfStream)
        {
            int count = reader.Read(pair, 0, 2);
            if (char.IsDigit(pair[0]))
                yield return (ushort)(pair[0] - '0');
            if (count < 2)
                yield break;
        }
    }
}
