using Microsoft.EntityFrameworkCore;
using MyWebApp.Api.Data;
using MyWebApp.Api.Dtos;
using MyWebApp.Api.Entities;
using MyWebApp.Api.Mapping;
using MyWebApp.Dtos;

namespace MyWebApp.Api.Endpoints;
public static class GamesEndpoints
{
    //Not needed as data is stored in sqlite db
    // private static readonly List<GameDto> games = [new(1, "fighter", "action", 19.43M, new DateOnly(2000, 11, 11)), new(2, "shooter", "action", 11.9M, new DateOnly(1999, 1, 1)), new(3, "racing", "roleplaying", 80.43M, new DateOnly(2010, 9, 1))];


    public static RouteGroupBuilder mapGamesEndpoints(this WebApplication app)
    {
        //With Parameter Validation is a service of nuget minimalapis extension that allows to perform validaation of parameters
        var group = app.MapGroup("games").WithParameterValidation();

        //Get all Games
        group.MapGet("/", async(GamestoreContext dbContext) =>
        {
            var games =await dbContext.Games
                        .Include(g => g.Genre)  // This will load the related Genre
                        .ToListAsync();

            return Results.Ok(games);
        });



        //Get Game By Id
        group.MapGet("/{id}", (int id, GamestoreContext dbContext) =>
        {
            Game? gameById = dbContext.Games.Find(id); //Getting rsults from the db
            if (gameById == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(gameById.ToGameDetailsDto());
        }).WithName("GetGameById");




        group.MapGet("/test", () =>
        {
            return "Hello World";
        });



        // Create Game 
        group.MapPost("/", (CreateGameDto newGame, GamestoreContext dbContext) =>
        {
            //Create an entity of Game from CreateGameDto and add it to the database
            var game = newGame.ToEntity();
            game.Genre = dbContext.Genres.Find(newGame.GenreId);

            dbContext.Games.Add(game); //Add the entity to the table
            dbContext.SaveChanges();  //Modify the db

            GameDto gameDto = game.ToDto(); //It is an extension of Game Entity Type
            return Results.Created($"/games/{game.Id}", gameDto);
        });

        return group;
    }
}