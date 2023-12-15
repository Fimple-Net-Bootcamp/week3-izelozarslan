namespace virtual_pet_care_api.Entities;

public class HealthStatus : BaseEntity<string>
{
    public string PetId { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public bool IsVaccinated { get; set; }
    public Pet Pet { get; set; }
}