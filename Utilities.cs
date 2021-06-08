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
                ManagerFirstName = stanley.Manager?.FirstName
            };

            if (!forgetfulDeveloper)
            {
                flat.ManagerLastName = stanley.Manager?.LastName;
            }

            flat.Address = $"{stanley.Address}";

            return flat;
        }
    }
}