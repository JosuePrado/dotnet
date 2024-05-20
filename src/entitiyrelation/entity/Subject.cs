public class Subject 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public int Credits { get; set; }

    public Subject (int id, string name, string code, int credits) {
        Id = id;
        Name = name;
        Code = code;
        Credits = credits;
    }
}