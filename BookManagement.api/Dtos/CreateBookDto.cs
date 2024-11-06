using System.ComponentModel.DataAnnotations;

namespace BookManagement.api.Dtos;

public record class CreateBookDto(
    [Required][StringLength(5)] string Title,
    [Required] int PublishYear,
    [Required] string Author
);