namespace Day3;

using Common;

public readonly struct DigitArrayInput : IInputSource<DigitArrayInput, int[]>
{
    public IEnumerable<int[]> Load(string name) =>
        default(LinesInput).Load(name)
            .Select(line => 
                line.Select(digit => digit - '0')
                .ToArray());
}

public readonly struct BinaryNumbersInput : IInputSource<BinaryNumbersInput, (int width, uint value)>
{
    public IEnumerable<(int width, uint value)> Load(string name) =>
        default(LinesInput).Load(name)
            .Select(line => line.Trim())
            .Select(line => (line.Length, Convert.ToUInt32(line, 2)));
}
