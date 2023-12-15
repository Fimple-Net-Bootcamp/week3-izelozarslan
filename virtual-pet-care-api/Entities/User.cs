namespace virtual_pet_care_api.Entities;

public class User : BaseEntity<string>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public List<Pet>? Pets { get; set; }
}