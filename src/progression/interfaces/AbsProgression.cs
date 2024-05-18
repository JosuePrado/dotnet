using System.Collections;

public abstract class AbsProgression<T> : IProgression<T> where T : IPivot, new()
{
    public int Limit { get; protected set; }
    protected T Pivot { get; set; }
    public AbsProgression(int limit) 
    {
        Limit = limit;
        Pivot = new T();
        Pivot.limit = limit;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return Pivot;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}