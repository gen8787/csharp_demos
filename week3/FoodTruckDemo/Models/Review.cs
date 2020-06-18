using System;
using System.ComponentModel.DataAnnotations;

namespace FoodTruckDemo.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "Review")]
        public string Body { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Foreign Keys:
        public int UserId { get; set; }
        public int FoodTruckId { get; set; }

        // Navigation Props - MUST USE .include to access:
        // 1 User : Many Reviews, corresponds to the UserId
        public User Author { get; set; } // the User who created this Review
        public FoodTruck FoodTruck { get; set; } // the FoodTruck the Review is for
    }
}