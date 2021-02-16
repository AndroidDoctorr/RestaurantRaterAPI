using RestaurantRater.Data;
using RestaurantRater.Data.Entities;
using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Services
{
    public class RestaurantService : IRestaurantService
    {
        // 12: Implement the interface (right click -> implement interface)
        // Then add the context field and the constructor

        private ApplicationDbContext _context;
        public RestaurantService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Fill out the service methods:
        public bool AddRestaurant(RestaurantCreate model)
        {
            RestaurantEntity newRestaurant = new RestaurantEntity()
            {
                Name = model.Name,
                Location = model.Location,
                Rating = model.Rating
            };

            _context.Restaurants.Add(newRestaurant);

            if (_context.SaveChangesAsync().Result == 1)
            {
                return true;
            }
            return false;
        }

        public RestaurantDetail GetRestaurantById(int id)
        {
            RestaurantEntity restaurant = _context.Restaurants.FindAsync(id).Result;

            // We can do some kind of default behavior here, or just return null

            if (restaurant == null) return null;

            //if (restaurant == null)
            //{
            //    return new RestaurantDetail()
            //    {
            //        Name = "404- Restaurant not found",
            //        Location = "--",
            //        Rating = 0.0,
            //    };
            //}

            return new RestaurantDetail()
            {
                Name = restaurant.Name,
                Location = restaurant.Location,
                Rating = restaurant.Rating,
            };
        }

        public List<RestaurantListItem> GetRestaurants()
        {
            return _context.Restaurants.Select(r => new RestaurantListItem() {
                Name = r.Name,
                Location = r.Location,
                Rating = r.Rating,
            }).ToList();
        }

        // Now we can bring this service into our Startup class...
    }
}
