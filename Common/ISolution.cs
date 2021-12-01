namespace Common;

public interface ISolution<in TIn, out TOut>
{
    int InputDay { get; }
    int InputPart { get; }
    IEnumerable<TOut> Evaluate(IEnumerable<TIn> inputs);
}