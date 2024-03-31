using Bogus;

namespace MoviesAPI;

public class MovieFaker : Faker<Movie>
{
    private static int id = 1;
    public MovieFaker()
    {
        RuleFor(d => d.Id, f => id++);
        RuleFor(d => d.Title, f => f.Random.Words());
        RuleFor(d => d.Description, f => f.Random.Words());
    }
}