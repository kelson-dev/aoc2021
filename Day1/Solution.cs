namespace Day1;

using Common;
using Common.DataStructures;

public readonly struct Part1 : ISolution<int, int>
{
    public int InputDay => 1;
    public int InputPart => 1;

    public IEnumerable<int> Evaluate(IEnumerable<int> inputs)
    {
        int? previous = null;
        int increases = 0;
        foreach (var input in inputs)
        {
            increases += previous is not null && input > previous ? 1 : 0;
            previous = input;
        }

        yield return increases;
    }
}

public readonly struct Part2 : ISolution<int, int>
{
    const int WINDOW_WIDTH = 3;

    public int InputDay => 1;
    public int InputPart => 1; // reuses part 1 input

    private IEnumerable<int> WindowSums(IEnumerable<int> inputs)
    {
        var window = new CircularBuffer<int>(WINDOW_WIDTH);
        int sum = 0;
        foreach (var input in inputs)
        {
            window.Add(input, out int replaced);
            sum += input - replaced;
            if (window.Count >= WINDOW_WIDTH)
                yield return sum;
        }
    }

    public IEnumerable<int> Evaluate(IEnumerable<int> inputs) => default(Part1).Evaluate(WindowSums(inputs));
}
