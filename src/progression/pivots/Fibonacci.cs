using System.Collections;

public class Fibonacci : IPivot
{

    public Fibonacci() 
    {   
        previous = 0;
        Current = 1;
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
            int aux = previous; 
            previous = Current;
            Current = aux + previous;
            return true;
        } else {
            return false;
        }
        
    }

    public void Reset()
    {
     
    }
}