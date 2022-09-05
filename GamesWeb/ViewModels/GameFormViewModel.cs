using GamesWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesWeb.ViewModels
{
    public class GameFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public Genre Genre { get; set; }

        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Game" : "New Game";
            }
        }
        public GameFormViewModel()
        {
            Id = 0;
        }
        public GameFormViewModel(Game game)
        {
            Id = game.Id;
            Name = game.Name;
            ReleaseDate = game.ReleaseDate;
            GenreId = game.GenreId;
        }
    }
}