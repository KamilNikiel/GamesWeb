using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesWeb.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public IdentityModels Customer { get; set; }
        public string CustomerId { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
    }
}