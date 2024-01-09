using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class CityEntity : Entity
{
    [Required]
    public string name { get; set; }
    
    [Required]
    public int area_id { get; set; }
}