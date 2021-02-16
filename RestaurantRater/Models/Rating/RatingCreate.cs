using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Models.Rating
{
    public class RatingCreate
    {
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public double Stars { get; set; }
    }
}
