
namespace HumanResourcesDesktop.Models
{
    public class Entity
    {
        public int id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Entity entity)
            {
                return entity.id == id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return id;
        }
    }
}

