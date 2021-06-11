using AutoMapperSamples.Destinations;
using AutoMapperSamples.Sources;

namespace AutoMapperSamples
{
    public class Utilities
    {
        public static FlatStanley GetFlatStanley(Employee stanley, bool forgetfulDeveloper = true)
        {
            var flat = new FlatStanley
            {
                Name = $"{stanley.FirstName} {stanley.LastName}", 
                ManagerLastName = stanley.Manager?.LastName
            };

            if (!forgetfulDeveloper)
            {
                flat.ManagerFirstName = stanley.Manager?.FirstName;
            }

            flat.Address = $"{stanley.Address}";

            return flat;
        }
    }
}