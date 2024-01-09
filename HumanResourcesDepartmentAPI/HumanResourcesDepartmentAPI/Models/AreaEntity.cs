using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class AreaEntity : Entity
{
    public string? name { get; set; }
    
    [Required]
    public int region_id { get; set; }
}