using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodTrucks.Models
{
    public class FoodTruck
    {
        [Key]
        public int FoodTruckId { get; set; }
        [Required(ErrorMessage = "is required")]
        [MinLength(5, ErrorMessage = "must be at least {1} characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "is required")]
        [MinLength(3, ErrorMessage = "must be at least {1} characters")]
        public string Style { get; set; }
        [Required(ErrorMessage = "is required")]
        [MinLength(10, ErrorMessage = "must be at least {1} characters")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        // Navigation Property
        public User SubmittedBy { get; set; }
        public List<Review> Reviews { get; set; }
    }
}