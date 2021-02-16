using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Models.Rating
{
    public class RatingDetail
    {
        public string Restaurant { get; set; }
        public double Stars { get; set; }

        // We can include additional properties here that we wouldn't include in the ListItem class - like Rater, DateCreated, etc.
    }
}
