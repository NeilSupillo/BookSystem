using System;
using BookManagement.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.api.Data;

// db context is a session with the database that can be used to query save instances of entities
public class BookContext(DbContextOptions<BookContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();
}
