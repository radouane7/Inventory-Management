using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        [Key]
        public int Id { get; protected set; }
        public Entity(int id)
        {
            Id = id;
        }

        public bool Equals(Entity? other)
        {
            if (other == null) return false;
            return other.Id == Id;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            return Equals(obj);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
