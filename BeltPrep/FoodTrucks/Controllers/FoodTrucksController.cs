using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodTrucks.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace FoodTrucks.Controllers
{
    public class FoodTrucksController : Controller
    {
        private FoodTrucksContext db;
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }
        public FoodTrucksController(FoodTrucksContext context)
        {
            db = context;
        }

        [HttpGet("/dashboard")]
        public IActionResult Dashboard()
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost("/Create")]
        public IActionResult Create(FoodTruck newTruck)
        {

            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                if (db.FoodTrucks.Any(truck => truck.Name == newTruck.Name))
                {
                    ModelState.AddModelError("Name", "is taken");
                }
                else
                {
                    newTruck.UserId = (int)uid;
                    db.Add(newTruck);
                    db.SaveChanges();
                    return RedirectToAction("Dashboard");
                }

            }
            // above return did not run, so not valid, re-render page to display error messages
            return View("New");
        }

        [HttpGet("/New")]
        public IActionResult New()
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}