using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodTruckDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace FoodTruckDemo.Controllers
{
    public class FoodTruckController : Controller
    {
        private FoodTruckContext db;

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
        public FoodTruckController(FoodTruckContext context)
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

            List<FoodTruck> allTrucks = db.FoodTrucks.ToList();

            return View("All", allTrucks);
        }

        [HttpGet("/new")]
        public IActionResult New()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("New");
        }

        [HttpPost("/trucks/create")]
        public IActionResult Create(FoodTruck newTruck)
        {
            if (ModelState.IsValid == false)
            {
                return View("New"); // display error messages
            }

            // associate newTruck with the logged in user
            // this user id could also have been passed in as a URL param or a hidden input which would auto assign the id. URL param would have to be named userId for auto assign to work
            newTruck.UserId = (int)uid;
            db.FoodTrucks.Add(newTruck);
            db.SaveChanges();

            return RedirectToAction("All");
        }

        [HttpGet("/trucks/{foodTruckId}/edit")]
        public IActionResult Edit(int foodTruckId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            FoodTruck selectedTruck = db.FoodTrucks.FirstOrDefault(truck => truck.FoodTruckId == foodTruckId);

            // if truck is not null, check if logged in user is creator before letting them see edit page
            if (selectedTruck == null || selectedTruck.UserId != uid)
            {
                return RedirectToAction("All");
            }

            return View("Edit", selectedTruck);
        }

        // This url is the same as the details URL, but there is no conflict because one is a POST and the other is a GET so they can be differentiated
        [HttpPost("/trucks/{foodTruckId}")]
        public IActionResult Update(int foodTruckId, FoodTruck editedTruck)
        {
            if (ModelState.IsValid == false)
            {
                return View("Edit", editedTruck);
            }

            FoodTruck selectedTruck = db.FoodTrucks.FirstOrDefault(truck => truck.FoodTruckId == foodTruckId);

            if (selectedTruck == null)
            {
                return RedirectToAction("All");
            }

            selectedTruck.Name = editedTruck.Name;
            selectedTruck.Style = editedTruck.Style;
            selectedTruck.Description = editedTruck.Description;
            selectedTruck.UpdatedAt = DateTime.Now;

            db.FoodTrucks.Update(selectedTruck);
            db.SaveChanges();

            // new {} dictionary is full of paramName value pairs for Details action
            // every param that the action needs, must be a key in the dictionary
            return RedirectToAction("Details", new { foodTruckId = selectedTruck.FoodTruckId });
        }

        [HttpGet("/trucks/{foodTruckId}")]
        public IActionResult Details(int foodTruckId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            FoodTruck selectedTruck = db.FoodTrucks.FirstOrDefault(truck => truck.FoodTruckId == foodTruckId);

            if (selectedTruck == null)
            {
                return RedirectToAction("All");
            }

            return View("Details", selectedTruck);
        }

    }
}
