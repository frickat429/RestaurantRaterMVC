using RestaurantMVC.Models.Restaurant;
using RestaurantRaterMVC.Models.Restaurant;

namespace RestaurantRaterMVC.Services.Restaurants;

public interface IRestaurantService 
{
Task<IEnumerable<RestaurantListItem>> GetAllRestaurantAsync();

Task<bool> CreateRestaurantAsync(RestaurantCreate model);
}