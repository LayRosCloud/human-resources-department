using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class AddressEntity : Entity
{
    [Required]
    public int city_street_id { get; set; }
    
    [Required]
    public int home_number { get; set; }
    
    public int? corpus { get; set; }
    
    public int? entrance { get; set; }
    
    [Required]
    public int apartment { get; set; }
}