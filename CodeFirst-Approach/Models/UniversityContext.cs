using Microsoft.EntityFrameworkCore;

namespace CodeFirst_Approach.Models;

public class UniversityContext: DbContext
{
    public UniversityContext(DbContextOptions<UniversityContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });  // Composite key

        base.OnModelCreating(modelBuilder);
     
    }
    
    
}