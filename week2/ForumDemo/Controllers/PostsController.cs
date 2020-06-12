using System;
using System.Collections.Generic;
using System.Linq;
using ForumDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumDemo.Controllers
{
    public class PostsController : Controller
    {
        // private field of controller class
        private ForumContext db;
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }

        private bool isLoggedIn
        {
            get
            {
                return uid != null;
            }
        }

        public PostsController(ForumContext context)
        {
            db = context;
        }

        [HttpGet("/posts")]
        public IActionResult All()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Post> allPosts = db.Posts
                .Include(post => post.Author)
                .ToList();
            return View("All", allPosts);
        }

        // handles GET request to DISPLAY the form for creating a new Post
        [HttpGet("/posts/new")]
        public IActionResult New()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

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
            newPost.UserId = (int)uid;
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
            Post selectedPost = db.Posts
                .Include(post => post.Author)
                .FirstOrDefault(post => post.PostId == id);

            if (selectedPost == null)
            {
                return RedirectToAction("All");
            }

            return View("Details", selectedPost);
        }

        [HttpGet("/posts/{id}/edit")]
        public IActionResult Edit(int id)
        {

            if (!isLoggedIn)
            {
                RedirectToAction("Index", "Home");
            }

            Post selectedPost = db.Posts.FirstOrDefault(post => post.PostId == id);

            // in case manually typing url into address bar, bypassing hidden edit button
            if (selectedPost == null || selectedPost.UserId != uid)
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
                // this id assignment could be done automatically if we named the parameter postId to match the primary key name
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
            selectedPost.ImgUrl = editedPost.ImgUrl;
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