namespace Common.DataStructures;

public struct CircularBuffer<T>
{
    private int cursor = 0;
    public int Count => cursor;
    public int Cursor => cursor % buffer.Length;
    public int Capacity => buffer.Length;
    private readonly T[] buffer;

    public CircularBuffer(int size) => buffer = new T[size];

    public T this[Index i]
    {
        get
        {
            int index = i.IsFromEnd 
                ? Count - i.Value  - 1
                : (Count < Capacity
                    ? i.Value
                    : Count + i.Value);
            if (index < 0)
                throw new IndexOutOfRangeException();
            return buffer[index % buffer.Length];
        }
    }

    /// <summary>
    /// Appends a value to a circular buffer.
    /// </summary>
    /// <param name="value">Value to append to the buffer</param>
    /// <param name="replaced">Value that may have been replaced by the added value</param>
    /// <returns>true if a value was replaced, false if no data was replaced</returns>
    public bool Add(T value, out T replaced)
    {
        bool wrapped = cursor >= buffer.Length;
        replaced = buffer[Cursor];
        buffer[Cursor] = value;
        cursor++;
        return wrapped;
    }
}