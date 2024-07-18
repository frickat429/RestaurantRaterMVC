using RestaurantRaterApi.Data;

namespace RestaurantRaterMVC.Services.Ratings;

public class RatingService : IRatingService
{
    private readonly RestaurantDbContext _context;
    public RatingService(RestaurantDbContext context) 
    {
        _context = context;
    }
}