using System.Collections;

public class Factorial : IPivot
{
    public Factorial()
    {
        previous = 1;   
        Current = 1;
        count = 1;
    }

    public int limit { get; set; }
    public int Current { get; set; }
    public int previous { get; set; }
    public int count { get; set; }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (Current < limit) 
            {
            previous = Current;
            Current = previous * count;
            count++;
            return true;
        } 
        else 
        {
            return false;
        }   
    }

    public void Reset()
    {
        
    }
}