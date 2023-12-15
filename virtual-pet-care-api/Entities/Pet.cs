using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace virtual_pet_care_api.Entities;

public class Pet : BaseEntity<string>
{
    public string Name { get; set; }
    public string AnimalType { get; set; }
    public string Breed { get; set; }
    public string UserId { get; set; }
    
    [ForeignKey("UserId")]
    public User User { get; set; }
    
    public List<HealthStatus> Healths { get; set; }
    public List<Activity> Activities { get; set; }
    public List<Food> Foods { get; set; }
}