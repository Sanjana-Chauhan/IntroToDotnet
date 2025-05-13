using MyWebApp.Api.Dtos;
using MyWebApp.Dtos;

namespace MyWebApp.Api.Endpoints;
public static class GamesEndpoints
{
    private static readonly List<GameDto> games = [new(1, "fighter", "action", 19.43M, new DateOnly(2000, 11, 11)), new(2, "shooter", "action", 11.9M, new DateOnly(1999, 1, 1)), new(3, "racing", "roleplaying", 80.43M, new DateOnly(2010, 9, 1))];


    public static RouteGroupBuilder mapGamesEndpoints(this WebApplication app)
    {
        //With Parameter Validation is a serveice of nuget minimalapis extension that allows to perform validaation of parameters
        var group =app.MapGroup("games").WithParameterValidation();
        group.MapGet("/", () =>
        {
            return Results.Ok(games);
        });

        group.MapGet("/{id}", (int id) =>
        {
            return Results.Ok(games[id - 1]);
        }).WithName("GetGameById");

        group.MapGet("/test", () =>
        {
            return "Hello World";
        });


        group.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto game = new(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);
            games.Add(game);
            return Results.CreatedAtRoute("GetGameById", new { id = game.Id }, game);
        });

        return group;
    }
}