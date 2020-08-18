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
                .ToList();
            return View("All", allTrucks);
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
    }
}