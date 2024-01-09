using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class TypeOfPhoneEntity : Entity
{
    [Required]
    public string name { get; set; } = "";
}