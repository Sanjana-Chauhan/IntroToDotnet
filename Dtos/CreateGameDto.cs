using System.ComponentModel.DataAnnotations;
namespace MyWebApp.Dtos;

public record class CreateGameDto(
     [Required][StringLength(40)]string Name,
    int GenreId,
    decimal Price,
    DateOnly ReleaseDate
);
