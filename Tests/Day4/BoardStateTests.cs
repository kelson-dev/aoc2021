using Day4;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Day4
{
    public class BoardStateTests
    {
        int[][] sample_board = new int[][] 
        {
            new int[] { 00, 01, 02, 03, 04 },
            new int[] { 10, 11, 12, 13, 14 },
            new int[] { 20, 21, 22, 23, 24 },
            new int[] { 30, 31, 32, 33, 34 },
            new int[] { 40, 41, 42, 43, 44 },
        };

        [Fact]
        public void NewBoardIsNotBingo()
        {
            var state = new BingoBoardState(sample_board);
            state.IsBingo.Should().BeFalse();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void BoardWithRowSetIsBingo(int row)
        {
            var state = new BingoBoardState(sample_board);
            for (int c = 0; c < 5; c++)
            {
                state.IsBingo.Should().BeFalse();
                state <<= sample_board[row][c];
            }
            state.IsBingo.Should().BeTrue();
            state.Values(set: true).Should().Contain(sample_board[row]);
            for (int r = 0; r < 5; r++) if (r != row)
                state.Values(set: false).Should().Contain(sample_board[r]);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void BoardWithColumnSetIsBingo(int column)
        {
            var state = new BingoBoardState(sample_board);
            for (int r = 0; r < 5; r++)
            {
                state.IsBingo.Should().BeFalse();
                state <<= sample_board[r][column];
            }
            state.IsBingo.Should().BeTrue();
        }
    }
}
