﻿// <auto-generated />
using BookManagement.api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookManagement.api.Data.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1");

            modelBuilder.Entity("BookManagement.api.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PublishYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "J.D. Salinger",
                            PublishYear = 1951,
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Harper Lee",
                            PublishYear = 1960,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 3,
                            Author = "George Orwell",
                            PublishYear = 1949,
                            Title = "1984"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
