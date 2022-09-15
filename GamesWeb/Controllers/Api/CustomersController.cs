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
    [Authorize(Roles = RoleName.CanManageCustomers)]
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET api/customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Users
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<IdentityModels, IdentityModelsDto>));
        }
        //GET api/customers/1
        public IHttpActionResult GetCustomer(string id)
        {
            var customer = _context.Users.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();
            
            return Ok(Mapper.Map<IdentityModels, IdentityModelsDto>(customer));
        }
        //POST /api/customers
        //public Customer PostCustomer(Customer customer) - [HttpPost] not needed
        [HttpPost]
        public IHttpActionResult CreateCustomer(IdentityModelsDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<IdentityModelsDto, IdentityModels>(customerDto);
            _context.Users.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(string id, IdentityModelsDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Users.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            Mapper.Map<IdentityModelsDto, IdentityModels>(customerDto, customerInDb);

            _context.SaveChanges();
            return Ok();
        }
        //DELETE /api/customers/1

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(string id)
        {
            var customerInDb = _context.Users.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Users.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
