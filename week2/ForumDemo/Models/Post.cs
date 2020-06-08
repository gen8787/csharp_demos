using System;
using System.ComponentModel.DataAnnotations;

namespace ForumDemo.Models
{
    public class Post
    {
        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
        [MaxLength(45, ErrorMessage = "Must be less than 45 characters.")]
        public string Topic { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}