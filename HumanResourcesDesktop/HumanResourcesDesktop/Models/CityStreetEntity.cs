
using System.Text.Json.Serialization;

namespace HumanResourcesDesktop.Models
{
    public class CityStreetEntity : Entity
    {
        public int city_id { get; set; }

        public int street_id { get; set; }

        [JsonIgnore]
        public CityEntity city { get; set; }

        [JsonIgnore]
        public StreetEntity street { get; set; }
    }
}

