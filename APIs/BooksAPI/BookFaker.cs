using Bogus;

namespace BooksAPI;

public class BookFaker : Faker<Book>
{
    private static int id = 1;
    public BookFaker()
    {
        RuleFor(d => d.Id, f => id++);
        RuleFor(d => d.BookTitle, f => f.Company.CompanyName());
        RuleFor(d => d.PublishDate, f => f.Date.Past());
        RuleFor(d => d.AuthorName, f => f.Name.FullName());
    }
}