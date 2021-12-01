using Common;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public abstract class GenericSolutionTest<TIn, TOut, TSolution> where TSolution : struct, ISolution<TIn, TOut>
    {
        public abstract IEnumerable<(TIn[], TOut[])> Cases();

        [Fact]
        public void ExamplesMatchProvidedSolutions()
        {
            foreach (var (input, output) in Cases())
            {
                var solution = default(TSolution).Evaluate(input).ToArray();
                string case_description = $"<[{string.Join(", ", input)}] -> [{string.Join(", ", solution)}], expected [{string.Join(", ", output)}]>";
                solution
                    .Should()
                    .HaveSameCount(output, because: case_description)
                    .And
                    .ContainInOrder(output, because: case_description);
            }
        }
    }
}
