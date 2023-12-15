namespace virtual_pet_care_api.Entities;

public class Activity : BaseEntity<string>
{
    public string Name { get; set; }
    public int PetId { get; set; }
    public Pet Pet { get; set; }
}