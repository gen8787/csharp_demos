using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodTruckDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTruckDemo.Controllers
{
    public class FoodTruckController : Controller
    {
        private FoodTruckContext db;
        public FoodTruckController(FoodTruckContext context)
        {
            db = context;
        }

        [HttpGet("/trucks")]
        public IActionResult All()
        {
            return View("All");
        }

    }
}
