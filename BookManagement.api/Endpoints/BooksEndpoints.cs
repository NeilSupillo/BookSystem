using System;
using BookManagement.api.Data;
using BookManagement.api.Dtos;
using BookManagement.api.Entities;

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

            Book book = new()
            {
                Title = bookDto.Title,
                PublishYear = bookDto.PublishYear,
                Author = bookDto.Author
            };
            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            BookDto returnBook = new(
                book.Id,
                book.Title,
                book.PublishYear,
                book.Author
            );

            return Results.CreatedAtRoute(GetBookEndpoint, new { id = book.Id }, returnBook);
        }).WithParameterValidation();

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
        }).WithParameterValidation();

        group.MapDelete("/{id}", (int id) =>
        {
            books.RemoveAll(book => book.Id == id);
            return Results.NoContent();
        }).WithParameterValidation();
        return group;
    }

}
