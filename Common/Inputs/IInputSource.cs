namespace Common;

public interface IInputSource<TSelf, T> where TSelf : struct, IInputSource<TSelf, T>
{
    IEnumerable<T> LoadFor(int day, int? part) => Load($"day{day}part{part ?? 1}.txt");

    IEnumerable<T> Load(string name);
}
