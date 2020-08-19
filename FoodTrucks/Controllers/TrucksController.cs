using System;
using System.Collections.Generic;
using System.Linq;
using FoodTrucks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            List<Truck> allTrucks = db.Trucks
                .Include(t => t.SubmittedBy)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();
            return View("All", allTrucks);
        }

        [HttpGet("/trucks/{truckId}")]
        public IActionResult Details(int truckId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            Truck truck = db.Trucks
                .Include(t => t.SubmittedBy)
                .Include(t => t.Reviews)
                .ThenInclude(review => review.Author)
                .FirstOrDefault(t => t.TruckId == truckId);

            if (truck == null)
            {
                return RedirectToAction("All");
            }
            return View("Details", truck);
        }

        [HttpGet("/trucks/{truckId}/delete")]
        public IActionResult Delete(int truckId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            Truck truck = db.Trucks.FirstOrDefault(t => t.TruckId == truckId);

            if (truck == null || truck.UserId != uid)
            {
                return RedirectToAction("All");
            }

            db.Trucks.Remove(truck);
            db.SaveChanges();
            return RedirectToAction("All");
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

        [HttpGet("/trucks/{truckId}/edit")]
        public IActionResult Edit(int truckId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            Truck truck = db.Trucks.FirstOrDefault(t => t.TruckId == truckId);

            if (truck == null)
            {
                return RedirectToAction("All");
            }

            return View("Edit", truck);
        }

        [HttpPost("/trucks/{truckId}/update")]
        public IActionResult Update(Truck editedTruck, int truckId)
        {
            if (ModelState.IsValid == false)
            {
                // return the view to display validation errors
                // editedTruck has the Truck id in it, so we have to pass it back in because of: asp-route-truckId="@Model.TruckId"
                // Technically we could remove that asp-route from the form and NOT pass in the editedTruck below and it will be handled automatically
                return View("Edit", editedTruck);
            }

            Truck dbTruck = db.Trucks.FirstOrDefault(t => t.TruckId == truckId);

            if (dbTruck == null)
            {
                return RedirectToAction("All");
            }

            dbTruck.Name = editedTruck.Name;
            dbTruck.Style = editedTruck.Style;
            dbTruck.Description = editedTruck.Description;
            dbTruck.ImgUrl = editedTruck.ImgUrl;
            dbTruck.UpdatedAt = DateTime.Now;

            db.Trucks.Update(dbTruck);
            db.SaveChanges();
            return RedirectToAction("All");
        }

        // the <form> does not have an asp-route-truckId but the {truckId} is in the URL
        // because the model passed to the <partial> where the <form> is already had the TruckId in it
        // You can add the asp-route-truckId if you want to be more explicit
        [HttpPost("/trucks/{truckId}/review")]
        public IActionResult Review(int truckId, Review newReview)
        {

            if (ModelState.IsValid == false)
            {
                Truck truck = db.Trucks
                    .Include(t => t.SubmittedBy)
                    .Include(t => t.Reviews)
                    .ThenInclude(review => review.Author)
                    .FirstOrDefault(t => t.TruckId == truckId);

                // to display error messages, need to pass in the model that the Details.cshtml needs
                return View("Details", truck);
            }
            newReview.UserId = (int)uid;
            db.Reviews.Add(newReview);
            db.SaveChanges();

            // because of Details parameter: Details(int truckId)
            // new { paramName = paramValue }, key value pairs for the required parameters
            return RedirectToAction("Details", new { truckId = newReview.TruckId });
        }
    }
}