using MyWebApp.Api.Data;
using MyWebApp.Api.Dtos;
using MyWebApp.Api.Entities;
using MyWebApp.Dtos;

namespace MyWebApp.Api.Mapping;
public static class Gamemapping
{
    public static Game ToEntity(this CreateGameDto createGameDto)
    {
        return new Game()
        {
            Name = createGameDto.Name,
            GenreId = createGameDto.GenreId,
            Price = createGameDto.Price,
            ReleaseDate = createGameDto.ReleaseDate
        };
    }

    public static GameDto ToDto(this Game game)
    {
        return new(
            game.Id,
            game.Name,
            game.Genre!.Name,
            game.Price,
            game.ReleaseDate
        );
    }


 public static GameDetailsDto ToGameDetailsDto(this Game game)
    {
        return new(
            game.Id,
            game.Name,
            game.GenreId,
            game.Price,
            game.ReleaseDate
        );
    }

}
