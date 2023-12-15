namespace virtual_pet_care_api.Entities;

public abstract class BaseEntity<T>
{
    public  T Id { get; set; }
    
}