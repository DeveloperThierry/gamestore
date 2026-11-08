using app.Dtos;

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
        
// GET /
group.MapGet("/", () => "Connected to Gamestore API");
// GET /games
group.MapGet("", () => games);
// GET /games/{id}
group.MapGet("/{id}", (int id) => { 
    var game = games.Find(game => game.Id == id); 
    return game is null ? Results.NotFound() : Results.Ok(game); 
})
.WithName(GetGameEndpointName);
// POST /games
group.MapPost("/", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );

    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
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