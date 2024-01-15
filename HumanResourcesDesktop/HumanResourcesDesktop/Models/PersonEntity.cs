
using System.Text.Json.Serialization;

namespace HumanResourcesDesktop.Models
{
    public class PersonEntity : Entity
    {
        public string last_name { get; set; }

        public string first_name { get; set; }

        public string patronymic { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public bool millitary_duty { get; set; }

        public bool? sex { get; set; }

        public int address_id { get; set; }

        public int role_id { get; set; }

        [JsonIgnore]
        public string SexName => sex == null ? "Не указан" : sex.Value ? "Мужской" : "Женский";
    }
}

