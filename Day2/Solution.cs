namespace Day2;

using Common;
using Direction = Day2.SubCommand.SubDirection;

public readonly struct Part1 : ISolution<SubCommand, int>
{
    public int InputDay => 2;

    public IEnumerable<int> Evaluate(IEnumerable<SubCommand> inputs)
    {
        (int horizontal, int depth) = (0, 0);
        foreach (var command in inputs)
            (horizontal, depth) = Apply(command, horizontal, depth);
        yield return horizontal * depth;
    }

    public static (int horizontal, int depth) Apply(SubCommand command, int horizontal, int depth)
    {
        switch (command.Direction)
        {
            case Direction.Down:
                depth += command.Distance;
                break;
            case Direction.Up:
                depth -= command.Distance;
                break;
            case Direction.Forward:
                horizontal += command.Distance;
                break;
        }

        return (horizontal, depth);
    }
}

public readonly struct Part2 : ISolution<SubCommand, int>
{
    public int InputDay => 2;

    public IEnumerable<int> Evaluate(IEnumerable<SubCommand> inputs)
    {
        (int horizontal, int depth, int aim) = (0, 0, 0);
        foreach (var command in inputs)
            (horizontal, depth, aim) = Apply(command, horizontal, depth, aim);
        yield return horizontal * depth;
    }

    public static (int horizontal, int depth, int aim) Apply(SubCommand command, int horizontal, int depth, int aim)
    {
        switch (command.Direction)
        {
            case Direction.Down:
                aim += command.Distance;
                break;
            case Direction.Up:
                aim -= command.Distance;
                break;
            case Direction.Forward:
                horizontal += command.Distance;
                depth += (aim * command.Distance);
                break;
        }

        return (horizontal, depth, aim);
    }
}