public class Client6
{
    public static void Main ()
    {
        print0();
        print1();
        print2();
        print3();
        print4();
    }

    private static void print0()
    {
        var response = (from student in DataBase.Students
        where student.LastName == "pardo"
        select new
        {
        student.Id,
        student.Name
        });

        var response2 = DataBase.Students
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
            from student in DataBase.Students 
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

    private static void print1() 
    { 
      // 1 Students of SE that has taken "Calculo" on the fifth semester
       var result = from student in DataBase.Students
                     join study in DataBase.Studies on student.Id equals study.IdStudent
                     join career in DataBase.Careers on study.IdCareer equals career.Id
                     join take in DataBase.Takes on student.Id equals take.IdStudent
                     join subject in DataBase.Subjects on take.IdSubject equals subject.Id
                     where career.Name == "SO" && subject.Name == "Calculo" && take.Semester == 5
                     select student;
        
        foreach (var student in result)
        {
            Console.WriteLine($"{student.Name} {student.LastName}");
        }

        // 1 Students of SE that has taken "Calculo" on the fifth semester
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
    }

    private static void print2()
    {

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

        // 2 Students older than 21 of "Comercial"
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

    }

    private static void print3()
    {
        // 3  subjects with no fail students
        var subjectsWithNoFailingStudentsQuery = 
            (from subject in DataBase.Subjects
            where !(from take in DataBase.Takes
            where take.IdSubject == subject.Id && take.Grades < 51
            select take).Any()
            select new { subject.Name, subject.Code })
            .ToList();

        foreach (var subject in subjectsWithNoFailingStudentsQuery)
        {
            Console.WriteLine($"{subject.Name} ({subject.Code})");
        }

        // 3 subjects with no fail students
            var subjectsWithNoFailingStudents = DataBase.Subjects
            .Where(subject => !DataBase.Takes
            .Any(take => take.IdSubject == subject.Id && take.Grades < 60)) // Asumiendo que la nota mínima para aprobar es 60
            .Select(subject => new { subject.Name, subject.Code })
            .ToList();

        foreach (var subject in subjectsWithNoFailingStudents)
        {
            Console.WriteLine($"{subject.Name} ({subject.Code})");
        }

    }

    private static void print4()
    {
        
        // 4 number of students of  SE witch more that 10 subjects approved
        var studentsInSEWithMoreThan10SubjectsApproved = DataBase.Students
            .Join(DataBase.Studies, student => student.Id, study => study.IdStudent, (student, study) => new { student, study })
            .Join(DataBase.Careers, ss => ss.study.IdCareer, career => career.Id, (ss, career) => new { ss.student, career })
            .Where(sc => sc.career.Name == "Software Engineering")
            .Select(sc => new
            {
                sc.student.Id,
                ApprovedSubjectsCount = DataBase.Takes
                    .Count(take => take.IdStudent == sc.student.Id && take.Grades >= 60) // Asumiendo que 60 es la nota mínima para aprobar
            })
            .Where(x => x.ApprovedSubjectsCount > 10)
            .Count();

        // 4 number of students of  SE witch more that 10 subjects approved
        var studentsInSEWithMoreThan10SubjectsApprovedQuery = 
            (from student in DataBase.Students
            join study in DataBase.Studies on student.Id equals study.IdStudent
            join career in DataBase.Careers on study.IdCareer equals career.Id
            where career.Name == "Software Engineering"
            let approvedSubjectsCount = (from take in DataBase.Takes
                                        where take.IdStudent == student.Id && take.Grades >= 60 // Asumiendo que 60 es la nota mínima para aprobar
                                        select take).Count()
            where approvedSubjectsCount > 10
            select student).Count();

        Console.WriteLine($"Number of SE students with more than 10 approved subjects: {studentsInSEWithMoreThan10SubjectsApprovedQuery}");
    }
}