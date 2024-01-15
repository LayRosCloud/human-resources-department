using System.Text.Json.Serialization;

namespace HumanResourcesDesktop.Models
{
    public class AddressEntity : Entity
    {
        public int city_street_id { get; set; }

        public int home_number { get; set; }

        public int? corpus { get; set; }

        public int? entrance { get; set; }

        public int apartment { get; set; }

        [JsonIgnore]
        public CityStreetEntity cityStreetEntity { get; set; }
        [JsonIgnore]
        public string city_street_name
        {
            get
            {
                if (cityStreetEntity == null)
                {
                    return null;
                }

                return $"{cityStreetEntity.city.area.region.country.name}, {cityStreetEntity.city.area.region.name}, {cityStreetEntity.city.area.name}, {cityStreetEntity.city.name}, {cityStreetEntity.street.name}, {home_number}, {corpus}, {entrance}, {apartment}";
            }
        }
    }
}