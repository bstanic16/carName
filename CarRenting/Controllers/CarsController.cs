using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRenting.Models;
using CarRenting.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
//using CarRenting.Migrations;



namespace CarRenting.Controllers
{
    public class CarsController : Controller
    {
        private ApplicationDbContext _context;
        public CarsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Cars
        public ActionResult Random()
        {
            var car = new Car() { Name = "Bugati" };
            var customers = new List<Customer>
            {
                new Customer{Name = "Customer1"},
                new Customer{Name = "Customer2"}


            };

            var viewModel = new RandomCarViewModel
            {
                Car = car,
                Customers = customers
            };
            return View(viewModel);

        }


        [Route("cars/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageCars))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }
        }
        public ActionResult Details(int id)
        {
            var car = _context.Cars.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }
        [Authorize(Roles = RoleName.CanManageCars)]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new CarFormViewModel
            {
                Genres = genres
            };
            return View("CarForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CarFormViewModel(car)
            {
                Genres = _context.Genres.ToList()
            };
            return View("CarForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Car car)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CarFormViewModel(car)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("CarForm", viewModel);
            }


            if (car.Id == 0)
            {
                _context.Cars.Add(car);
            }
            else
            {
                var carInDb = _context.Cars.Single(m => m.Id == car.Id);
                carInDb.Name = car.Name;
                carInDb.GenreId = car.GenreId;
                carInDb.DateReleased = car.DateReleased;
                carInDb.Available = car.Available;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Cars");
        }
    }
}