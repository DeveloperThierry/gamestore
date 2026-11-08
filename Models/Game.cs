using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Game
    {
        public int Id {get; set;}
        public required string Name {get; set;}

        public Genre? Genre {get; set;}

        public int GenreId {get; set;}

        public decimal Price {get; set;}

        public DateOnly ReleaseDate {get; set;}

    }
}