
using System.Collections;

public interface IPivot : IEnumerator<int>
{
    int limit {get; set;} 
    int previous { get; set; }

}