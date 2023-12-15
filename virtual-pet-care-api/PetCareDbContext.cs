using Microsoft.EntityFrameworkCore;
using virtual_pet_care_api.Entities;

namespace virtual_pet_care_api;

public class PetCareDbContext : DbContext
{

    public PetCareDbContext(DbContextOptions<PetCareDbContext> options) : base(options)
        {

        }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

    public DbSet<User> Users { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<HealthStatus> HealthStatus { get; set; }
}