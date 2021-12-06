
namespace Common;

public interface IValue<TSelf, TValue> where TSelf : struct, IValue<TSelf, TValue>
{
    public TValue Value { get; }
}
