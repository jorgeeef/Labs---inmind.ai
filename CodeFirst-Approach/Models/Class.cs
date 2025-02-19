namespace CodeFirst_Approach.Models;

public class Class
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string ClassTime { get; set; }

    public Course Course { get; set; }
}