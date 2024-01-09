using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class SessionEntity : Entity
{
    [Required]
    public int employee_id { get; set; }
    
    [Required]
    public DateTime date_start { get; set; }
    
    [Required]
    public DateTime date_end { get; set; }
    
    [Required]
    public int type_of_session_id { get; set; }
}