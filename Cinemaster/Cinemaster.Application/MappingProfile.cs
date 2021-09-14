using AutoMapper;
using System.Collections.Generic;

namespace Cinemaster.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.MovieShow, List<Cinemaster.Application.MovieShow.MovieShowDto>>();
            CreateMap<List<Cinemaster.Application.MovieShow.MovieShowDto>, Domain.Entities.MovieShow>();

            CreateMap<Domain.Entities.MovieShow, Cinemaster.Application.MovieShow.MovieShowDto>();
            CreateMap<Cinemaster.Application.MovieShow.MovieShowDto, Domain.Entities.MovieShow>();

            CreateMap<Domain.Entities.Person, Cinemaster.Application.Person.PersonDto>();
            CreateMap<Cinemaster.Application.Person.PersonDto, Domain.Entities.Person>();
            CreateMap<Domain.Entities.Address, Cinemaster.Application.Person.AddressDto>();
            CreateMap<Cinemaster.Application.Person.AddressDto, Domain.Entities.Address>();
        }
    }
}
