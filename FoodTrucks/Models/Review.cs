using System;
using System.ComponentModel.DataAnnotations;

namespace FoodTrucks.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required(ErrorMessage = "is required.")]
        [Display(Name = "Review")]
        public string Body { get; set; }

        [Required(ErrorMessage = "is required.")]
        // without making the prop nullable (with a question mark) the required error message will not be displayed
        [Range(1, 5, ErrorMessage = "rating must be {1}-{2}")]
        public int? Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Foreign Keys
        public int UserId { get; set; }
        public int TruckId { get; set; }

        // Navigation Properties (not added to DB, MUST use .Include to access)
        public User Author { get; set; }
        public Truck Truck { get; set; }
    }
}