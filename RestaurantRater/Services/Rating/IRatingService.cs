using RestaurantRater.Models.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Services.Rating
{
    public interface IRatingService
    {
        bool RateRestaurant(RatingCreate model);
        List<RatingListItem> GetAllRatings();
        // We will demonstrate later that this is redundant - lazy loading can do this for us!
        List<RatingListItem> GetRatingsForRestaurant(int restaurantId);
        RatingDetail GetRatingById(int id);
    }
}
