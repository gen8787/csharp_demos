using System.Collections.Generic;
using System.Linq;
using FoodTrucks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrucks.Controllers
{
    public class TrucksController : Controller
    {
        private FoodTrucksContext db;

        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }

        private bool isLoggedIn
        {
            get
            {
                return uid != null;
            }
        }

        public TrucksController(FoodTrucksContext context)
        {
            db = context;
        }

        [HttpGet("/trucks")]
        public IActionResult All()
        {

            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Truck> allTrucks = db.Trucks.ToList();
            return View("Trucks", allTrucks);
        }

        [HttpGet("/trucks/new")]
        public IActionResult New()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("New");
        }

        [HttpPost("/trucks/create")]
        public IActionResult Create(Truck newTruck)
        {
            if (ModelState.IsValid == false)
            {
                // return view instead of redirect so validation errors will be displayed
                return View("New");
            }

            // relate the truck to the user who submitted it
            newTruck.UserId = (int)uid;
            db.Trucks.Add(newTruck);
            db.SaveChanges();
            return RedirectToAction("All");
        }
    }
}