using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Models
{
    public class RestaurantDetail
    {
        // This is for displaying the details of an individual restaurant. Right now it's identical to the RestaurantListItem but we might want to add properties later that we don't want to display in a list
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double Rating { get; set; }
    }
}
