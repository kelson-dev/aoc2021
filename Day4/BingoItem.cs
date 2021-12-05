namespace Day4;

using Common;
using System;
using System.Collections.Generic;
using System.Linq;

public readonly struct BingoInput : IInputSource<BingoInput, BingoItem> { public IEnumerable<BingoItem> Load(string name) => BingoItem.Parse(default(LinesInput).Load(name)); }

public abstract class BingoItem 
{
    private enum ParseState { None, Values, Blank, Board1, Board2, Board3, Board4, Board5, }

    public static IEnumerable<BingoItem> Parse(IEnumerable<string> lines)
    {
        var state = ParseState.Values;
        var board_lines = new string[5];
        foreach (var line in lines) switch (state)
        {
            case ParseState.Values:
                state = ParseState.Blank;
                yield return new NumberSequence(line);
                break;
            case ParseState.Blank:
                state = ParseState.Board1;
                break;
            case ParseState.Board1:
                board_lines[0] = line;
                state = ParseState.Board2;
                break;
            case ParseState.Board2:
                board_lines[1] = line;
                state = ParseState.Board3;
                break;
            case ParseState.Board3:
                board_lines[2] = line;
                state = ParseState.Board4;
                break;
            case ParseState.Board4:
                board_lines[3] = line;
                state = ParseState.Board5;
                break;
            case ParseState.Board5:
                board_lines[4] = line;
                state = ParseState.Blank;
                yield return new BoardDefinition(board_lines);
                break;
            case ParseState.None:
            default:
                yield break;
        }
    }

    public class NumberSequence : BingoItem
    {
        public readonly int[] Sequence;

        public NumberSequence(string line) => Sequence = line.Split(",", StringSplitOptions.TrimEntries).SelectWhere<string,int>(int.TryParse).ToArray();
    }

    public class BoardDefinition : BingoItem
    {
        public readonly int[][] Board;

        public BoardDefinition(params string[] lines) => Board =
            lines.Select(line =>
                line.Split(' ', StringSplitOptions.TrimEntries)
                    .SelectWhere<string, int>(int.TryParse)
                    .ToArray())
                .ToArray();
    }
        
}