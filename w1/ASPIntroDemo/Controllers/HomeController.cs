using System;
using System.Collections.Generic;
using ASPIntroDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPIntroDemo.Controllers
{
    public class HomeController : Controller
    {
        // prop of HomeController (a  member of HomeController)
        public HomePage DefaultHomePageModel { get; set; } = new HomePage(new User("Lousy", "Tourist"));

        [HttpGet("")]
        public ViewResult Index()
        {
            ViewBag.Message = "message from ViewBag";

            // looks for  Views/Home/Index because this action is called Index and we are in the HomeController
            return View(DefaultHomePageModel);
            // return View("Index");
        }

        [HttpGet("/travel/{DestinationName}")]
        public ViewResult Destination(string destinationName)
        {

            Destination chosenDestination = null;

            foreach (Destination dest in DefaultHomePageModel.TravelDestinations)
            {
                if (destinationName == dest.Name)
                {
                    chosenDestination = dest;
                }
            }

            // Redirect to Index method / 'action'
            return View("Destination", chosenDestination);
        }

        [HttpGet("/register")]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost("/register/process")]
        public ViewResult Register(User newUser)
        {
            return View("GuestUser", newUser);
        }


        [HttpGet("{Path}")]
        public RedirectToActionResult Unknown(string path)
        {
            Console.WriteLine(path);
            return RedirectToAction("Index");
        }
    }
}