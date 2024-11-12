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

        group.MapGet("/", (BookContext dbContext) =>
            dbContext.Books
                .Select(books => books.ToDto())
                .AsNoTracking()
        );

        group.MapGet("/{id}", (int id, BookContext dbContext) =>
        {

            Book? book = dbContext.Books.Find(id);

            return book is null ? Results.NotFound() : Results.Ok(book.ToDto());

        }).WithName(GetBookEndpoint);

        group.MapPost("/", (CreateBookDto bookDto, BookContext dbContext) =>
        {
            Book book = bookDto.ToEntity();

            dbContext.Books.Add(book);
            dbContext.SaveChanges();



            return Results.CreatedAtRoute(GetBookEndpoint, new { id = book.Id }, book.ToDto());
        });

        group.MapPut("/{id}", (int id, UpdateBookDto bookDto, BookContext dbContext) =>
        {
            //var index = books.FindIndex(bookDto => bookDto.Id == id);
            var existingBook = dbContext.Books.Find(id);

            if (existingBook is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existingBook)
                .CurrentValues
                .SetValues(bookDto.ToEntity(id));

            dbContext.SaveChanges();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id, BookContext dbContext) =>
        {
            //books.RemoveAll(book => book.Id == id);

            dbContext.Books.
                Where(books => books.Id == id)
                    .ExecuteDelete();

            return Results.NoContent();
        });
        return group;
    }

}
