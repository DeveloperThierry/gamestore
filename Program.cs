using app.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
List<GameDto> games = [ 
    new(1, "Street Fighter II", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
    new(2, "Mortal Kombat II", "Fighting", 24.99M, new DateOnly(1993, 6, 25)),
    new(3, "Super Mario World", "Platformer", 49.99M, new DateOnly(1990, 11, 21))
];

// GET /games
app.MapGet("/", () => "Connected to Gamestore API");
app.MapGet("/games", () => games);

app.Run();
