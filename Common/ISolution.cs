namespace Common;

public interface ISolution<in TIn, out TOut>
{
    int InputDay { get; }
    int? InputPart => null;
    TOut Evaluate(IEnumerable<TIn> inputs);
}