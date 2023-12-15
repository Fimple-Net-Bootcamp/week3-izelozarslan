using Microsoft.AspNetCore.Mvc;
using virtual_pet_care_api.Entities;

namespace virtual_pet_care_api.Controllers;

[ApiController]
[Route("/api/v1/health-statuses")]
public class HealthStatusController : ControllerBase
{
    private readonly PetCareDbContext _dbContext;

    public HealthStatusController(PetCareDbContext petCareDbContext)
    {
        _dbContext = petCareDbContext;
    }
    
    [HttpGet("{petId}")]
    public IActionResult GetHealthStatus(string petId)
    {
        var healthStatus = _dbContext.HealthStatus.FirstOrDefault(h => h.PetId == petId);

        if (healthStatus == null)
        {
            return NotFound();
        }

        return Ok(healthStatus);
    }

    [HttpPatch("{petId}")]
    public async Task<IActionResult> UpdateHealthStatus(string petId, HealthStatus updatedHealthStatus)
    {
        var healthStatus = _dbContext.HealthStatus.FirstOrDefault(h => h.PetId == petId);

        if (healthStatus == null)
        {
            return NotFound();
        }

        healthStatus.Weight = updatedHealthStatus.Weight;
        healthStatus.Height = updatedHealthStatus.Height;
        healthStatus.IsVaccinated = updatedHealthStatus.IsVaccinated;

        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}