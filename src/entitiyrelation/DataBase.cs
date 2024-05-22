using Microsoft.VisualBasic;

public class DataBase
{

    public static List<Student> Students = new List<Student>
        {
            new(1, "jose", "pardo"),
            new(2, "luis", "barra"),
            new(3, "sebas", "mendoza"),
            new(4, "vicente", "pizzo"),
            new(5, "santiago", "cocha"),
        };
    public static List<Career> Careers = new List<Career>
            {
                new Career(1, "SO"),
                new Career(2, "EE"),
                new Career(3, "PO"),
                new Career(4, "IN"),
                new Career(5, "SIS"),
            };
    

    public static List<Subject> Subjects = new List<Subject> 
        {
            new(1, "calculo", "cd1", 4),
            new(2, "calculo2", "cd2", 5),
            new(3, "calculo3", "cd3", 6),
            new(4, "calculo4", "cd4", 7),
        };

    public static List<Takes> Takes = new List<Takes> 
        {
            new Takes(1, 1, 5, 85), 
            new Takes(2, 3, 5, 90),
            new Takes(3, 4, 3, 92),
            new Takes(4, 5, 2, 50),
            new Takes(1, 2, 4, 40),
        };

    public static List<Has> Has = new List<Has>
        {
            new Has(1, 1),
            new Has(2, 2),
            new Has(3, 3),
            new Has(4, 4),
        };
    public static List<Study> Studies = new List<Study>
        {
            new Study(1, 1), 
            new Study(2, 2),
            new Study(3, 3),
            new Study(4, 4),
            new Study(1, 2),
            new Study(2, 3),
            
        };
}
