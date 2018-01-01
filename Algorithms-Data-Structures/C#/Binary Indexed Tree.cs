/// <summary>
/// A class for creating and manipulating a binary indexed tree supporting value changes and interval sum operations.
/// </summary>
public class BinaryIndexedTree
{
    public int[] CreateTree(int[] Array)
    {
        int[] BIT = new int[Array.Length + 1];
        for (int i = 0; i < Array.Length; i++)
            Update(BIT, i + 1, Array[i]);

        return BIT;
    }

    public void Update(int[] BIT, int index, int delta)
    {
        index++; //Index in BIT is 1 more than index in original array
        for (int i = index; i < BIT.Length; i = Next(i))
            BIT[i] += delta;
    }

    /// <summary>
    /// Returns the sum on the interval [start,end]
    /// </summary>
    public int IntervalSum(int[] BIT, int start, int end)
    {
        return GetSum(BIT, end) - GetSum(BIT, start - 1);
    }

    private int GetSum(int[] BIT, int index)
    {
        index++;
        int sum = 0;
        for (int i = index; i > 0; i = Parent(i))
            sum += BIT[i];

        return sum;
    }

    private int Parent(int index)
    {
        return index - (index & -index);
    }

    private int Next(int index)
    {
        return index + (index & -index);
    }
}

