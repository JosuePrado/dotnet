public class Student 
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string LastName { get; set; } 

    public Student (int id, string name, string lastName) 
    {
        Id = id;
        Name = name;
        LastName = lastName;
    }

}