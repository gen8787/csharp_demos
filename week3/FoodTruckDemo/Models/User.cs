using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTruckDemo.Models
{
    public class User
    {
        [Key] // the below prop is the primary key, [Key] is not needed if named with pattern: ModelNameId
        public int UserId { get; set; }

        [Required(ErrorMessage = "is required")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "is required")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "is required")]
        [MinLength(8, ErrorMessage = "must be at least 8 characters")]
        [DataType(DataType.Password)] // <input type="password">
        public string Password { get; set; }

        [NotMapped]
        [MinLength(8, ErrorMessage = "must be at least 8 characters")]
        [DataType(DataType.Password)] // <input type="password">
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "doesn't match password")]
        public string PasswordConfirm { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation Props - MUST USE .include to access:
        // 1 user : many trucks. Truck can only be created by 1 user
        public List<FoodTruck> UploadedTrucks { get; set; }

        // 1 User : Many Reviews
        public List<Review> Reviews { get; set; }

        // Many User : Many Truck - to get the trucks that this user is a fan of
        public List<TruckFan> TruckFans { get; set; }

        // methods
        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}