
using System.Text.Json.Serialization;

namespace HumanResourcesDesktop.Models
{
    public class PhoneEntity : Entity
    {
        public int employee_id { get; set; }
        public string number { get; set; }
        public int phone_type_id { get; set; }

        [JsonIgnore]
        public TypeOfPhoneEntity Type { get; set; }
    }
}

