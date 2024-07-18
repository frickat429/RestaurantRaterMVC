using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Services.Ratings;

namespace RestaurantRaterMVC.ViewComponents;

[ViewComponent(Name = nameof(RestaurantRatings))]
public class RestaurantRatings : ViewComponent
{
    private readonly IRatingService _ratingService;
    public RestaurantRatings(IRatingService ratingService) => _ratingService = ratingService;

    public async Task<IViewComponentResult> InvokeAsync(int restaurantId)
    {
        var ratings = await _ratingService.GetRestaurantRatingsAsync(restaurantId);
        return View(ratings);
    }
}