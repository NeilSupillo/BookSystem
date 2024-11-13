namespace BookManagement.api.Dtos;
// a record class not a simple class/ immutable
public record class BookDto(
    int Id,
    string Title,
    int PublishYear,
    string Author,
    DateTime CreatedAt,
    DateTime UpdatedAt

);
// Schema::create('books', function (Blueprint $table) {
//             $table->id();
//             $table->string('title');
//             $table->integer('publishYear'); // Use integer for numbers
//             $table->string('author');
//             $table->timestamps();
//         });