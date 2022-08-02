using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamesWeb.Models;

namespace GamesWeb.ViewModels
{
    public class RandomGameViewModel
    {
        public List<Game> Games { get; set; }
        public List<Customer> Customers { get; set; }
    }
}