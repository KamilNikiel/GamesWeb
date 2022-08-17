using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesWeb.Models;
using GamesWeb.ViewModels;

namespace GamesWeb.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games

        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }
        
        public ActionResult Index()
        {
            var games = _context.Games.ToList();
            return View(games);
        }

        [Route("games/released/{year:regex(\\d{4})}/{month:range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Random()
        {
            var games = new List<Game>()
            {
                new Game {Id = 1, Name = "The Witcher 3"},
                new Game {Id = 2, Name = "Gothic"},
                new Game {Id = 3, Name = "Gothic II"}
            };

            var viewModel = new RandomGameViewModel
            {
                Games = games
            };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);

            if (game == null)
                return HttpNotFound();
            return View(game);
        }

    }
}