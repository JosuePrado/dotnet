public class Takes
 {
    public int IdStudent { get; set; } 
    public  int IdSubject { get; set; }
    public int Semester { get; set; }
    public int Grades { get; set; }

    public Takes (int idStudent, int idSubject, int semester, int grades) {
      IdStudent = idStudent;
      IdSubject = idSubject;
      Semester = semester;
      Grades = grades;
    }
 }