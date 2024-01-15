
using System.Text.Json.Serialization;

namespace HumanResourcesDesktop.Models
{
    public class CityEntity : Entity
    {
        public string name { get; set; }

        public int area_id { get; set; }
        [JsonIgnore]
        public AreaEntity area { get; set; }
    }
}

