using AutoMapper;
using GamesWeb.Dtos;
using GamesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace GamesWeb.Controllers.Api
{
    public class OrdersController : ApiController
    {
        private ApplicationDbContext _context;
        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateGame(OrderDto orderDto)
        {
            var customer = _context.Users.SingleOrDefault(
                 c => c.Id == orderDto.CustomerId);

            if (customer == null)
                return BadRequest("Invalid customer ID.");
             
            var games = _context.Games.Where(
                m => orderDto.GameIds.Contains(m.Id)).ToList();

            if (games.Count != orderDto.GameIds.Count)
                return BadRequest("One or more game IDs are invalid.");
            
            foreach (var game in games)
            {
                var order = new Order
                {
                    Customer = customer,
                    Game = game,
                    DateCreated = DateTime.Now
                };

                _context.Orders.Add(order);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}