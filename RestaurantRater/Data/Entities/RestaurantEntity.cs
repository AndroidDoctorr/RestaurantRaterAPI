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

        // Since this property is called Id (ID, RestaurantEntityId and  would also work), it doesn't need this annotation, but just for clarity
        // https://www.learnentityframeworkcore.com/conventions#:~:text=The%20convention%20for%20a%20foreign,primary%20key%20property%20name%3EId
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        // Possible future refactor: Make Location an object with City, State, Address, and Zip properties? Separate City, Zip, and State into separate tables for faster search indexing?
        public string Location { get; set; }
        // Future Refactor: Collect ratings from actual rating table
        public double Rating { get; set; }
    }
}
