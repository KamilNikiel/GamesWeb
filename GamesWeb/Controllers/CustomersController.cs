using GamesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesWeb.ViewModels;


namespace GamesWeb.Controllers
{
    public class CustomersController : Controller
    {
        public ViewResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                    return HttpNotFound();
            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, FirstName = "Kamil", LastName = "Nikiel"},
                new Customer { Id = 2, FirstName = "Joanna", LastName = "Zoła"},
                new Customer { Id = 3, FirstName = "Zdzisek" }
            };
        }
        

    }
}