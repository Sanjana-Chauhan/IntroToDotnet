using System.ComponentModel.DataAnnotations;
namespace MyWebApp.Api.Dtos;

public record class GameDetailsDto(
    [Required]int Id,
    [Required][StringLength(40)] string Name,
    int GenreId,
    decimal Price,
    DateOnly ReleaseDate
);
