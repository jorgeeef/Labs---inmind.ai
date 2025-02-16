using Lab03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab03.Controllers;

[ApiController]
[Route("[controller]")]
public class LibraryController: ControllerBase
{
    private List<Book> _books = new List<Book>();
    private List<Author> _authors = new List<Author>();
    
    
     public LibraryController()
    {
        _authors.Add(new Author { author_id = 1, name = "Author1", birth_date = new DateTime(1992, 1, 3), country = "Africa" });
        _authors.Add(new Author { author_id = 2, name = "Author3", birth_date = new DateTime(1999, 9, 20), country = "USA" });
        _authors.Add(new Author { author_id = 3, name = "Author4", birth_date = new DateTime(1908, 11, 29), country = "Lebanon" });
        _authors.Add(new Author { author_id = 4, name = "Author5", birth_date = new DateTime(1992, 9, 21), country = "USA" });
        _authors.Add(new Author { author_id = 5, name = "Author6", birth_date = new DateTime(1785, 12, 16), country = "England" });

        _books.Add(new Book { book_id = 1, title = "The Hobbit", author_id = 1, isbn = "978-0547928227", published_year = new DateTime(1785, 12, 17) });
        _books.Add(new Book { book_id = 2, title = "A Game of Thrones", author_id = 2, isbn = "978-0007444465", published_year = new DateTime(1785, 12, 16) });
        _books.Add(new Book { book_id = 3, title = "The Lion, the Witch and the Wardrobe", author_id = 3, isbn = "978-0007115862", published_year = new DateTime(1895, 3, 16) });
        _books.Add(new Book { book_id = 4, title = "The Shining", author_id = 4, isbn = "978-0385121679", published_year = new DateTime(2000, 5, 20) });
        _books.Add(new Book { book_id = 5, title = "Pride and Prejudice", author_id = 5, isbn = "978-0141439518", published_year = new DateTime(2003, 1, 16) });
    }
    

    public enum SortOrder
    {
        Ascending,
        Descending
    }

    [HttpGet("books/published/{year}")]
    public IActionResult GetBooksPublishedInYear(int year, SortOrder order = SortOrder.Ascending )
    {
        var books = _books.Where(b => b.published_year.Year == year);
        if (books.Count() == 0 )
            return NotFound("No books available for this year.");
        // If user does not choose any order, it will display them in ascending order based on default order parameter (ascending)
        if (order == SortOrder.Descending) 
            books = books.OrderByDescending(b => b.published_year.Month)
                .ThenByDescending(b=> b.published_year.Day);
        return Ok(books.ToList());
    }

    
    [HttpGet("authors/samebirthyear")]
    public IActionResult GetAuthorsBornInSameYear()
    {
        var groupedAuthors = _authors
            .GroupBy(a => a.birth_date.Year)
            .ToList();
        return Ok(groupedAuthors);
    }
    
    
    [HttpGet("authors/samebirthyearandcountry")]
    public IActionResult GetAuthorsBornInSameYearAndCountry()
    {
        var groupedAuthors = _authors
            .GroupBy(a => new { a.birth_date.Year, a.country }) 
            .ToList();

        return Ok(groupedAuthors);
    }
    
    
    [HttpGet("books/count")]
    public IActionResult GetTotalBookCount()
    {
        int totalBooks = _books.Count();
        return Ok(totalBooks);
    }
    
    [HttpGet("books/paged")]
    public ActionResult<IEnumerable<Book>> GetBooksPaged(int numberOfBooksPerPage, int pageNumber)
    {
        var skip = (pageNumber - 1) * numberOfBooksPerPage;  
        var books = _books.Skip(skip).Take(numberOfBooksPerPage); 
        return Ok(books.ToList());
    }


}