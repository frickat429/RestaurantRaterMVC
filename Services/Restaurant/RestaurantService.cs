using Microsoft.EntityFrameworkCore;
using RestaurantMVC.Models.Restaurant;
using RestaurantRaterApi.Data;
using RestaurantRaterMVC.Services.Restaurants;

namespace RestaurantRaterMVC.Services.Restaurant; 

public class RestaurantService : IRestaurantService
{
    private RestaurantDbContext _context;
    public RestaurantService(RestaurantDbContext context) 
    {
    _context = context;
    } 

public async Task<IEnumerable<RestaurantListItem>> GetAllRestaurantAsync()
{
    List<RestaurantListItem> restaurants = await _context.Restaurants
        .Include(r => r.Ratings)
        .Select(r => new RestaurantListItem()
        {
            Id = r.Id,
            Name = r.Name,
            Score = r.AverageRating
        })
        .ToListAsync();
        return restaurants;
    }

 
}