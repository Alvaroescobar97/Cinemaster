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
        }
    }
}
