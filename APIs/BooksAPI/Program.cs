using Bogus;
using BooksAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var books = new BookFaker().Generate(100);

app.MapGet("/books", () => books).WithOpenApi();
app.MapGet("/books/{id}", (int id) =>
{
    var book = books.FirstOrDefault(p => p.Id == id);

    return book is not null ? Results.Ok(book) : Results.NotFound();
}).WithOpenApi();

app.Run();
