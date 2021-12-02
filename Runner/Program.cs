﻿var days = Days(args);

Run<Day1.Part1, int, int, IntegerLinesInput>();
Run<Day1.Part2, int, int, IntegerLinesInput>();
Run<Day2.Part1, Day2.SubCommand, int, Day2.SubmarineCommandsInput>();
Run<Day2.Part2, Day2.SubCommand, int, Day2.SubmarineCommandsInput>();

#region Functions
static ImmutableHashSet<int> Days(string[] args)
{
    HashSet<int> values = new();
    bool any_number = false;
    for (int i = args.Length - 1; i >= 0; i--)
    {
        if (int.TryParse(args[i], out var value))
        {
            any_number = true;
            values.Add(value);
        }
        else if (any_number)
            break;
    }
    return values.ToImmutableHashSet();
}

void Run<TSolution, TIn, TOut, TInputSource>()
    where TSolution : struct, ISolution<TIn, TOut>
    where TInputSource : struct, IInputSource<TInputSource, TIn>
{
    var solution = default(TSolution);

    if (days.Count != 0 && !days.Contains(solution.InputDay))
        return;

    var output = default(TSolution).Evaluate(default(TInputSource).LoadFor(solution.InputDay, solution.InputPart));
    Console.WriteLine($"Day {solution.InputDay} Part {solution.InputPart}: {output}");
}
#endregion