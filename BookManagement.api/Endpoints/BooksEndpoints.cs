using System;
using BookManagement.api.Dtos;

namespace BookManagement.api.Endpoints;

public static class BooksEndpoints
{
    const string GetBookEndpoint = "GetBook";
    private static readonly List<BookDto> books = [
    new (
    1,
    "hxt",
    2017,
    "togashi"
),
new (
    2,
    "alya",
    2024,
    "idk"
),
];

    public static RouteGroupBuilder MapBooksEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("books");

        group.MapGet("/books", () => books);

        group.MapGet("/book/{id}", (int id) =>
        {

            BookDto? book = books.Find((book) => book.Id == id);

            return book is null ? Results.NotFound() : Results.Ok(book);

        }).WithName(GetBookEndpoint);

        group.MapPost("/book", (CreateBookDto bookDto) =>
        {

            BookDto book = new(
                books.Count + 1,
                bookDto.Title,
                bookDto.PublishYear,
                bookDto.Author
            );
            books.Add(book);
            return Results.CreatedAtRoute(GetBookEndpoint, new { id = book.Id }, book);
        });

        group.MapPut("/book/{id}", (int id, UpdateBookDto bookDto) =>
        {
            var index = books.FindIndex(bookDto => bookDto.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }
            books[index] = new BookDto(
               id,
               bookDto.Title,
               bookDto.PublishYear,
               bookDto.Author
               );
            return Results.NoContent();
        });

        group.MapDelete("/book/{id}", (int id) =>
        {
            books.RemoveAll(book => book.Id == id);
            return Results.NoContent();
        });
        return group;
    }

}
