namespace GuineasECS;

public class SparseSet<T>
{
    public const int NULL_INDEX = -1;

    public int[] Sparse;
    public T?[] Dense;

    public int Length => Dense.Length;

    public SparseSet()
    {
        Sparse = [];
        Dense = [];
    }

    public void Clear()
    {
        Array.Clear(Sparse);
        Array.Clear(Dense);
    }

    public void Set(int index, T item)
    {
        if (index > Sparse.Length - 1)
        {
            Array.Resize(ref Sparse, index + 1);
        }
        Sparse[index] = Dense.Length;

        Array.Resize(ref Dense, Dense.Length + 1);
        Dense[^1] = item;
    }

    public T? Get(int index)
    {
        var denseIndex = Sparse[index];
        if (denseIndex != NULL_INDEX) return Dense[denseIndex];
        return default;
    }

    public bool Contains(int index)
    {
        var denseIndex = Sparse[index];
        if (denseIndex != NULL_INDEX) return true;
        return false;
    }

    public void Delete(int index)
    {
        var denseIndex = Sparse[index];

        (Dense[denseIndex], Dense[^1]) = (Dense[^1], Dense[denseIndex]);
        Dense[^1] = default;

        Sparse[^1] = denseIndex;
        Sparse[index] = NULL_INDEX;

        Array.Resize(ref Dense, Length - 1);
    }
}
