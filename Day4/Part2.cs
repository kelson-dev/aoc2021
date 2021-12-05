namespace Day4;

using Common;
using System.Collections.Generic;
using System.Linq;
using static BingoItem;

public readonly struct Part2 : ISolution<BingoItem, int>
{
    public int InputDay => 4;

    public int Evaluate(IEnumerable<BingoItem> inputs)
    {
        int[]? numbers = null;
        var (most_steps, last_number, unset_sum) = (0, 0, 0);
        foreach (var input in inputs)
            if (input is NumberSequence sequence)
                numbers = sequence.Sequence;
            else if (input is BoardDefinition board && numbers is int[] set)
                CheckBoard(board, set, ref most_steps, ref unset_sum, ref last_number);

        return unset_sum * last_number;
    }

    public bool CheckBoard(BoardDefinition board, int[] numbers, ref int mostSteps, ref int unsetSum, ref int lastNumber)
    {
        var state = new BingoBoardState(board.Board);
        for (int i = 0; i < 100; i++)
        {
            var number = numbers[i];
            state <<= number;
            if (state.IsBingo)
            {
                if (i > mostSteps)
                {
                    mostSteps = i;
                    unsetSum = state.Values(set: false).Sum();
                    lastNumber = number;
                    return true;
                }
                else return false;
            }
        }
        return false;
    }
}