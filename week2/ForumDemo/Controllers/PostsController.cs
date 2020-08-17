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

            // no .Where because we want all of them
            // .Include to auto fill the Post.Author property with corresponding User (does a SQL Join)
            /* 
                SELECT * FROM posts
                JOIN users ON posts.UserId = users.UserId
                JOIN votes ON posts.UserId = Votes.PostId
            */
            List<Post> allPosts = db.Posts
                .Include(post => post.Author)
                .Include(post => post.Votes)
                // .ThenInclude(vote => vote.Voter)
                .OrderByDescending(p => p.CreatedAt)
                .ToList();
            return View("All", allPosts);
        }

        [HttpGet("/posts/new")]
        public IActionResult New()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
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
            // Assign author's UserId to the created Post
            newPost.UserId = (int)uid;
            db.Posts.Add(newPost);
            // db does NOT update until you run this, after SaveChanges, the newPost now has it's ID from the DB
            db.SaveChanges();
            return RedirectToAction("All");
        }

        // {postId} is a URL parameter, it MUST match the asp-route-paramName attribute on the anchor/form tag
        // where paramName is whatever you named it in the html
        [HttpGet("/posts/{postId}")]
        public IActionResult Details(int postId)
        {

            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            Post selectedPost = db.Posts
                .Include(post => post.Author)
                .Include(post => post.Votes)
                .ThenInclude(vote => vote.Voter)
                .FirstOrDefault(post => post.PostId == postId);

            if (selectedPost == null)
            {
                return RedirectToAction("All");
            }

            return View("Details", selectedPost);
        }

        [HttpPost("/posts/{postId}/delete")]
        public IActionResult Delete(int postId)
        {
            Post selectedPost = db.Posts.FirstOrDefault(post => post.PostId == postId);

            if (selectedPost != null)
            {
                db.Posts.Remove(selectedPost);
                db.SaveChanges();
            }
            return RedirectToAction("All");
        }

        [HttpGet("/posts/{postId}/edit")]
        public IActionResult Edit(int postId)
        {
            Post selectedPost = db.Posts.FirstOrDefault(post => post.PostId == postId);

            if (selectedPost == null || selectedPost.UserId != uid)
            {
                return RedirectToAction("All");
            }
            return View("Edit", selectedPost);
        }

        [HttpPost("/posts/{postId}/update")]
        public IActionResult Update(Post editedPost, int postId)
        {
            if (ModelState.IsValid == false)
            {
                // the id assignment line is happening automatically because our id param name matches the primary key name
                // if not named the same need to do it manually or use a hidden input with the id in it b/c editedPost is a newly constructed object from the form data
                // editedPost.PostId = idParamName;

                // send back to the page with the form so error messages are displayed
                return View("Edit", editedPost);
            }

            // ModelState IS valid
            Post selectedPost = db.Posts.FirstOrDefault(post => post.PostId == postId);

            if (selectedPost == null)
            {
                return RedirectToAction("All");
            }

            // selectedPost is not null
            selectedPost.Topic = editedPost.Topic;
            selectedPost.Body = editedPost.Body;
            selectedPost.ImgUrl = editedPost.ImgUrl;
            selectedPost.UpdatedAt = DateTime.Now;

            db.Posts.Update(selectedPost);
            db.SaveChanges();

            // Details needs a paramter so we have to pass it in a dictionary
            // { paramName: paramValue, paramName2: paramValue2 }
            return RedirectToAction("Details", new { postId = postId });
        }

        /* 
            The All.cshtml page does not have a @model Vote but a newVote is still auto instantiated
            for us because the form has no input boxes, instead the newVote info is passed in as params
            whose names match the Vote classes property names, so they get auto-mapped for us.
        */
        [HttpPost("/posts/{postId}/{isUpvote}")]
        public IActionResult Vote(Vote newVote)
        {
            newVote.UserId = (int)uid;

            Vote existingVote = db.Votes.FirstOrDefault(vote => vote.PostId == newVote.PostId && vote.UserId == newVote.UserId);

            if (existingVote == null)
            {
                db.Votes.Add(newVote);
            }
            // there IS an existing vote
            else
            {

                // voting the same way means they are trying to remove their vote
                if (existingVote.IsUpvote == newVote.IsUpvote)
                {
                    db.Votes.Remove(existingVote);
                }
                // if they are changing their vote
                else
                {
                    existingVote.IsUpvote = newVote.IsUpvote;
                    existingVote.UpdatedAt = DateTime.Now;
                    db.Votes.Update(existingVote);
                }
            }

            db.SaveChanges();

            return RedirectToAction("All");
            // Details needs a paramter so we have to pass it in a dictionary
            // { paramName: paramValue, paramName2: paramValue2 }
            // return RedirectToAction("Details", new { postId = newVote.PostId });
        }

        // Without removing vote or changing vote functionality
        // [HttpPost("/posts/{postId}/{isUpvote}")]
        // public IActionResult Vote(Vote newVote)
        // {
        //     newVote.UserId = (int)uid;

        //     db.Votes.Add(newVote);
        //     db.SaveChanges();

        //     // Details needs a paramter so we have to pass it in a dictionary
        //     // { paramName: paramValue, paramName2: paramValue2 }
        //     return RedirectToAction("Details", new { postId = newVote.PostId });
        // }

        // alternatively
        // [HttpPost("/posts/{postId}/{isUpvote}")]
        // public IActionResult Vote(int postId, bool isUpvote)
        // {
        //     Vote newVote = new Vote()
        //     {
        //         PostId = postId,
        //         IsUpvote = isUpvote
        //     };

        //     newVote.UserId = (int)uid;

        //     db.Votes.Add(newVote);
        //     db.SaveChanges();

        //     // Details needs a paramter so we have to pass it in a dictionary
        //     // { paramName: paramValue, paramName2: paramValue2 }
        //     return RedirectToAction("Details", new { postId = newVote.PostId });
        // }
    }
}