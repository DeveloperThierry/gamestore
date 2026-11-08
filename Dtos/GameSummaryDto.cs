using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Dtos
{
    public record GameSummaryDto(
        int Id,
        string Name,
        string Genre,
        decimal Price,
        DateOnly releaseDate
    );
}