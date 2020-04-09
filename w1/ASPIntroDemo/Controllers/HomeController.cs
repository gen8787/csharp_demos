using System;
using Microsoft.AspNetCore.Mvc;

namespace ASPIntroDemo.Controllers
{
    public class HomeController : Controller
    {
        // method attributes
        // [HttpGet]
        // attribute for url
        // [Route("")]
        // Request type & url combined attribute
        [HttpGet("")]
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpGet("travel/{Destination}")]
        public RedirectToActionResult Unknown(string destination)
        {
            Console.WriteLine("****************************************************");
            Console.WriteLine("destination");

            // Redirect to Index method / 'action'
            return RedirectToAction("Index");
        }
    }
}