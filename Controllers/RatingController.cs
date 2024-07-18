using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Services.Ratings;

namespace RestaurantRaterMVC.Controllers; 

public class RatingController : Controller
{
    private readonly IRatingService _service;
    public RatingController(IRatingService service) 
    {
        _service = service;
    }
}