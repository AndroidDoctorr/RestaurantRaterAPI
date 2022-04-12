namespace RestaurantRaterAPI.Models
{
    public class RatingListItem
    {
        public string RestaurantName { get; set; }
        public double FoodScore { get; set; }
        public double CleanlinessScore { get; set; }
        public double AtmosphereScore { get; set; }
    }
}