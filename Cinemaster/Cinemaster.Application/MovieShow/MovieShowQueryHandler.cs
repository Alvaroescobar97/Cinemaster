using AutoMapper;
using Cinemaster.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cinemaster.Application.MovieShow
{
    public class MovieShowQueryHandler : IRequestHandler<MovieShowQuery, MovieShowDto>, IDisposable
    {

        private readonly IGenericRepository<Domain.Entities.MovieShow> _MovieShowRepository;
        private readonly IMapper _Mapper;
        public MovieShowQueryHandler(IGenericRepository<Domain.Entities.MovieShow> movieShowRepository, IMapper mapper)
        {
            _MovieShowRepository = movieShowRepository;
            _Mapper = mapper;
        }

        public async Task<MovieShowDto> Handle(MovieShowQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request object needed to handle this task");
            var response = await _MovieShowRepository.GetAsync(f => f.Id.Equals(request.Id),
                includeStringProperties: "Tickets").ConfigureAwait(false);
            return _Mapper.Map<MovieShowDto>(response.FirstOrDefault());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this._MovieShowRepository.Dispose();
        }

    }
}
