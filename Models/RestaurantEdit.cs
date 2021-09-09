namespace RestaurantRaterAPI.Models
{
    public class RestaurantEdit
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
    }
}