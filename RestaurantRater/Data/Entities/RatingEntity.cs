using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Data.Entities
{
    public class RatingEntity
    {
        public int Id { get; set; }

        // Here we are setting up a connection to the Restaurant table. Each Rating is attached to exactly one Restaurant, but many Ratings can attach to the same Restaurant. This is therefore a many-to-one relationship.

        // This annotation should also be redundant. The fact that we have a table called Restaurants means Entity Framework will by default try to connect it to any other tables with the property "RestaurantId"

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        // We also want to create a "virtual" Restaurant property - this means that when we load a Rating, EF will "lazy-load" the Restaurant with it. giving us access to its properties.

        public virtual RestaurantEntity Restaurant { get; set; }
        public double Stars { get; set; }

        // Now add the DbSet to the ApplicationDbContext and start creating Models
    }
}
