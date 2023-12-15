using Microsoft.AspNetCore.Mvc;
using virtual_pet_care_api.Entities;

namespace virtual_pet_care_api.Controllers;

[ApiController]
[Route("/api/v1/foods")]
public class FoodController : ControllerBase
{
    
    private readonly PetCareDbContext _dbContext;

    public FoodController(PetCareDbContext petCareDbContext)
    {
        _dbContext = petCareDbContext;
    }
    
    [HttpGet()]
    public IActionResult GetAllFoods()
    {
        var foods = _dbContext.Foods.ToList();
        return Ok(foods);
    }

    [HttpPost("{petId}")]
    public async Task<IActionResult> FeedPet(string petId, Food food)
    {
        food.Id = petId;
        _dbContext.Foods.Add(food);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAllFoods), food);
    }
}