namespace Tests.Day2;

using global::Day2;
using System.Collections.Generic;

public class Part1Tests : GenericSolutionTest<SubCommand, int, Part1>
{
    public override IEnumerable<(SubCommand[], int)> Cases()
    {
        yield return (new SubCommand[] { }, 0);

        yield return (
            new SubCommand[] 
            { 
                new(SubCommand.SubDirection.Forward, 1),
                new(SubCommand.SubDirection.Down, 1),
            }, 
            1);

        yield return (
            new SubCommand[]
            {
                new(SubCommand.SubDirection.Forward, 1),
                new(SubCommand.SubDirection.Up, 1),
            },
            -1);

        yield return (
            new SubCommand[]
            {
                new(SubCommand.SubDirection.Forward, 5),
                new(SubCommand.SubDirection.Down, 5),
                new(SubCommand.SubDirection.Forward, 8),
                new(SubCommand.SubDirection.Up, 3),
                new(SubCommand.SubDirection.Down, 8),
                new(SubCommand.SubDirection.Forward, 2),
            },
            150);
    }
}

public class Part2_EmptyInput_GoesNowhere : GenericCaseTest<SubCommand, int, Part2>
{
    public override SubCommand[] Case => new SubCommand[] { };
    public override int Expected => 0;
}

public class Part2_ForwardDown_HasNoDepth : GenericCaseTest<SubCommand, int, Part2>
{
    public override SubCommand[] Case => new SubCommand[]
    {
        new(SubCommand.SubDirection.Forward, 1),
        new(SubCommand.SubDirection.Down, 1),
    };

    public override int Expected => 0;
}

public class Part2_DownForward_HasDepth : GenericCaseTest<SubCommand, int, Part2>
{
    public override SubCommand[] Case => new SubCommand[]
    {
        new(SubCommand.SubDirection.Down, 1),
        new(SubCommand.SubDirection.Forward, 1),
    };

    public override int Expected => 1;
}

public class Part2_DownByMultipleOfAim : GenericCaseTest<SubCommand, int, Part2>
{
    public override SubCommand[] Case => new SubCommand[]
    {
        new(SubCommand.SubDirection.Forward, 1), // (1, 0, 0)
        new(SubCommand.SubDirection.Down, 1), // (1, 0, 1)
        new(SubCommand.SubDirection.Forward, 3), // (4, 3, 1)
    };

    public override int Expected => 12;
}

public class Part2_SampleCase : GenericCaseTest<SubCommand, int, Part2>
{
    public override SubCommand[] Case => new SubCommand[]
    {
        new(SubCommand.SubDirection.Forward, 5),
        new(SubCommand.SubDirection.Down, 5),
        new(SubCommand.SubDirection.Forward, 8),
        new(SubCommand.SubDirection.Up, 3),
        new(SubCommand.SubDirection.Down, 8),
        new(SubCommand.SubDirection.Forward, 2),
    };

    public override int Expected => 900;
}