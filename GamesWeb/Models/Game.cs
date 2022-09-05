using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GamesWeb.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]

        [Required]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        public DateTime DateAdded { get; set; }
        public DateTime? LastModified { get; set; }

    }
}