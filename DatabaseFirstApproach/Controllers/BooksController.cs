using DatabaseFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace DatabaseFirstApproach.Controllers;

[Route("odata/[controller]")]
[ApiController]
public class BooksController:ODataController
{
    private readonly LibrarydbContext _context;

    public BooksController(LibrarydbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [EnableQuery]
    public IActionResult GetAllBooks()
    {
        return Ok(_context.Books);
    }
    
    [HttpGet("GetBooksByYear")]
    public IActionResult GetBooksByYear(int year, string order = "asc")
    {
        var books = _context.Books
            .Where(b => b.PublishedYear == year)
            .OrderBy(b => order == "asc" ? b.PublishedYear : (int?)null);
        return Ok(books);
    }


    [HttpGet("TotalBooks")]
    public IActionResult GetTotalBooks()
    {
        var TotalBooks = _context.Books.Count();   
        return Ok(TotalBooks);
    }
    
    [HttpGet("PaginatedBooks")]
    public IActionResult GetPaginatedBooks(int pageNumber, int pageSize)
    {
        var books = _context.Books
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return Ok(books);
    }
}
