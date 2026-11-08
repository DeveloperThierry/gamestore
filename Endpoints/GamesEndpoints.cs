using app.Data;
using app.Dtos;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Endpoints
{
    public static class GamesEndpoints
    {

        const string GetGameEndpointName = "GetGame";
        private static readonly List<GameDto> games = [ 
    new(1, "Street Fighter II", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
    new(2, "Mortal Kombat II", "Fighting", 24.99M, new DateOnly(1993, 6, 25)),
    new(3, "Super Mario World", "Platformer", 49.99M, new DateOnly(1990, 11, 21))
];   

    public static void MapGamesEndpoints(this WebApplication app){
        var group = app.MapGroup("/games");
        
// GET /games
group.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Games.Include(game => game.Genre).Select(game => new GameSummaryDto(
    game.Id,
    game.Name,
    game.Genre.Name,
    game.Price,
    game.ReleaseDate
)).AsNoTracking().ToListAsync());
// GET /games/{id}
group.MapGet("/{id}", async (int id, GameStoreContext dbContext) => { 
    var game = await dbContext.Games.FindAsync(id); 
    return game is null ? Results.NotFound() : Results.Ok(
        new GameDetailsDto(
            game.Id,
            game.Name,
            game.GenreId,
            game.Price,
            game.ReleaseDate
            )
    ); 
})
.WithName(GetGameEndpointName);
// POST /games
group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
{
    Game game = new()
        {
        Name=newGame.Name,
        GenreId=newGame.GenreId,
        Price=newGame.Price,
        ReleaseDate=newGame.ReleaseDate
        };

    dbContext.Games.Add(game);
    await dbContext.SaveChangesAsync();

    GameDetailsDto gameDto = new(
        game.Id,
        game.Name,
        game.GenreId,
        game.Price,
        game.ReleaseDate
    );

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = gameDto.Id}, gameDto);
});

// UPDATE /games/{id}
group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var index = games.FindIndex(game => game.Id == id);
    if(index == -1) return Results.NotFound();
    games[index] = new GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
        );
    return Results.NoContent();
});

// DELETE /games/{id}
group.MapDelete("/{id}", (int id) => {
    games.RemoveAll(game => game.Id == id);
    return Results.NoContent();
});
    }
    }
}