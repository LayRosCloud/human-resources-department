using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class RoleEntity : Entity
{
    [Required]
    public string name { get; set; } = "";
}