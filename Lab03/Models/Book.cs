namespace Lab03.Models;

public class Book
{
    public int book_id { get; set; }
    public string title { get; set; }
    public int author_id { get; set; }
    public string isbn { get; set; }
    public DateTime published_year { get; set; }
}