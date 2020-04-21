using System;
using System.ComponentModel.DataAnnotations;

namespace FoodTrucks.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int Rating { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "must be at least {1} characters")]
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int FoodTruckId { get; set; }
        public int UserId { get; set; }
        public User Author { get; set; }
        public FoodTruck FoodTruck { get; set; }
    }
}