using System;
using System.Collections.Generic;
using System.Linq;
using ForumDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumDemo.Controllers
{
    public class PostsController : Controller
    {
        // private field of controller class
        private ForumContext db;
        public PostsController(ForumContext context)
        {
            db = context;
        }

        [HttpGet("/posts")]
        public IActionResult All()
        {
            List<Post> allPosts = db.Posts.ToList();
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
                // send back to the page with the form so error messages are displayed
                return View("New");
            }

            // ModelState IS valid
            db.Posts.Add(newPost);
            // db doesn't update until we run save changes
            // after SaveChanges, our newPost object now has PostId from db
            db.SaveChanges();

            // when redirect to an action that has params, pass the params using a new dictionary where the keys match the param names
            return RedirectToAction("Details", new { id = newPost.PostId });

        }

        // url param and method param names match
        // and match the html tag helper asp-route-id=
        // asp-route-paramName
        // the value for id in this url came from the href of the anchor tag, the href was built from the tag helpers
        [HttpGet("/posts/{id}")]
        public IActionResult Details(int id)
        {
            Post selectedPost = db.Posts.FirstOrDefault(post => post.PostId == id);

            if (selectedPost == null)
            {
                return RedirectToAction("All");
            }

            return View("Details", selectedPost);
        }

        [HttpGet("/posts/{id}/edit")]
        public IActionResult Edit(int id)
        {
            Post selectedPost = db.Posts.FirstOrDefault(post => post.PostId == id);

            if (selectedPost == null)
            {
                return RedirectToAction("All");
            }

            return View("Edit", selectedPost);
        }

        [HttpPost("/posts/{id}/update")]
        public IActionResult Update(Post editedPost, int id)
        {

            if (ModelState.IsValid == false)
            {
                // send back to the page with the form so error messages are displayed
                editedPost.PostId = id;
                return View("Edit", editedPost);
            }

            Post selectedPost = db.Posts.FirstOrDefault(post => post.PostId == id);

            if (selectedPost == null)
            {
                return RedirectToAction("All");
            }

            selectedPost.Topic = editedPost.Topic;
            selectedPost.Body = editedPost.Body;
            selectedPost.UpdatedAt = DateTime.Now;

            db.Posts.Update(selectedPost);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = selectedPost.PostId });
        }

        // better practice to use a post request for delete to avoid typing into url to cause a delete
        // also, google pre-fetches anchor tag urls to load faster, which could cause something to be deleted unintentionally
        [HttpGet("/posts/{id}/delete")]
        public IActionResult Delete(int id)
        {
            Post selectedPost = db.Posts.FirstOrDefault(post => post.PostId == id);

            if (selectedPost != null)
            {
                db.Posts.Remove(selectedPost);
                db.SaveChanges();
            }

            return RedirectToAction("All");
        }
    }
}