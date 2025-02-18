using DatabaseFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace DatabaseFirstApproach.Controllers;

[Route("odata/[controller]")]
[ApiController]
public class AuthorsController: ODataController
{
    private readonly LibrarydbContext _context;

    public AuthorsController(LibrarydbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [EnableQuery]
    public IActionResult GetAllAuthors()
    {
        return Ok(_context.Authors);
    }
    
    [HttpGet("GroupByBirthYear")]
    public IActionResult GetAuthorsGroupedByYear()
    {
        var groups = _context.Authors
            .GroupBy(a => a.BirthDate);

        return Ok(groups);
    }
    
    [HttpGet("GroupByBirthYearAndCountry")]
    public IActionResult GetAuthorsGroupedByYearAndCountry()
    {
        var groups = _context.Authors
            .GroupBy(a => new { a.BirthDate, a.Country });
        
        return Ok(groups);
    }
}