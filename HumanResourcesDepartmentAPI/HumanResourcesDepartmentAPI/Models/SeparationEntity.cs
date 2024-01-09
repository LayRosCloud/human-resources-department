using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class SeparationEntity: Entity
{
    [Required]
    public string name { get; set; }
    
    [Required]
    public string code { get; set; }
}