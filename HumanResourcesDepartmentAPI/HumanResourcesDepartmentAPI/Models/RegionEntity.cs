using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class RegionEntity : Entity
{
    [Required]
    public string name { get; set; } = "";
    [Required]
    public int country_id { get; set; }
}