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
    [Authorize(Roles = RoleName.CanManageCustomers)]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
            };
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(IdentityModels customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            var customerInDb = _context.Users.Single(c => c.Id == customer.Id);

            customerInDb.FirstName = customer.FirstName;
            customerInDb.LastName = customer.LastName;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.UserName = customer.UserName;
            customerInDb.PhoneNumber = customer.PhoneNumber;
            if (customer.NewEmail != null && customer.Email != customer.NewEmail)
                customerInDb.Email = customer.NewEmail;

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
        public ViewResult Index()
        {
            return View("");
        }

        public ActionResult Details(string id)
        {
            var customer = _context.Users.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult Edit(string id)
        {
            var customer = _context.Users.SingleOrDefault(c => c.Id == id);

            if (id == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
        public ViewResult NavBarAccessible()
        {
            if (User.IsInRole(RoleName.CanManageCustomers))
                return View("List");

            return View("ReadOnlyList");
        }
    }
}