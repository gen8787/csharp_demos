using System;
using System.Collections.Generic;
using ASPIntroDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPIntroDemo.Controllers
{
    public class HomeController : Controller
    {
        // prop of HomeController (a  member of HomeController)
        public HomePage HomePageModel { get; set; } = new HomePage(new User("Lousy", "Tourist"));

        [HttpGet("")]
        public ViewResult Index()
        {
            ViewBag.Message = "message from ViewBag";

            // looks for  Views/Home/Index because this action is called Index and we are in the HomeController
            return View(HomePageModel);
            // return View("Index");
        }

        [HttpGet("/travel/{DestinationName}")]
        public ViewResult Destination(string destinationName)
        {

            Destination chosenDestination = null;

            foreach (Destination dest in HomePageModel.TravelDestinations)
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
        public RedirectToActionResult Register(User newUser)
        {
            Console.WriteLine(newUser.FirstName);

            /* 
                HomePageModel.Tourist = newUser; This data doesn't persist through redirects

                To Persist data, need: session, TempData, database

                The HomeController gets re-instantiated during the redirect
                So, the HomePageModel also gets re-instantiated because
                it is a member of the HomeController
            */
            HomePageModel.Tourist = newUser;

            return RedirectToAction("Index");
        }

        [HttpGet("{Path}")]
        public RedirectToActionResult Unknown(string path)
        {
            Console.WriteLine(path);
            return RedirectToAction("Index");
        }
    }
}