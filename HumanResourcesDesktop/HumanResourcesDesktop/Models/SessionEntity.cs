using System;
using System.Text.Json.Serialization;

namespace HumanResourcesDesktop.Models
{
    public class SessionEntity : Entity
    {
        public int employee_id { get; set; }

        public DateTime date_start { get; set; } = DateTime.Now;

        public DateTime date_end { get; set; } = DateTime.Now;

        public int type_of_session_id { get; set; }

        [JsonIgnore]
        public PersonEntity person { get; set; }

        [JsonIgnore]
        public TypeOfSessionEntity type { get; set; }
    }
}

