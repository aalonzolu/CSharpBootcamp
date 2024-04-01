
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

List<Book> books = new List<Book>();

app.MapGet("/api/books", () => books);


app.MapGet("/api/books/{id}", (int id) =>
{
    var book = books.FirstOrDefault(b => b.ID == id);
    if (book == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(book);
}).WithName("GetBookById").Produces<Book>(statusCode: 200).Produces(404);


app.MapPost("/api/books", (Book book) =>
{
    book.ID = books.Count + 1;
    books.Add(book);
    return Results.Created($"/api/books/{book.ID}", book);
}).Produces<Book>(statusCode: 201);

app.MapPut("/api/books/{id}", (int id, Book book) =>
{
    var existingBook = books.FirstOrDefault(b => b.ID == id);
    if (existingBook == null)
    {
        return Results.NotFound();
    }
    existingBook.Title= book.Title;
    existingBook.Author = book.Author;
    return Results.Ok(existingBook);
}).Produces<Book>(statusCode: 200).Produces(404);

app.MapDelete("/api/books/{id}", (int id) =>
{
    var book = books.FirstOrDefault(b => b.ID == id);
    if (book == null)
    {
        return Results.NotFound();
    }
    books.Remove(book);
    return Results.NoContent();
}).Produces(statusCode: 204).Produces(404);

app.Run();