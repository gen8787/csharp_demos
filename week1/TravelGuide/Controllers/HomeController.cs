using System;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Models;

namespace TravelGuide.Controllers
{
    public class HomeController : Controller
    {
        // methods in controllers are called Actions

        [HttpGet("")] // attr
        public ViewResult Index()
        {
            ViewBag.Introduction = "My name is Falconhoof and I will be your travel guide on your quest.";
            ViewBag.YearCreated = 2020;
            ViewBag.ImgUrl = "https://ih1.redbubble.net/image.230236822.2041/raf,750x1000,075,t,101010:01c5ca27c6.u3.jpg";
            return View("Index");
        }

        [HttpPost("/guide")]
        public ViewResult Guide(Traveler newTraveler)
        {
            /* Method 1 for passing more than one type of data to the page
                pass the page a ViewModel
                also use a ViewBag
            */
            // using our static class to get some data since we don't have a DB
            ViewBag.TravelDestinations = TravelDestinations.Destinations;
            return View("Guide", newTraveler);
        }

        [HttpPost("/guide2")]
        public ViewResult Guide2(Traveler newTraveler)
        {
            Guide guide = new Guide()
            {
                Traveler = newTraveler,
                Destinations = TravelDestinations.Destinations
            };
            return View("Guide2", guide);
        }

        [HttpGet("/test")]
        public ViewResult Test()
        {
            return View("Test");
        }

        [HttpGet("/travel/{destinationName}")]
        public IActionResult Travel(string destinationName)
        {
            Destination dest = TravelDestinations.GetDestination(destinationName);

            if (dest == null)
            {
                return RedirectToAction("Index");
            }

            return View("Destination", dest);
        }

    }
}