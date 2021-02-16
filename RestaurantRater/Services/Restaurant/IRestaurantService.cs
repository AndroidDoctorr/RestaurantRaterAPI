using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Services
{
    public interface IRestaurantService
    {
        // 9. Once we have our Models, we can add methods here. We want to use separate model classes for different purposes, like for creating objects (where we only want certain properties to be determined by the user, but not others, like ID or CreatedAt) or displaying data in partial detail or full detail, for example...

        // 11: Once we have our models, we can define what we want our service methods to do
        // Ctrl . to bring in Models
        // This could also be void, but I want the bool for tests
        bool AddRestaurant(RestaurantCreate model);
        List<RestaurantListItem> GetRestaurants();
        RestaurantDetail GetRestaurantById(int id);

        // We can add the "UD" later. For now let's just implement our first three methods
    }
}
