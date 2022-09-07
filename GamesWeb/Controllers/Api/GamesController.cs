using AutoMapper;
using GamesWeb.Dtos;
using GamesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GamesWeb.Controllers.Api
{
    public class GamesController : ApiController
    {
        private ApplicationDbContext _context;
        public GamesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET api/customers
        public IHttpActionResult GetGames()
        {
            return Ok(_context.Games.ToList().Select(Mapper.Map<Game, GameDto>));
        }
        //GET api/customers/1
        public IHttpActionResult GetGame(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);

            if (game == null)
                return NotFound();
            
            return Ok(Mapper.Map<Game, GameDto>(game));
        }
        //POST /api/customers
        //public Customer PostCustomer(Customer customer) - [HttpPost] not needed
        [HttpPost]
        public IHttpActionResult CreateGame(GameDto gameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            gameDto.DateAdded = DateTime.Now;
                
            var game = Mapper.Map<GameDto, Game>(gameDto);
            _context.Games.Add(game);
            _context.SaveChanges();

            gameDto.Id = game.Id;

            return Created(new Uri(Request.RequestUri + "/" + game.Id), gameDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateGame(int id, GameDto gameDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var gameInDb = _context.Games.SingleOrDefault(c => c.Id == id);

            if (gameInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            gameDto.LastModified = DateTime.Now;

            Mapper.Map<GameDto, Game>(gameDto, gameInDb);

            _context.SaveChanges();

            return Ok();
        }
        //DELETE /api/customers/1

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var gameInDb = _context.Games.SingleOrDefault(c => c.Id == id);

            if (gameInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Games.Remove(gameInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
