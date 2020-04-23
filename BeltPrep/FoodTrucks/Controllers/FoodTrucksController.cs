using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodTrucks.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

            List<FoodTruck> allTrucks = db.FoodTrucks.ToList();

            return View("Dashboard", allTrucks);
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

        [HttpGet("/trucks/{foodTruckId}/edit")]
        // any parameters in the url need to be parameters for the method (action)
        public IActionResult Edit(int foodTruckId)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            FoodTruck selectedTruck = db.FoodTrucks.FirstOrDefault(truck => truck.FoodTruckId == foodTruckId);


            // selected truck not found due to manually entering bad id into URL
            // OR the Uesr is not The Creator
            if (selectedTruck == null || selectedTruck.UserId != uid)
            {
                return RedirectToAction("Dashboard");
            }

            return View("Edit", selectedTruck);
        }

        [HttpPost("/Update/{foodTruckId}")]
        public IActionResult Update(FoodTruck editedTruck, int foodTruckId)
        {

            if (ModelState.IsValid == false)
            {
                return View("Edit", editedTruck); // display error messages
            }

            FoodTruck dbTruck = db.FoodTrucks.FirstOrDefault(truck => truck.FoodTruckId == editedTruck.FoodTruckId);

            // if the name is being changed
            if (editedTruck.Name != dbTruck.Name)
            {
                bool isNameTaken = db.FoodTrucks.Any(truck => truck.Name == editedTruck.Name);

                if (isNameTaken)
                {
                    ModelState.AddModelError("Name", "is taken");
                    return View("Edit", editedTruck); // display error messages
                }
            }

            // none of the above returns happened, safe to update

            dbTruck.UpdatedAt = DateTime.Now;
            dbTruck.Name = editedTruck.Name;
            dbTruck.Style = editedTruck.Style;
            dbTruck.Description = editedTruck.Description;

            db.Update(dbTruck);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("/trucks/{foodTruckId}")]
        public IActionResult Details(int foodTruckId)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            FoodTruck selectedTruck = db.FoodTrucks
                .Include(truck => truck.Reviews)
                .FirstOrDefault(truck => truck.FoodTruckId == foodTruckId);

            ViewBag.FoodTruckId = foodTruckId;
            return View("Details", selectedTruck);
        }

        // better practice to make delete a POST request, but can't have a form nested in a form so kept it as a GET to make
        // the formatting to match the mockup easier
        [HttpGet("/trucks/{foodTruckId}/delete")]
        public IActionResult Delete(int foodTruckId)
        {
            FoodTruck dbTruck = db.FoodTrucks.FirstOrDefault(truck => truck.FoodTruckId == foodTruckId);
            db.FoodTrucks.Remove(dbTruck);
            db.SaveChanges();

            // succinct version
            // db.FoodTrucks.Remove(db.FoodTrucks.FirstOrDefault(truck => truck.FoodTruckId == foodTruckId));
            return RedirectToAction("Dashboard");
        }

        // not using int foodTruckId parameter, it is included for showing the alternative method of getting the 
        // foodTruckId using ViewBag
        [HttpPost("/trucks/{foodTruckId}/review")]
        public IActionResult ReviewTruck(Review newReview, int foodTruckId)
        {
            newReview.UserId = (int)uid;
            db.Reviews.Add(newReview);
            db.SaveChanges();
            return RedirectToAction("Details", new { foodTruckId = newReview.FoodTruckId });
        }
    }
}