
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Day4;

public readonly struct BingoBoardState
{
    private readonly int _mask;
    private readonly int _size;
    private readonly int[] _data;

    public BingoBoardState(params int[][] board)
    {
        _mask = 0;
        _size = board.Length * board.Length; // assumes square
        _data = new int[_size];
        for (int i = 0; i < _size; i++)
            _data[i] = board[i / board.Length][i % board.Length];
    }

    private BingoBoardState(BingoBoardState previous, int number)
    {
        var index = previous.IndexOf(number);
        _mask = index >= 0 ? previous._mask | (1 << index) : previous._mask;
        _size = previous._size;
        _data = previous._data;
    }

    public bool IsBingo => _mask.IsBingo();

    public int IndexOf(int value) => _data.AsSpan().IndexOf(value);

    public static BingoBoardState operator <<(BingoBoardState state, int value) => new(state, value);

    public IEnumerable<int> Values(bool? set = null)
    {
        int mask = _mask;
        for (int i = 0; i < 25; i++)
        {
            bool is_set = (mask & 1) == 1;
            mask >>= 1;
            if (is_set == set)
                yield return _data[i];
            if (set == true && mask == 0)
                yield break;
        }
    }
}
