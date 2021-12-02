using Common;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public abstract class GenericSolutionTest<TIn, TOut, TSolution> where TSolution : struct, ISolution<TIn, TOut>
    {
        public abstract IEnumerable<(TIn[], TOut)> Cases();

        [Fact]
        public void ExamplesMatchProvidedSolutions()
        {
            foreach (var (input, output) in Cases())
            {
                var solution = default(TSolution).Evaluate(input);
                string case_description = $"<[{string.Join(", ", input)}] -> [{string.Join(", ", solution)}], expected [{string.Join(", ", output)}]>";
                solution.Should().BeEquivalentTo(output, because: case_description);
            }
        }
    }

    public abstract class GenericCaseTest<TIn, TOut, TSolution> where TSolution : struct, ISolution<TIn, TOut>
    {
        public abstract TIn[] Case { get; }
        public abstract TOut Expected { get; }

        [Fact]
        public void ExamplesMatchProvidedSolutions()
        {
            var (input, output) = (Case, Expected);
            var solution = default(TSolution).Evaluate(input);
            string case_description = $"<[{string.Join(", ", input)}] -> [{string.Join(", ", solution)}], expected [{string.Join(", ", output)}]>";
            solution.Should().BeEquivalentTo(output, because: case_description);
        }
    }
}
