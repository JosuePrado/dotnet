using System.Collections;

public class Factorial : IPivot
{
    public Factorial()
    {
        previous = 0;
        limit = 0;
        Current = 0;
    }

    public int limit { get; set; }

    public int Current { get; set; }
    public int previous { get; set; }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        return true;
    }

    public void Reset()
    {
        
    }
}