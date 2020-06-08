using System.Collections.Generic;
using DbConnection;
using ForumDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumDemo.Controllers
{
    public class PostsController : Controller
    {
        [HttpGet("/posts")]
        public IActionResult All()
        {
            List<Dictionary<string, object>> allPosts = DbConnector.Query("SELECT * FROM posts");
            return View("All", allPosts);
        }

        // handles GET request to DISPLAY the form for creating a new Post
        [HttpGet("/posts/new")]
        public IActionResult New()
        {
            return View("New");
        }

        // handles POST request form submission to CREATE a new Post model instance
        [HttpPost("/posts/create")]
        public IActionResult Create(Post newPost)
        {
            if (ModelState.IsValid == false)
            {
                // send back to the page with the form so error messages are dispalyed
                return View("New");
            }


            string insertSqlStatement = $@"
                INSERT INTO posts (Username, Topic, Body)
                VALUES ('{newPost.Username}', '{newPost.Topic}', '{newPost.Body}');
            ";

            DbConnector.Execute(insertSqlStatement);
            return RedirectToAction("All");

        }

        // url param and method param names match
        // and match the html tag helper asp-route-id=
        // asp-route-paramName
        [HttpGet("/posts/{id}")]
        public IActionResult Details(int id)
        {
            List<Dictionary<string, object>> results = DbConnector.Query($"SELECT * FROM posts WHERE PostId={id}");

            if (results.Count > 0)
            {
                return View(results[0]);
            }

            // list is empty, not found
            return RedirectToAction("All");
        }
    }
}