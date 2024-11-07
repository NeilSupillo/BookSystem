using System;
using BookManagement.api.Data;
using BookManagement.api.Dtos;
using BookManagement.api.Entities;
using BookManagement.api.Mapping;

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
        var group = app.MapGroup("book");

        group.MapGet("/", () => books);

        group.MapGet("/{id}", (int id) =>
        {

            BookDto? book = books.Find((book) => book.Id == id);

            return book is null ? Results.NotFound() : Results.Ok(book);

        }).WithName(GetBookEndpoint);

        group.MapPost("/", (CreateBookDto bookDto, BookContext dbContext) =>
        {
            Book book = bookDto.ToEntity();

            dbContext.Books.Add(book);
            dbContext.SaveChanges();



            return Results.CreatedAtRoute(GetBookEndpoint, new { id = book.Id }, book.ToDto());
        });

        group.MapPut("/{id}", (int id, UpdateBookDto bookDto) =>
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

        group.MapDelete("/{id}", (int id) =>
        {
            books.RemoveAll(book => book.Id == id);
            return Results.NoContent();
        });
        return group;
    }

}
