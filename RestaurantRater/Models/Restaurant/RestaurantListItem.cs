using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Models
{
    public class RestaurantListItem
    {
        // This is just for displaying restaurants in a list
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double Rating { get; set; }

        // Now that we have our models, we can set up our service methods...
    }
}
