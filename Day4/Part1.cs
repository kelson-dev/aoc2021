namespace Day4;

using Common;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using static BingoItem;

public readonly struct Part1 : ISolution<BingoItem, int>
{
    public int InputDay => 4;

    public int Evaluate(IEnumerable<BingoItem> inputs)
    {
        int[]? numbers = null;
        var (least_steps, last_number, unset_sum) = (int.MaxValue, 0, 0);
        foreach (var input in inputs)
            if (input is NumberSequence sequence)
                (numbers, least_steps) = (sequence.Sequence, sequence.Sequence.Length);
            else if (input is BoardDefinition board && numbers is int[] set)
                CheckBoard(board, set, ref least_steps, ref unset_sum, ref last_number);

        return unset_sum * last_number;
    }

    public bool CheckBoard(BoardDefinition board, int[] numbers, ref int leastSteps, ref int unsetSum, ref int lastNumber)
    {
        var state = new BingoBoardState(board.Board);
        for (int i = 0; i < leastSteps; i++)
        {
            var number = numbers[i];
            state <<= number;
            if (i >= 4 && state.IsBingo)
            {
                leastSteps = i; // only loops up to less than least steps, so definitely less than
                unsetSum = state.Values(set: false).Sum();
                lastNumber = number;
                return true;
            }
        }
        return false;
    }
}
