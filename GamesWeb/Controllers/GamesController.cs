using GamesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesWeb.ViewModels;
using System.Data.Entity;

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
        
        public ViewResult Index()
        {
            var games = _context.Games.Include(g => g.Genre).ToList();

            if (User.IsInRole(RoleName.CanManageGames))
                return View("List");

            return View("ReadOnlyList");
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

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageGames)]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new GameFormViewModel
            {
                Genres = genre,
            };
            return View("GameForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageGames)]
        public ActionResult Save(Game game)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GameFormViewModel(game)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("GameForm", viewModel);
            }
            if (game.Id == 0)
            {
                game.DateAdded = DateTime.Now;
                
                _context.Games.Add(game);
            }
            else
            {
                game.LastModified = DateTime.Now;

                var gameInDb = _context.Games.Single(g => g.Id == game.Id);

                gameInDb.Name = game.Name;
                gameInDb.Genre = game.Genre;
                gameInDb.ReleaseDate = game.ReleaseDate;
                gameInDb.LastModified = game.LastModified;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Games");
        }

        public ActionResult Details(int id)
        {
            var game = _context.Games.Include(g => g.Genre).SingleOrDefault(g => g.Id == id);

            if (game == null)
                return HttpNotFound();

            return View(game);
        }
        [Authorize(Roles = RoleName.CanManageGames)]
        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);

            if (id == null)
                return HttpNotFound();

            var viewModel = new GameFormViewModel(game)
            {
                Genres = _context.Genres.ToList()
            };

            return View("GameForm", viewModel);
        }
    }
}