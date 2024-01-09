using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class PassportEntity : Entity
{
    [Required]
    public int employee_id { get; set; }
    
    [Required]
    public int seria { get; set; }
    
    [Required]
    public int number { get; set; }
    
    [Required]
    public int address_registration_id { get; set; }
    
    [Required]
    public int separation_id { get; set; }
    
    [Required]
    public DateTime date { get; set; }
    
    [Required]
    public DateTime birthday { get; set; }
}