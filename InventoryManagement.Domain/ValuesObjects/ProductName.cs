using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.ValuesObjects
{
    public class ProductName : IEquatable<ProductName>
    {
        public string Value { get; }

        public ProductName(string value)
        {
            // Add any validation rules here
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("First name cannot be null or empty", nameof(value));
            }
            Value = value;
        }

        public bool Equals(ProductName? other)
        {
            if (other == null) return false;
            if (ReferenceEquals(other, this)) return true;
            return other.Value == Value;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != GetType()) return false;

            return ((ProductName)obj).Value == Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
