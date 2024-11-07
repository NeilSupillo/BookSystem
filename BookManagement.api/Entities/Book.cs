using System;

namespace BookManagement.api.Entities;

public class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required int PublishYear { get; set; }
    public required string Author { get; set; }
}
// Schema::create('books', function (Blueprint $table) {
//             $table->id();
//             $table->string('title');
//             $table->integer('publishYear'); // Use integer for numbers
//             $table->string('author');
//             $table->timestamps();
//         });