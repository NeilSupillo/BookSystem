using System;
using BookManagement.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.api.Data;

// db context is a session with the database that can be used to query save instances of entities
public class BookContext(DbContextOptions<BookContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();

    //database seeding
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "The Catcher in the Rye",
                Author = "J.D. Salinger",
                PublishYear = 1951
            },
            new Book
            {
                Id = 2,
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                PublishYear = 1960
            },
            new Book
            {
                Id = 3,
                Title = "1984",
                Author = "George Orwell",
                PublishYear = 1949
            }
        );
    }

}
