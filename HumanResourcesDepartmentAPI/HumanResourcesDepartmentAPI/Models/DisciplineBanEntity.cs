using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class DisciplineBanEntity : Entity
{
    [Required]
    public int employee_id { get; set; }
    [Required]
    public string ban { get; set; }
    [Required]
    public DateTime date { get; set; }
}