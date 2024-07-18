using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantMVC.Models.Restaurant;
using RestaurantRaterApi.Data;
using RestaurantRaterMVC.Models.Restaurant;
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
public async Task<IActionResult> Details(int id) 
{
    RestaurantDetail? model = await _service.GetRestaurantAsync(id);

    if (model is null) 
    return NotFound();

    return View(model);
} 
//Edit Restaurant 
[HttpGet] 
public async Task<IActionResult> Edit(int id) 
{
    RestaurantDetail? restaurant = await _service.GetRestaurantAsync(id);
if (restaurant is null)
    return NotFound();

    RestaurantEdit model = new()
    {
        Id = restaurant.Id,
        Name = restaurant.Name ?? "",
        Location = restaurant.Location ?? ""
    };
    return View(model);
} 

//Delete 
[HttpGet] 
public async Task<IActionResult> Delete(int id)
{
    RestaurantDetail? restaurant = await _service.GetRestaurantAsync(id) ;
    {
        if (restaurant is null) 
    return RedirectToAction(nameof(Index)); 
    return View(restaurant);
    }

    
} 

[HttpPost] 
[ActionName(nameof(Delete))] 
public async Task<IActionResult> ConfirmDelete(int id) 
{
    await _service.DeleteRestaurantAsync(id);
    return RedirectToAction(nameof(Index));
}

[HttpPost] 
public async Task<IActionResult> Edit(int id, RestaurantEdit model)
{
if (!ModelState.IsValid) 
return View(model);

if(await _service.UpdateRestaurantAsync(model))
return RedirectToAction(nameof(Details), new { id = id});
ModelState.AddModelError("Save Error", "Could not update the Restaurant. Please try again ");
return View(model);
}


[HttpGet] 
public IActionResult Create() 
{
    return View(); 
}

[HttpPost] 
public async Task<IActionResult> Create(RestaurantCreate model) 
{
if(!ModelState.IsValid) 
return View(model); 
await _service.CreateRestaurantAsync(model);
return RedirectToAction(nameof(Index)); 
} 


}