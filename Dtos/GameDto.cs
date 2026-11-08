namespace app.Dtos;

public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly releaseDate
);