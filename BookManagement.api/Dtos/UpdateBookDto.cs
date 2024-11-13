using System.ComponentModel.DataAnnotations;

namespace BookManagement.api.Dtos;

public record class UpdateBookDto(
    [Required] string Title,
    [Required] int PublishYear,
    [Required] string Author

);
