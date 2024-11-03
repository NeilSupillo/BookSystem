namespace BookManagement.api.Dtos;

public record class UpdateBookDto(
    string Title,
    int PublishYear,
    string Author
);
