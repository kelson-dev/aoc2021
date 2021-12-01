using System.Collections;

namespace Common
{
    public interface IInputSource<TSelf, T> where TSelf : struct, IInputSource<TSelf, T>
    {
        IEnumerable<T> LoadFor(int day, int part) => Load($"day{day}part{part}.txt");

        IEnumerable<T> Load(string name);
    }
}
