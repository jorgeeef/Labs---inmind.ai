using AutoMapper;
using CodeFirst_Approach.Models;
using CodeFirst_Approach.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst_Approach.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController: ControllerBase
{
    private readonly UniversityContext _context;
    private readonly IMapper _mapper;

    public CourseController(UniversityContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    
    [HttpPost("add")]
    public IActionResult AddCourse([FromBody] Course course)
    {
        if (course == null)
        {
            return BadRequest();
        }

        _context.Courses.Add(course);
        _context.SaveChanges();  

        return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
    }

    
    [HttpGet("{id}")]
    public IActionResult GetCourse(int id)
    {
        var course = _context.Courses.Find(id); 

        if (course == null)
        {
            return NotFound();
        }
        
        var courseViewModel = _mapper.Map<CourseViewModel>(course);

        return Ok(courseViewModel);
    }

   
    [HttpGet]
    public IActionResult GetCourses()
    {
        var courses = _context.Courses.ToList();  


        // Map the list of Courses to a list of CourseViewModels
        var courseViewModels = _mapper.Map<List<CourseViewModel>>(courses);

        return Ok(courseViewModels);
    }
    
}