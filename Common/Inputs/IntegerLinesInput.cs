namespace Common;

public readonly struct IntegerLinesInput : IInputSource<IntegerLinesInput, int>
{
    public IEnumerable<int> Load(string name) => default(LinesInput).Load(name).SelectWhere<string, int>(int.TryParse);
}
