using Microsoft.EntityFrameworkCore;

namespace FoodTrucks.Models
{
    public class FoodTrucksContext : DbContext
    {
        // constructor
        public FoodTrucksContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<FoodTruck> FoodTrucks { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}