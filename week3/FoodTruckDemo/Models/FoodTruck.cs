using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodTruckDemo.Models
{
    public class FoodTruck
    {
        [Key]
        public int FoodTruckId { get; set; }

        [MinLength(5, ErrorMessage = "must be at least 2 characters")]
        public string Name { get; set; }

        [MinLength(3, ErrorMessage = "must be at least 2 characters")]
        public string Style { get; set; }

        [MinLength(10, ErrorMessage = "must be at least 2 characters")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Foreign Keys:
        public int UserId { get; set; } // 1 User : Many Uploaded Trucks

        // Navigation Props:
        public User UploadedBy { get; set; } // 1 User : Many Uploaded Trucks
        public List<Review> Reviews { get; set; }
    }
}