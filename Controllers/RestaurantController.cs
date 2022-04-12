using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RestaurantRaterAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace RestaurantRaterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _context;
        public RestaurantController(RestaurantDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostRestaurant([FromForm] RestaurantEdit model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Restaurants.Add(new Restaurant()
            {
                Name = model.Name,
                Location = model.Location,
            });

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await _context.Restaurants.Include(r => r.Ratings).ToListAsync();

            var restaurantList = restaurants.Select(restaurant =>
            {
                var ratings = restaurant.Ratings;

                double averageFoodScore = 0;
                double averageCleanlinessScore = 0;
                double averageAtmosphereScore = 0;

                if (ratings != null && ratings.Count > 0)
                {
                    averageFoodScore = ratings.Select(s => s.FoodScore).Average();
                    averageCleanlinessScore = ratings.Select(s => s.CleanlinessScore).Average();
                    averageAtmosphereScore = ratings.Select(s => s.AtmosphereScore).Average();
                }

                return new RestaurantListItem()
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    Location = restaurant.Location,
                    AverageFoodScore = Math.Round(averageFoodScore, 2),
                    AverageCleanlinessScore = Math.Round(averageCleanlinessScore, 2),
                    AverageAtmosphereScore = Math.Round(averageAtmosphereScore, 2),
                };
            });

            return Ok(restaurantList);
        }






        [HttpPost]
        [Route("GetRestaurantById/{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            var restaurant = await _context.Restaurants.Include(r => r.Ratings).SingleOrDefaultAsync(r => r.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}