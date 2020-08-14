using System;
using System.ComponentModel.DataAnnotations;

namespace ForumDemo.Models
{
    public class Vote
    {
        [Key] // primary key
        public int VoteId { get; set; }

        // Foreign Keys
        public int PostId { get; set; }
        public int UserId { get; set; }
        public bool IsUpvote { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        public User Voter { get; set; }
        public Post Post { get; set; }
    }
}