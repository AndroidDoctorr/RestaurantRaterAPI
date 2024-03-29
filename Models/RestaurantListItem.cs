namespace RestaurantRaterAPI.Models
{
    public class RestaurantListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double AverageFoodScore { get; set; }
        public double AverageCleanlinessScore { get; set; }
        public double AverageAtmosphereScore { get; set; }
    }
}