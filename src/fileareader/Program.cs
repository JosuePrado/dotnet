
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace FirstClass
{
 public class Mains {
        static void Executes ()
        {
           Console.WriteLine("entrado en mains");
            var progression = new FibP(10);
            var list = progression;
            foreach (var current in progression) 
            {   
                Console.WriteLine(current);
            }

            Console.WriteLine("saliendo de mains");
        }
    }   
}