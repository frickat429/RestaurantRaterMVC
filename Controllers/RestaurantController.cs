using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Models.Restaurant;
using RestaurantRaterMVC.Services.Restaurants;

namespace RestaurantRaterMVC.Controllers;

public class RestaurantController : Controller
{
private IRestaurantService _service;
public RestaurantController(IRestaurantService service) 
{
    _service = service;
} 
[HttpGet] //Not necessary as EF assumes it is Get unless otherwise spesiffied. 
public async Task<IActionResult> Index()
{
IEnumerable<RestaurantListItem> restaurants = await _service.GetAllRestaurantAsync();
return View(restaurants);
} 

[HttpGet] 
public IActionResult Create() 
{
    return View(); 
}


}