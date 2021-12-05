

namespace Tests.Day5;
using global::Day5;

public class Part1_SampleCase : GenericCaseTest<LineSegment, int, Part1>
{
    public override LineSegment[] Case => new LineSegment[]
    {
        new LineSegment(0,9, 5,9),
        new LineSegment(8,0, 0,8),
        new LineSegment(9,4, 3,4),
        new LineSegment(2,2, 2,1),
        new LineSegment(7,0, 7,4),
        new LineSegment(6,4, 2,0),
        new LineSegment(0,9, 2,9),
        new LineSegment(3,4, 1,4),
        new LineSegment(0,0, 8,8),
        new LineSegment(5,5, 8,2),
    };

    public override int Expected => 5;
}


public class Part2_SampleCase : GenericCaseTest<LineSegment, int, Part2>
{
    public override LineSegment[] Case => new LineSegment[]
    {
        new LineSegment(0,9, 5,9),
        new LineSegment(8,0, 0,8),
        new LineSegment(9,4, 3,4),
        new LineSegment(2,2, 2,1),
        new LineSegment(7,0, 7,4),
        new LineSegment(6,4, 2,0),
        new LineSegment(0,9, 2,9),
        new LineSegment(3,4, 1,4),
        new LineSegment(0,0, 8,8),
        new LineSegment(5,5, 8,2),
    };

    public override int Expected => 12;
}