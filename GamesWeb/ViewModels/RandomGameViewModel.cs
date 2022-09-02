using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamesWeb.Models;

namespace GamesWeb.ViewModels
{
    public class RandomGameViewModel
    {
        public ICollection<Game> Games { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}