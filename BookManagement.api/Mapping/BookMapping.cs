using System;
using BookManagement.api.Dtos;
using BookManagement.api.Entities;

namespace BookManagement.api.Mapping;

// helper class for mapping
public static class BookMapping
{
    public static Book ToEntity(this CreateBookDto book)
    {
        return new Book()
        {
            Title = book.Title,
            PublishYear = book.PublishYear,
            Author = book.Author
        };
    }

    public static BookDto ToDto(this Book book)
    {
        return new BookDto(
            book.Id,
            book.Title,
            book.PublishYear,
            book.Author
        );
    }

}
