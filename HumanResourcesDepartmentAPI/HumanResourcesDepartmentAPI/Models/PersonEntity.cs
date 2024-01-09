using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class PersonEntity : Entity
{
    [Required]
    public string last_name { get; set; }
    
    [Required]
    public string first_name { get; set; }
    
    public string? patronymic { get; set; }
    
    [Required]
    public string login { get; set; }
    
    [Required]
    public string password { get; set; }
    
    [Required]
    public bool millitary_duty { get; set; }
    
    [Required]
    public bool? sex { get; set; }
    
    [Required]
    public int address_id { get; set; }
    
    [Required]
    public int role_id { get; set; }
}