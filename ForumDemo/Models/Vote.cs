using System;
using System.ComponentModel.DataAnnotations;

namespace ForumDemo.Models
{
    // One Vote instance represents a single vote that a single user did for a single post
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }
        public bool IsUpvote { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Foreign Keys
        public int UserId { get; set; }
        public int PostId { get; set; }

        // Navigation Properties
        public User Voter { get; set; }
        public Post Post { get; set; }
    }
}