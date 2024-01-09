using System.ComponentModel.DataAnnotations;

namespace HumanResourcesDepartmentAPI.Models;

public class CityStreetEntity : Entity
{
    [Required] 
    public int city_id { get; set; }
    
    [Required] 
    public int street_id { get; set; }
}