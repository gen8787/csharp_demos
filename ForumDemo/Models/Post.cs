using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForumDemo.Models
{
    public class Post
    {
        [Key] // Primary Key
        public int PostId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
        [MaxLength(45, ErrorMessage = "Must be less than 45 characters.")]
        public string Topic { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
        public string Body { get; set; }

        public string ImgUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Foreign Keys:
        // FK, must be named same as the primary key it relates to
        public int UserId { get; set; } // 1 User : many Post

        // Navigation properties:
        public User Author { get; set; }

        // Many User : Many Post because 1 Post has Many Vote and each Vote has a User, so through the Vote you can access the Many related Users
        public List<Vote> Votes { get; set; }
    }
}