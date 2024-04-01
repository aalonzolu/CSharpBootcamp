var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var books = new List<Book>
{
    new Book(1, "The Fellowship of the Ring", new DateTime(1954, 7, 29)),
    new Book(2, "The Two Towers", new DateTime(1954, 11, 11)),
    new Book(3, "The Return of the King", new DateTime(1955, 10, 20))
};


app.MapGet("/books", () => books)
    .WithName("GetBooks")
    .WithOpenApi();

app.Run();


record Book(int Id, string Name, DateTime PublishDate);