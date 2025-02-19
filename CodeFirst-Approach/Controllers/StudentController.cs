using AutoMapper;
using CodeFirst_Approach.Models;
using CodeFirst_Approach.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst_Approach.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController:ControllerBase
{
    private readonly UniversityContext _context;
    private readonly IMapper _mapper;

    public StudentController(UniversityContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    
    [HttpPost("add")]
    public IActionResult AddStudent([FromBody] Student student)
    {
        if (student == null)
        {
            return BadRequest();
        }

        _context.Students.Add(student);
        _context.SaveChanges();  

        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }


    [HttpGet("{id}")]
    public IActionResult GetStudent(int id)
    {
        var student = _context.Students.Find(id);

        if (student == null)
        {
            return NotFound();
        }
        // Map Student to StudentViewModel
        var studentViewModel = _mapper.Map<StudentViewModel>(student);

        return Ok(studentViewModel);
    }

    
    
    [HttpGet]
    public IActionResult GetStudents()
    {
        var students = _context.Students.ToList();

        // Map the list of Students to a list of StudentViewModels
        var studentViewModels = _mapper.Map<List<StudentViewModel>>(students);

        return Ok(studentViewModels);
    }

}