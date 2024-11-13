using System;
using BookManagement.api.Data;
using BookManagement.api.Dtos;
using BookManagement.api.Entities;
using BookManagement.api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.api.Endpoints;

public static class BooksEndpoints
{
    const string GetBookEndpoint = "GetBook";

    public static RouteGroupBuilder MapBooksEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("book");

        group.MapGet("/", async (BookContext dbContext) =>
            await dbContext.Books
                .Select(books => books.ToDto())
                .AsNoTracking()
                .ToListAsync()
        );

        group.MapGet("/{id}", async (int id, BookContext dbContext) =>
        {

            Book? book = await dbContext.Books.FindAsync(id);

            return book is null ? Results.NotFound() : Results.Ok(book.ToDto());

        }).WithName(GetBookEndpoint);

        group.MapPost("/", async (CreateBookDto bookDto, BookContext dbContext) =>
        {
            Book book = bookDto.ToEntity();

            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();



            return Results.CreatedAtRoute(GetBookEndpoint, new { id = book.Id }, book.ToDto());
        });

        group.MapPut("/{id}", async (int id, UpdateBookDto bookDto, BookContext dbContext) =>
        {
            //var index = books.FindIndex(bookDto => bookDto.Id == id);
            var existingBook = await dbContext.Books.FindAsync(id);

            if (existingBook is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existingBook)
                .CurrentValues
                .SetValues(bookDto.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, BookContext dbContext) =>
        {
            //books.RemoveAll(book => book.Id == id);

            await dbContext.Books.
                Where(books => books.Id == id)
                    .ExecuteDeleteAsync();

            return Results.NoContent();
        });
        return group;
    }

}
