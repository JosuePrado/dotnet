using System.Linq;

public class Client 
{
    static void Main(string[] args)
        {
           Console.WriteLine("entrado en mains");
            var progression = new FibP(12);
            var list = progression;
            foreach (var current in list) 
            {   
                Console.WriteLine(current);
            }

            Console.WriteLine("---------------");

            var progression2 = new FacP(121);
            var list2 = progression2;
            foreach (var current in list2) 
            {   
                Console.WriteLine(current);
            }

            Console.WriteLine("saliendo de mains");
        }
}