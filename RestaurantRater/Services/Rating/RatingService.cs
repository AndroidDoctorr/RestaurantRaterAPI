using RestaurantRater.Data;
using RestaurantRater.Models.Rating;
using RestaurantRater.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Services.Rating
{
    public class RatingService : IRatingService
    {
        private ApplicationDbContext _context;
        public RatingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool RateRestaurant(RatingCreate model)
        {
            _context.Ratings.Add(new RatingEntity()
            {
                RestaurantId = model.RestaurantId,
                Stars = model.Stars,
            });
            return _context.SaveChanges() == 1;
            throw new NotImplementedException();
        }
        public List<RatingListItem> GetAllRatings()
        {
            return _context.Ratings.Select(r => new RatingListItem() {
                Stars = r.Stars,
                // Here we can use our virtual property to dig a little deeper and get the name of the Restaurant
                Restaurant = r.Restaurant.Name,
            }).ToList();
        }

        public RatingDetail GetRatingById(int id)
        {
            var rating = _context.Ratings.Find(id);
            if (rating == null)
            {
                // Let's play with custom exceptions a little - see if they can guess what status code this will give (should be 500)
                throw new Exception("Rating not found!");
            }
            return new RatingDetail()
            {
                Restaurant = rating.Restaurant.Name,
                Stars = rating.Stars,
                Id = rating.Id,
            };
        }

        public List<RatingListItem> GetRatingsForRestaurant(int restaurantId)
        {
            // This method is similar to our GetAll method, but we can add a LINQ method (.Where()) to only get specific Ratings
            return _context.Ratings
                // Here we can use an arrow expression to define what Ratings we want to include
                .Where(r => r.RestaurantId == restaurantId)
                .Select(r => new RatingListItem()
            {
                Stars = r.Stars,
                Restaurant = r.Restaurant.Name,
                Id = r.Id,
            }).ToList();
        }

        // Once the services and models are set up, now we can create our controllers...
    }
}
