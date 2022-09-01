using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesWeb.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
    }
}