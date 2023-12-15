using Microsoft.AspNetCore.Mvc;
using virtual_pet_care_api.Entities;

namespace virtual_pet_care_api.Controllers;

[ApiController]
[Route("/api/v1/users")]
public class UserController : ControllerBase
{
    private readonly PetCareDbContext _dbContext;

    public UserController(PetCareDbContext petCareDbContext)
    {
        _dbContext = petCareDbContext;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUser), new { userId = user.Id }, user);
    }

    [HttpGet("{userId}")]
    public IActionResult GetUser(string userId)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}