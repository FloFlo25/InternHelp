using DatabaseAPIExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPIExercise.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { 

        }

        public DbSet<Product> Products{ get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
