using System;
using System.Text.Json.Serialization;

namespace HumanResourcesDesktop.Models
{
    public class PassportEntity : Entity
    {
        public int employee_id { get; set; }

        public int seria { get; set; }

        public int number { get; set; }

        public int address_registration_id { get; set; }

        public int separation_id { get; set; }

        public DateTime date { get; set; }

        public DateTime birthday { get; set; }

        [JsonIgnore]
        public AddressEntity address { get; set; }
    }
}
