using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantRater.Models;
using RestaurantRater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Controllers
{
    // 13??: Create Restaurant controller with basic endpoints - create, get, and get all

    [ApiController]
    // This defines how we can navigate to these controller actions via the URL
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost]
        // Talk about POCOs here and why these models need to be serializable

        // ASYNC/AWAIT LESSON:

        // At some point, refactor this to be async, talk about async and await, threading etc. (service method will also need to be refactored to be async in this case)

        public IActionResult CreateRestaurant([FromBody] RestaurantCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createResult = _restaurantService.AddRestaurant(model);

            if (createResult)
                return Ok("Restaurant was created.");

            return BadRequest("Restaurant could not be created.");
        }

        // This annotation is technically unnecessary but good practice - public methods in a controller are assumed to be GET actions (I think this is still true - test)
        [HttpGet]
        public IActionResult GetRestaurant(int id)
        {
            var restaurant = _restaurantService.GetRestaurantById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }
    }
}
