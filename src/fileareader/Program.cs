
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace FirstClass
{
 public class Mains {
        static void Main(string[] args)
        {
           using var Handle = new FileHandler("a.txt"); 
            {
                var lines = Handle.ReadLines();
                foreach (var line in lines) {
                    Console.WriteLine(line);
                }
            }
        }
    }   
}