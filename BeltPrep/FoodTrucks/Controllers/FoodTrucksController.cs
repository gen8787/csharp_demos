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
            return View();
        }
    }
}