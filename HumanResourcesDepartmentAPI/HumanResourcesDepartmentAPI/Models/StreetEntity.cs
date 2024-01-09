using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class StreetEntity : Entity
{
    [Required]
    public string name { get; set; }
}