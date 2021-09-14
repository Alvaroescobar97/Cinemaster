using AutoMapper;

namespace Cinemaster.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Person, Cinemaster.Application.Person.PersonDto>();
            CreateMap<Cinemaster.Application.Person.PersonDto, Domain.Entities.Person>();
            CreateMap<Domain.Entities.Address, Cinemaster.Application.Person.AddressDto>();
            CreateMap<Cinemaster.Application.Person.AddressDto, Domain.Entities.Address>();
        }
    }
}
