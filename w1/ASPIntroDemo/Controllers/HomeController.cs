using System;
using System.Collections.Generic;
using ASPIntroDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPIntroDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            ViewBag.Introduction = "My name is Falconhoof and I will be your guide on your quest.";
            // looks for  Views/Home/Index because this action / method is called Index and we are in the HomeController
            return View();
            // return View("Index");
        }

        [HttpPost("/guide")]
        public ViewResult Guide(User newUser)
        {
            Guide guideModel = new Guide(newUser);
            // to let Destination method access this info since we have no DB or session set up
            // TempData["FirstName"] = newUser.FirstName;
            // TempData["LastName"] = newUser.LastName;
            return View(guideModel);
        }

        [HttpGet("/travel/{DestinationName}")]
        public ViewResult Destination(string destinationName)
        {
            // right now we don't have access to the user from the form because we are in a different method
            // and don't have a database or session set up
            Guide guide = new Guide(new User());
            Destination selectedDestionation = guide.GetDestination(destinationName);
            return View("Destination", selectedDestionation);
        }

        [HttpGet("{Path}")]
        public RedirectToActionResult Unknown(string path)
        {
            Console.WriteLine(path);
            return RedirectToAction("Index");
        }
    }
}