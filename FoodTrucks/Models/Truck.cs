using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FoodTrucks.Models
{
    public class Truck
    {
        [Key] // primary key
        public int TruckId { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least {1} characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(3, ErrorMessage = "must be at least {1} characters.")]
        public string Style { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(10, ErrorMessage = "must be at least {1} characters.")]
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Foreign Keys
        public int UserId { get; set; }

        // Navigation Properties (not added to DB - must use .Include)
        public User SubmittedBy { get; set; }
        public List<Review> Reviews { get; set; }

        public double AverageRating()
        {
            double? avg = Reviews.Average(review => review.Rating);

            // if (avg == null)
            // {
            //     return 0;
            // }
            // else
            // {
            //     return Math.Round((double)avg, 1);
            // }

            // round to 1 decimal place
            return avg == null ? 0 : Math.Round((double)avg, 1);
        }
    }
}