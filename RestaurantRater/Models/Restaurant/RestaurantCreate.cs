using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Models
{
    // 10: Set up the Restaurant Models
    public class RestaurantCreate
    {
        // The Id property will be set automatically by the database, we don't want it being assigned here
        [Required]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }
        [Display(Name = "Address, Intersection, or Neighbourhood")]
        public string Location { get; set; }
        public double Rating { get; set; } = 0.0;
    }
}
