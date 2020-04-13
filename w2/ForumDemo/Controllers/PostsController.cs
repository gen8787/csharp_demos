using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForumDemo.Models;
using DbConnection;

public class PostsController : Controller
{
    [HttpGet("/Posts/All")]
    public IActionResult All()
    {

        List<Dictionary<string, object>> allPosts = DbConnector.Query("SELECT * FROM Post");

        return View(allPosts);
    }

    [HttpGet("/Posts/New")]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost("/Posts/Create")]
    public IActionResult Create(Post newPost)
    {
        if (ModelState.IsValid)
        {
            string insertSqlCommand = $@"
                INSERT INTO post (Username, Topic, Body)
                VALUES ('{newPost.Username}', '{newPost.Topic}', '{newPost.Body}')
            ";

            DbConnector.Execute(insertSqlCommand);

            return RedirectToAction("All");
        }
        else
        {
            // so error messages will be displayed
            return View("New");
        }
    }

    [HttpGet("/Posts/{id}")]
    public IActionResult Details(int id)
    {
        List<Dictionary<string, object>> results = DbConnector.Query($"SELECT * FROM post WHERE PostId={id}");

        if (results.Count > 0)
        {
            return View(results[0]);
        }
        else
        {
            return RedirectToAction("All");
        }
    }
}