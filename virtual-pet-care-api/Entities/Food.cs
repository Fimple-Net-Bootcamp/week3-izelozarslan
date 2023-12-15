namespace virtual_pet_care_api.Entities;

public class Food : BaseEntity<string>
{
    public string name { get; set; }
    public int PetId { get; set; }
    public Pet Pet { get; set; }
}