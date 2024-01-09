using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class PhoneEntity : Entity
{
    [Required]
    public int employee_id { get; set; }
    [Required]
    public string number { get; set; }
    [Required]
    public int phone_type_id { get; set; }
}