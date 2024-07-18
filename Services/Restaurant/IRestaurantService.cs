using RestaurantMVC.Models.Restaurant;
using RestaurantRaterApi.Data;
using RestaurantRaterMVC.Models.Restaurant;

namespace RestaurantRaterMVC.Services.Restaurants;

public interface IRestaurantService 
{
Task<IEnumerable<RestaurantListItem>> GetAllRestaurantAsync();

Task<bool> CreateRestaurantAsync(RestaurantCreate model); 

Task<RestaurantDetail?> GetRestaurantAsync(int id);
Task<bool> UpdateRestaurantAsync(RestaurantEdit model);
Task<bool> DeleteRestaurantAsync(int id);
} 

