using Microsoft.EntityFrameworkCore;
using RestaurantRater.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Data
{
    // 8: Create the Application DB Context and set up a Restaurants table
    // Next we need to set up our service...
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // Ctrl . to bring in using statement (RestaurantRater.Data.Entities)
        public DbSet<RestaurantEntity> Restaurants { get; set; }
        // Add this in after we've set up models and services for restaurants
        public DbSet<RatingEntity> Ratings { get; set; }
    }
}
