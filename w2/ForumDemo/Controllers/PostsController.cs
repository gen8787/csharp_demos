using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForumDemo.Models;

public class PostsController : Controller
{
    private ForumContext db;

    // controller constructor overload
    public PostsController(ForumContext context)
    {
        db = context;
    }


    [HttpGet("/Posts")]
    public IActionResult All()
    {
        // get all posts and all columns
        List<Post> allPosts = db.Posts.ToList();

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
        if (ModelState.IsValid == false)
        {
            // to display validation error messages
            return View("New");
        }

        // ModelState IS valid
        db.Posts.Add(newPost);
        // after save changes, our newPost object gets it's id from the database
        db.SaveChanges();
        return RedirectToAction("Details", new { id = newPost.PostId });
    }

    [HttpGet("/Posts/{postId}")]
    public IActionResult Details(int postId)
    {
        Post selectedPost = db.Posts.FirstOrDefault(post => post.PostId == postId);

        // in caes user manually types an invalid ID into the URL
        if (selectedPost == null)
        {
            return RedirectToAction("All");
        }

        return View(selectedPost);
    }

    [HttpGet("/Posts/{postId}/Edit")]
    public IActionResult Edit(int postId)
    {
        Post postToEdit = db.Posts.FirstOrDefault(post => post.PostId == postId);

        if (postToEdit == null)
        {
            return RedirectToAction("All");
        }

        return View(postToEdit);
    }

    [HttpPost("/Posts/Update")]
    public IActionResult Update(Post editedPost, int postId)
    {
        if (ModelState.IsValid == false)
        {
            // so error messages will be displayed and original input box values prefilled
            return View("Edit", editedPost);
        }
        Post dbPost = db.Posts.FirstOrDefault(post => post.PostId == postId);
        if (dbPost == null)
        {
            return RedirectToAction("All");
        }

        dbPost.Topic = editedPost.Topic;
        dbPost.Body = editedPost.Body;
        dbPost.UpdatedAt = DateTime.Now;

        db.Posts.Update(dbPost);
        db.SaveChanges();

        return RedirectToAction("Details", new { id = dbPost.PostId });
    }

    [HttpGet("/Posts/{postId}/Delete")]
    public IActionResult Delete(int postId)
    {
        Post postToDelete = db.Posts.FirstOrDefault(post => post.PostId == postId);
        db.Posts.Remove(postToDelete);

        // succinct version
        // db.Posts.Remove(db.Posts.FirstOrDefault(p => p.PostId == postId));

        db.SaveChanges();

        return RedirectToAction("All");
    }
}