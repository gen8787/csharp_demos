using Microsoft.EntityFrameworkCore;

namespace FoodTrucks.Models
{
    public class FoodTrucksContext : DbContext
    {
        public FoodTrucksContext(DbContextOptions options) : base(options) { }

        // for every model / entity that is going to be part of the db
        // the names of these properties will be the names of the tables in the db
        public DbSet<User> Users { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }

}