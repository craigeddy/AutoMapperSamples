
// ReSharper disable once CheckNamespace
namespace AutoMapperSamples.Destinations
{
    public class FlatStanley
    {
        public string Name { get; set; }

        public string ManagerFirstName { get; set; }

        public string ManagerLastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
    }
}

namespace AutoMapperSamples.Sources
{
    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Employee Manager { get; set; }

        public Address Address { get; set; }
    }

    public class Office
    {
        public string Name { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZIP { get; set; }

        public override string ToString()
        {
            return $"{Street}, {City}, {State} {ZIP}";
        }
    }
}