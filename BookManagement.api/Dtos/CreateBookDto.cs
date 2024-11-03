namespace BookManagement.api.Dtos;

public record class CreateBookDto(
    string Title,
    int PublishYear,
    string Author
);