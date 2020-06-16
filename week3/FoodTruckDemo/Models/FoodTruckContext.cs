using Microsoft.EntityFrameworkCore;

namespace FoodTruckDemo.Models
{
    public class FoodTruckContext : DbContext
    {
        public FoodTruckContext(DbContextOptions options) : base(options) { }

        // for every model / entity that is going to be part of the db
        // the names of these properties will be the names of the tables in the db
        public DbSet<User> Users { get; set; }
        public DbSet<FoodTruck> FoodTrucks { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}