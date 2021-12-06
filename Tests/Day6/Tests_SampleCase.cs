

namespace Tests.Day6;

using Common;
using global::Day6;

public class Part1_SampleCase : GenericCaseTest<ushort, ulong, LampfishSim<Eighty>>
{
    public override ushort[] Case => new ushort[] { 3, 4, 3, 1, 2 };

    public override ulong Expected => 5934;
}

public class Part2_SampleCase : GenericCaseTest<ushort, ulong, LampfishSim<TwoHundredFiftySix>>
{
    public override ushort[] Case => new ushort[] { 3, 4, 3, 1, 2 };

    public override ulong Expected => 26984457539;
}
