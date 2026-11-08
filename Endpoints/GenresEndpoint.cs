using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using app.Dtos;
using Microsoft.EntityFrameworkCore;

namespace app.Endpoints
{
    public static class GenresEndpoint
    {
        public static void MapGenresEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/genres");

            group.MapGet("/", async (GameStoreContext dbContext) =>

            await dbContext.Genres.Select(genre => new GenreDto(
                genre.Id,
                genre.Name
            ))
            .AsNoTracking()
            .ToListAsync()
            );
        }
    }
}