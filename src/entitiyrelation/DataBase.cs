using Microsoft.VisualBasic;

public class DataBase
{

    public static List<Student> Students = new List<Student>
            {
                new(1, "jose", "pardo"),
                new(2, "luis", "barra"),
                new(3, "sebas", "mendoza"),
                new(4, "vicente", "pizzo"),
            };

    public static List<Takes> Takes = new List<Takes> 
            {
                new(1, 2, 1),
                new(2, 3, 3),
                new(3, 4, 5),
                new(4, 1, 6),
            };

    public static List<Subject> Subjects = new List<Subject> 
    {
        new(1, "calculo", "cd1", 4),
        new(2, "calculo2", "cd2", 5),
        new(3, "calculo3", "cd3", 6),
        new(4, "calculo4", "cd4", 7),
    };
    public static void Main ()
    {
        var response = (from student in DataBase.Students
        where student.LastName == "pardo"
        select new
        {
        student.Id,
        student.Name
        });

        var response2 = Students
        .Where(student => student.LastName == "Vargas")
        .Select(student => new {student.Name, student.Id});

        foreach (var s in response)
        {
        Console.WriteLine(s);
        }

        foreach (var s in response2)
        {
        Console.WriteLine(s);
        }

        var response3 = (
            from student in Students 
            join take in DataBase.Takes on student.Id equals take.IdStudent  
            join subject in DataBase.Subjects on take.IdSubject equals subject.Id 
            where subject.Name == "dev"
            select new 
            {
                subject.Id,
                subject.Name
            }
        );

        var response4 = DataBase.Students
        .Join(DataBase.Takes,
        student => student.Id,
        take => take.IdStudent,
        (student, take) => new {student.Name, student.LastName, take.IdSubject})
        .Join(DataBase.Subjects,
        studentake => studentake.IdSubject,
        subject => subject.Id,
        (studentake, subject) => new {studentake.Name, studentake.LastName, Subject = subject.Name})
        .Where(S => S.Subject == "Software U ");


    }


}
