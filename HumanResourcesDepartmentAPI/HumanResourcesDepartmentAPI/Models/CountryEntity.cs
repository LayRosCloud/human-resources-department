using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class CountryEntity : Entity
{
    [Required]
    public string name { get; set; } = "";
}