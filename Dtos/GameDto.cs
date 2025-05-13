using System.ComponentModel.DataAnnotations;
namespace MyWebApp.Api.Dtos;

public record class GameDto(
    [Required]int Id,
    [Required][StringLength(40)] string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
