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
            Author = book.Author,
            CreateAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
    public static Book ToEntity(this UpdateBookDto book, int id)
    {
        return new Book()
        {
            Id = id,
            Title = book.Title,
            PublishYear = book.PublishYear,
            Author = book.Author,
            UpdatedAt = DateTime.UtcNow
        };
    }

    public static BookDto ToDto(this Book book)
    {
        return new BookDto(
            book.Id,
            book.Title,
            book.PublishYear,
            book.Author,
            book.CreateAt,
            book.UpdatedAt
        );
    }

}
