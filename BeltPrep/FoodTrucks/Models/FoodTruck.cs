using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        public double CalculateAverageRating()
        {
            // if this was an int the division will get rid of decimal places
            double ratingSum = Reviews.Sum(review => review.Rating);

            if (Reviews.Count == 0)
            {
                return 0;
            }

            // round to 1 decimal place
            return Math.Round(ratingSum / Reviews.Count, 1);
        }
    }
}