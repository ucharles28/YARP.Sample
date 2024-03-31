using MoviesAPI;

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

var movies = new MovieFaker().Generate(100);

app.MapGet("/movies", () => movies).WithOpenApi();
app.MapGet("/movies/{id}", (int id) =>
{
    var movie = movies.FirstOrDefault(p => p.Id == id);

    return movie is not null ? Results.Ok(movie) : Results.NotFound();
}).WithOpenApi();

app.Run();