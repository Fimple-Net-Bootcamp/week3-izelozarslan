using Microsoft.AspNetCore.Mvc;
using virtual_pet_care_api.Entities;

namespace virtual_pet_care_api.Controllers;

[ApiController]
[Route("/api/v1/activities")]
public class ActivityController : ControllerBase
{

    private readonly PetCareDbContext _dbContext;

    public ActivityController(PetCareDbContext petCareDbContext)
    {
        _dbContext = petCareDbContext;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateActivity(Activity activity)
    {
        _dbContext.Activities.Add(activity);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetActivitiesForPet), new { petId = activity.PetId }, activity);
    }

    [HttpGet("{petId}")]
    public IActionResult GetActivitiesForPet(string petId)
    {
        var activities = _dbContext.Activities.Where(a => a.Id == petId).ToList();
        return Ok(activities);
    }
    
}