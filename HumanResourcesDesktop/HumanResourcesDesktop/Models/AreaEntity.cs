
using System.Text.Json.Serialization;

namespace HumanResourcesDesktop.Models
{
    public class AreaEntity : Entity
    {
        public string name { get; set; }

        public int region_id { get; set; }
        [JsonIgnore]
        public RegionEntity region { get; set; }
    }
}

