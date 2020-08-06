using System;
using Microsoft.AspNetCore.Mvc;

namespace TravelGuide.Controllers
{
    public class HomeController : Controller
    {
        // methods in controllers are called Actions

        [HttpGet("")] // attr
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpGet("/test")]
        public ViewResult Test()
        {
            return View("Test");
        }

        [HttpGet("/travel/{destination}")]
        public RedirectToActionResult Travel(string destination)
        {
            return RedirectToAction("Index");
        }

    }
}