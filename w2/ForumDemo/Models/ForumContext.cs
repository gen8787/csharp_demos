using Microsoft.EntityFrameworkCore;

namespace ForumDemo.Models
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions options) : base(options) { }
        // This DbSet corresponds to our posts table in our database which will let us query the table
        public DbSet<Post> Posts { get; set; }
    }
}