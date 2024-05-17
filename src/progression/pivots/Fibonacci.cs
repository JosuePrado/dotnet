using System.Collections;

public class Fibonacci : IPivot
{

    public Fibonacci() 
    {   
        previous = 0;
        limit = 0;
        Current = 0;
    }

    public int limit { get; set; }

    public int Current {get; set;}
    public int previous { get; set; }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
     
    }

    public bool MoveNext()
    {
        if (Current < limit) {

        }
        return true;
    }

    public void Reset()
    {
     
    }
}