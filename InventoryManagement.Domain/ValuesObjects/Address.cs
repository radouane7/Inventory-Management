namespace InventoryManagement.Domain.ValuesObjects
{
    public class Address : IEquatable<Address>
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }

        private Address() { }

        public Address(string street, string city, string state, string zipCode)
        {
            //Validation
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public bool Equals(Address other)
        {
            if (other == null)
                return false;

            return Street == other.Street && City == other.City && State == other.State && ZipCode == other.ZipCode;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj == null || GetType() != obj.GetType()) return false;

            return Equals((Address)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Street.GetHashCode();
                hash = hash * 23 + City.GetHashCode();
                hash = hash * 23 + State.GetHashCode();
                hash = hash * 23 + ZipCode.GetHashCode();
                return hash;
            }
        }
    }
}