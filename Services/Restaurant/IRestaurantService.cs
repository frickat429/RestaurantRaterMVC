using RestaurantMVC.Models.Restaurant;

namespace RestaurantRaterMVC.Services.Restaurants;

public interface IRestaurantService 
{
Task<IEnumerable<RestaurantListItem>> GetAllRestaurantAsync();
    
}