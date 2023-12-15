using Microsoft.AspNetCore.Mvc;
using virtual_pet_care_api.Entities;

namespace virtual_pet_care_api.Controllers;

[ApiController]
[Route("/api/v1/pets")]
public class PetController : ControllerBase
{
    
    private readonly PetCareDbContext _dbContext;

    public PetController(PetCareDbContext petCareDbContext)
    {
        _dbContext = petCareDbContext;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePet(Pet pet)
    {
        _dbContext.Pets.Add(pet);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPet), new { petId = pet.Id }, pet);
    }

    [HttpGet()]
    public IActionResult GetAllPets()
    {
        var pets = _dbContext.Pets.ToList();
        return Ok(pets);
    }

    [HttpGet("{petId}")]
    public IActionResult GetPet(string petId)
    {
        var pet = _dbContext.Pets.FirstOrDefault(p => p.Id == petId);

        if (pet == null)
        {
            return NotFound();
        }

        return Ok(pet);
    }

    [HttpPut("{petId}")]
    public async Task<IActionResult> UpdatePet(string petId, Pet updatedPet)
    {
        var pet = _dbContext.Pets.FirstOrDefault(p => p.Id == petId);

        if (pet == null)
        {
            return NotFound();
        }

        pet.Name = updatedPet.Name;

        await _dbContext.SaveChangesAsync();

        return Ok();
    }
}