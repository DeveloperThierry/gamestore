using app.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
List<GameDto> games = [ 
    new(1, "Street Fighter II", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
    new(2, "Mortal Kombat II", "Fighting", 24.99M, new DateOnly(1993, 6, 25)),
    new(3, "Super Mario World", "Platformer", 49.99M, new DateOnly(1990, 11, 21))
];
const string GetGameEndpointName = "GetGame";
// GET /
app.MapGet("/", () => "Connected to Gamestore API");
// GET /games
app.MapGet("/games", () => games);
// GET /games/{id}
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameEndpointName);
// POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
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
app.Run();
