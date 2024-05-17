using System.Collections;

public class Factorial : IPivot
{
    public Factorial()
    {
        limit = 0;
        Current = 0;
    }

    public int limit { get; set; }

    public int Current { get; set; }

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