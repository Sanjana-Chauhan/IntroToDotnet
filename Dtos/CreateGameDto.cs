using System.ComponentModel.DataAnnotations;
namespace MyWebApp.Dtos;

public record class CreateGameDto(
     [Required][StringLength(40)]string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
