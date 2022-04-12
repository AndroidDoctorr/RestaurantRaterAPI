using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterAPI.Models
{
    public class RatingEdit
    {
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public float FoodScore { get; set; }
        [Required]
        public float CleanlinessScore { get; set; }
        [Required]
        public float AtmosphereScore { get; set; }
    }
}