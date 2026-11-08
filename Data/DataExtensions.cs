using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Data
{
    public static class DataExtensions
    {
        public static void MigrateDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
            DbContext.Database.Migrate();
        }

        public static void AddGameStoreDb(this WebApplicationBuilder builder)
        {
            var connString = "Data Source=GameStore.db";
            builder.Services.AddSqlite<GameStoreContext>(connString, 
                optionsAction: options => options.UseSeeding((context, _) =>
                {
                    if (!context.Set<Genre>().Any())
                    {
                        context.Set<Genre>().AddRange(
                            new Genre { Name = "Action" },
                            new Genre { Name = "Adventure" },
                            new Genre { Name = "RPG" },
                            new Genre { Name = "Strategy" },
                            new Genre { Name = "Simulation" },
                            new Genre { Name = "Sports" },
                            new Genre { Name = "Fighting" }
                        );
                        context.SaveChanges();

                    }
                })
            );
        }
    }
}