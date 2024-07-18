using RestaurantRaterApi.Data;
using RestaurantRaterMVC.Models.Rating;

namespace RestaurantRaterMVC.Services.Ratings;

public interface IRatingService
{
    Task<List<RatingListItem>> GetRatingsAsync();
    Task<List<RatingListItem>> GetRestaurantRatingsAsync(int restaurantId);
}