using System;
using Microsoft.AspNetCore.Mvc;

namespace TravelGuide.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet] // attribute
        [Route("")] // attribute: the url which when visited will trigger the method immediately below it
        public ViewResult Index()
        {
            return View("Index");

            // if the method name is the same as the .cshtml file, no argument needs to be passed to View
            // return View();
        }

        [HttpGet("/test")]
        public ViewResult Test()
        {
            return View("Test");
        }

        //                {routeParamName}
        [HttpGet("/travel/{destination}")]
        public RedirectToActionResult Unknown(string destination)
        {
            Console.WriteLine($"\n destination: {destination} \n");

            // redirect to Index method, methods in controllers are aka "Action"
            return RedirectToAction("Index");
        }

    }
}