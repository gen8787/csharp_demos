using System.Collections.Generic;
using System.Linq;
using ForumDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumDemo.Controllers
{
    public class PostsController : Controller
    {
        private ForumContext db;
        public PostsController(ForumContext context)
        {
            db = context;
        }

        [HttpGet("/posts")]
        public IActionResult All()
        {
            // no .Where because we want all of them
            List<Post> allPosts = db.Posts.ToList();
            return View("All", allPosts);
        }

        [HttpGet("/posts/new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("/posts/create")]
        /* 
          <form 
            asp-controller="Posts"
            asp-action="Create" method="POST">
         */
        public IActionResult Create(Post newPost)
        {
            if (ModelState.IsValid == false)
            {
                // send back to the page with the form so error messages are displayed
                return View("New");
            }

            // ModelState IS valid
            db.Posts.Add(newPost);
            // db does NOT update until you run this, after SaveChanges, the newPost now has it's ID from the DB
            db.SaveChanges();
            return RedirectToAction("All");
        }
    }
}