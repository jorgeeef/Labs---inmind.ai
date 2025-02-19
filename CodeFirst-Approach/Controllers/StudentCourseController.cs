using CodeFirst_Approach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst_Approach.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentCourseController : ControllerBase
{
    private readonly UniversityContext _context;

    public StudentCourseController(UniversityContext context)
    {
        _context = context;
    }

    
    [HttpPost("enroll")]
    public IActionResult EnrollInCourse([FromBody] StudentCourse studentCourse)
    {
        var student = _context.Students.Find(studentCourse.StudentId);  
        var course = _context.Courses.Find(studentCourse.CourseId);    

        if (student == null || course == null)
        {
            return NotFound();
        }

        _context.StudentCourses.Add(studentCourse);
        _context.SaveChanges(); 

        return Ok(studentCourse);  
    }


    [HttpDelete("remove")]
    public IActionResult RemoveFromCourse([FromBody] StudentCourse studentCourse)
    {
        var existingEnrollment = _context.StudentCourses
            .FirstOrDefault(sc => sc.StudentId == studentCourse.StudentId && sc.CourseId == studentCourse.CourseId);  // Synchronous database call

        if (existingEnrollment == null)
        {
            return NotFound();
        }

        _context.StudentCourses.Remove(existingEnrollment);
        _context.SaveChanges(); 

        return NoContent(); 
    }

}