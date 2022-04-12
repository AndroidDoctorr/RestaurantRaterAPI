using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RestaurantRaterAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;


namespace RestaurantRaterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : Controller
    {
        private RestaurantDbContext _context;
        public RatingController(RestaurantDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RateRestaurant([FromForm] RatingEdit model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ratings.Add(new Rating()
            {
                RestaurantId = model.RestaurantId,
                FoodScore = model.FoodScore,
                CleanlinessScore = model.CleanlinessScore,
                AtmosphereScore = model.AtmosphereScore,
            });

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRatings()
        {
            var ratings = await _context.Ratings.Include(r => r.Restaurant).ToListAsync();
            var ratingList = ratings.Select(r =>   // LINQ method
                new RatingListItem()
                {
                    RestaurantName = r.Restaurant.Name,
                    FoodScore = r.FoodScore,
                    CleanlinessScore = r.CleanlinessScore,
                    AtmosphereScore = r.AtmosphereScore,
                });
            return Ok(ratingList);
        }

        [HttpGet]
        [Route("{id}")]   // localhost/Rating/1
        public async Task<IActionResult> GetRatingsForRestaurant(int id)
        {
            var ratings = await _context.Ratings.Include(r => r.Restaurant).Where(r => r.RestaurantId == id).ToListAsync();

            IEnumerable<RatingListItem> ratingList = ratings.Select(r => new RatingListItem()
            {
                RestaurantName = r.Restaurant.Name,
                FoodScore = r.FoodScore,
                CleanlinessScore = r.CleanlinessScore,
                AtmosphereScore = r.AtmosphereScore,
            });

            return Ok(ratingList);
        }
    }
}