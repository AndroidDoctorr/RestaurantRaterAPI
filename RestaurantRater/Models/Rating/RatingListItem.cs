using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Models.Rating
{
    public class RatingListItem
    {
        public int Id { get; set; }
        public string Restaurant { get; set; }
        public double Stars { get; set; }
    }
}
