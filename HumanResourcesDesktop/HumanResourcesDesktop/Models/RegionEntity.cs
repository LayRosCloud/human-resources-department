
using System.Text.Json.Serialization;

namespace HumanResourcesDesktop.Models
{
    public class RegionEntity : Entity
    {
        public string name { get; set; } = "";
        public int country_id { get; set; }
        [JsonIgnore]
        public CountryEntity country { get; set; }
    }
}

