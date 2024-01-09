using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class TypeOfSessionEntity : Entity
{
    [Required]
    public string name { get; set; } = "";
}