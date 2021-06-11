using AutoMapper;
using AutoMapperSamples.Destinations;
using AutoMapperSamples.Sources;

namespace AutoMapperSamples
{
    public static class Configurators
    {
        private static MapperConfiguration _config;

        /// <summary>
        /// Create the <see cref="MapperConfiguration"/>
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration AutoMapper()
        {
            return new MapperConfiguration(cfg =>
                cfg.CreateMap<Employee, FlatStanley>()
                    .ForMember(d => d.Name,
                        opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                    .ForMember(d => d.City,
                        opt => opt.MapFrom(src => src.Address.City))
            );
        }

        /// <summary>
        /// Only create the <see cref="MapperConfiguration"/> once...
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration GetSingletonConfiguration()
        {
            if (_config != null) return _config;

            _config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Employee, FlatStanley>()
                    .ForMember(d => d.Name,
                        opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                    .ForMember(d => d.City,
                        opt => opt.MapFrom(src => src.Address.City)));

            return _config;
        }
    }
}