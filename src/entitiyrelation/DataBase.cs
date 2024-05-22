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

     private static void Print1() { 
      // Students of SE that has taken "Calculo" on the fifth semester
       var result = from student in Students
                     join study in Studies on student.Id equals study.IdStudent
                     join career in Careers on study.IdCareer equals career.Id
                     join take in Takes on student.Id equals take.IdStudent
                     join subject in Subjects on take.IdSubject equals subject.Id
                     where career.Name == "SO" && subject.Name == "Calculo" && take.Semester == 5
                     select student;

        
        foreach (var student in result)
        {
            Console.WriteLine($"{student.Name} {student.LastName}");
        }

      // Students older than 21 of "Comercial"
        var olderStudentsInComercialQuery = 
        (from student in DataBase.Students
        join study in DataBase.Studies on student.Id equals study.IdStudent
        join career in DataBase.Careers on study.IdCareer equals career.Id
        where career.Name == "Comercial" && student.Age > 21
        select new { student.Name, student.LastName, student.Age })
        .ToList();

        foreach (var student in olderStudentsInComercialQuery)
            {
                Console.WriteLine($"{student.Name} {student.LastName}, Age: {student.Age}");
            }

      // subjects with no fail students
      var subjectsWithNoFailingStudentsQuery = 
     (from subject in DataBase.Subjects
     where !(from take in DataBase.Takes
             where take.IdSubject == subject.Id && take.Grades < 60 // Asumiendo que la nota mínima para aprobar es 60
             select take).Any()
        select new { subject.Name, subject.Code })
        .ToList();

foreach (var subject in subjectsWithNoFailingStudentsQuery)
{
    Console.WriteLine($"{subject.Name} ({subject.Code})");
}

      var failNO = DataBase.Subjects
        .Where(subject => !failingGrades.Contains(subject.ID))
        .Select(subject => new { subject.Name });

    // number of students of  SE witch more that 10 subjects approved
    var approved = DataBase.Students
      .Where(student => student.CareerId == 100)
      .Select(student => new { student, approvedSubjectsCount = DataBase.grades.Count(grade => grade.StudentID == student.ID && grade.GradeValue >= 51) })
      .Where(studentApprovedSubjectsCount => studentApprovedSubjectsCount.approvedSubjectsCount >= 10)
      .Count();

    }
    private static void Print2(){
        // Students of SE that has taken "Calculo" on the fifth semester
         var calculus = DataBase.Students
            .Join(DataBase.Studies, student => student.Id, study => study.IdStudent, (student, study) => new { student, study })
            .Join(DataBase.Careers, ss => ss.study.IdCareer, career => career.Id, (ss, career) => new { ss.student, career })
            .Join(DataBase.Takes, sc => sc.student.Id, takes => takes.IdStudent, (sc, takes) => new { sc.student, sc.career, takes })
            .Join(DataBase.Subjects, sct => sct.takes.IdSubject, subject => subject.Id, (sct, subject) => new { sct.student, sct.career, sct.takes, subject })
            .Where(s => s.career.Name == "Software Engineering" && s.subject.Name == "Calculo" && s.takes.Semester == 5)
            .Select(s => new { s.student.Name, s.student.LastName })
            .ToList();

        foreach (var student in calculus)
        {
            Console.WriteLine($"1. {student.Name} {student.LastName}");
        }


        // Students older than 21 of "Comercial"
        var olderStudentsInComercial = DataBase.Students
        .Join(DataBase.Studies, student => student.Id, study => study.IdStudent, (student, study) => new { student, study })
        .Join(DataBase.Careers, ss => ss.study.IdCareer, career => career.Id, (ss, career) => new { ss.student, career })
        .Where(sc => sc.career.Name == "Comercial" && sc.student.Age > 21)
        .Select(sc => new { sc.student.Name, sc.student.LastName, sc.student.Age })
        .ToList();

        foreach (var student in olderStudentsInComercial)
            {
            Console.WriteLine($"{student.Name} {student.LastName}, Age: {student.Age}");
            }

        //  subjects with no fail students
            var subjectsWithNoFailingStudents = DataBase.Subjects
            .Where(subject => !DataBase.Takes
            .Any(take => take.IdSubject == subject.Id && take.Grades < 60)) // Asumiendo que la nota mínima para aprobar es 60
            .Select(subject => new { subject.Name, subject.Code })
            .ToList();

foreach (var subject in subjectsWithNoFailingStudents)
{
    Console.WriteLine($"{subject.Name} ({subject.Code})");
}

        var r3 = (
        from subject in DataBase.Subjects
        where !failingGrades.Contains(subject.ID)
        select new { subject.Name }
        );

        // number of students of  SE witch more that 10 subjects approved
        var r4 = (
        from student in DataBase.Students
        where student.CareerId == 100
        let approvedSubjectsCount = DataBase.grades.Count(grade => grade.StudentID == student.ID && grade.GradeValue >= 51)
        where approvedSubjectsCount >= 10
        select student
        ).Count();
    }
    }


}
