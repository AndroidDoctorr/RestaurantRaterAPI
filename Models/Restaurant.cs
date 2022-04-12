using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RestaurantRaterAPI.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }
        public virtual List<Rating> Ratings { get; set; }

        public double AverageFoodScore
        {
            get
            {
                var averageRating = Ratings.Count > 0 ? Ratings.Select(r => r.FoodScore).Average() : 0;
                return Math.Round(averageRating, 2);
            }
        }
    }
}