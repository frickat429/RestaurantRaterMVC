using Microsoft.EntityFrameworkCore;
using RestaurantMVC.Models.Restaurant;
using RestaurantRaterApi.Data;
using RestaurantRaterMVC.Models.Restaurant;
using RestaurantRaterMVC.Services.Restaurants;

namespace RestaurantRaterMVC.Services.Restaurants; 

public class RestaurantService : IRestaurantService
{
    private RestaurantDbContext _context;
    public RestaurantService(RestaurantDbContext context) 
    {
    _context = context;
    } 

    public async Task<bool> CreateRestaurantAsync(RestaurantCreate model) 
    {
    Restaurant  entity = new()
    {
        Name = model.Name,
        Location = model.Location
    };
    _context.Restaurants.Add(entity);
    return await _context.SaveChangesAsync() == 1;
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
    public async Task<RestaurantDetail?> GetRestaurantAsync(int id) 
    {
    Restaurant? restaurant = await _context.Restaurants
    .Include(r => r.Ratings)
    .FirstOrDefaultAsync(r => r.Id == id);
    return restaurant is null ? null : new()
    {
        Id = restaurant.Id, 
        Name = restaurant.Name,
        Location = restaurant.Location,
        Score = restaurant.AverageRating
    };
    }
    public async Task<bool> UpdateRestaurantAsync(RestaurantEdit model) 
    {
        Restaurant? entity = await _context.Restaurants.FindAsync(model.Id);
        if(entity is null) 
        return false; 

        entity.Name = model.Name;
        entity.Location = model.Location;
        return await _context.SaveChangesAsync() == 1;
    } 

    public async Task<bool> DeleteRestaurantAsync(int id) 
    {
        Restaurant? entity = await _context.Restaurants.FindAsync(id);
        if(entity is null) 
        return false;
           var ratings = await _context.Ratings.Where(r => r.RestaurantId == entity.Id).ToListAsync();
    _context.Ratings.RemoveRange(ratings);
    await _context.SaveChangesAsync();
        _context.Restaurants.Remove(entity);
        return await _context.SaveChangesAsync() == 1;
    }
    }