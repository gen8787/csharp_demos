using System;
using System.ComponentModel.DataAnnotations;

namespace FoodTruckDemo.Models
{
    // class to represent Many User : Many Truck so many users can become a fan of a user can be a fan of many trucks
    public class TruckFan
    {
        [Key]
        public int TruckFanId { get; set; }

        // Foreign Keys
        public int FoodTruckId { get; set; }
        public int UserId { get; set; }


        // Navigation Props - MUST USE .include to access:
        public User Fan { get; set; }
        public FoodTruck FoodTruck { get; set; }
    }
}