namespace Day4;

public static class BingoMaskExtensions
{
    public const int ROW_SET = 0b11111;
    public const int COLUMN_SET = 0b00001;

    private static int RowMask(int row) => ROW_SET << (row * 5);
    private static int ColumnMask(int column) => 0
        | (COLUMN_SET << ((column + 0) % 5) << 0)
        | (COLUMN_SET << ((column + 1) % 5) << 5)
        | (COLUMN_SET << ((column + 2) % 5) << 10)
        | (COLUMN_SET << ((column + 3) % 5) << 15)
        | (COLUMN_SET << ((column + 4) % 5) << 20);

    public const int ROW_0_SET = ROW_SET << 0;
    public const int ROW_1_SET = ROW_SET << 5;
    public const int ROW_2_SET = ROW_SET << 10;
    public const int ROW_3_SET = ROW_SET << 15;
    public const int ROW_4_SET = ROW_SET << 20;
    public const int COLUMN_0_SET = (COLUMN_SET << 0 << 0) | (COLUMN_SET << 0 << 5) | (COLUMN_SET << 0 << 10) | (COLUMN_SET << 0 << 15) | (COLUMN_SET << 0 << 20);
    public const int COLUMN_1_SET = (COLUMN_SET << 1 << 0) | (COLUMN_SET << 1 << 5) | (COLUMN_SET << 1 << 10) | (COLUMN_SET << 1 << 15) | (COLUMN_SET << 1 << 20);
    public const int COLUMN_2_SET = (COLUMN_SET << 2 << 0) | (COLUMN_SET << 2 << 5) | (COLUMN_SET << 2 << 10) | (COLUMN_SET << 2 << 15) | (COLUMN_SET << 2 << 20);
    public const int COLUMN_3_SET = (COLUMN_SET << 3 << 0) | (COLUMN_SET << 3 << 5) | (COLUMN_SET << 3 << 10) | (COLUMN_SET << 3 << 15) | (COLUMN_SET << 3 << 20);
    public const int COLUMN_4_SET = (COLUMN_SET << 4 << 0) | (COLUMN_SET << 4 << 5) | (COLUMN_SET << 4 << 10) | (COLUMN_SET << 4 << 15) | (COLUMN_SET << 4 << 20);

    public static bool IsBingo(this int mask) =>
           (mask & ROW_0_SET) == ROW_0_SET
        || (mask & ROW_1_SET) == ROW_1_SET
        || (mask & ROW_2_SET) == ROW_2_SET
        || (mask & ROW_3_SET) == ROW_3_SET
        || (mask & ROW_4_SET) == ROW_4_SET
        || (mask & COLUMN_0_SET) == COLUMN_0_SET
        || (mask & COLUMN_1_SET) == COLUMN_1_SET
        || (mask & COLUMN_2_SET) == COLUMN_2_SET
        || (mask & COLUMN_3_SET) == COLUMN_3_SET
        || (mask & COLUMN_4_SET) == COLUMN_4_SET;
}
