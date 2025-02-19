namespace CodeFirst_Approach.Models;

public class Teacher
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public ICollection<Course> Courses { get; set; }
}