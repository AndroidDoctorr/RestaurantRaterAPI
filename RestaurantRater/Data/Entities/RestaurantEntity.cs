using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater.Data.Entities
{
    public class RestaurantEntity
    {
        // 7: Set up the Restaurant Data Model (or Entity Model)
        // Use this to set up the DB Context...

        // Since this property is called Id, it doesn't need this annotation, but just for clarity
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        // Possible future refactor: Make Location an object with City, State, Address, and Zip properties? Separate City, Zip, and State into separate tables for faster search indexing?
        public string Location { get; set; }
        // Future Refactor: Collect ratings from actual rating table
        public double Rating { get; set; }
    }
}
