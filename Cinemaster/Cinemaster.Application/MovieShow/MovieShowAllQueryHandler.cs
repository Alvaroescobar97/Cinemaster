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
    public class MovieShowAllQueryHandler : IRequestHandler<MovieShowAllQuery, List<MovieShowDto>>, IDisposable
    {
        private readonly IGenericRepository<Domain.Entities.MovieShow> _MovieShowRepository;
        private readonly IMapper _Mapper;
        public MovieShowAllQueryHandler(IGenericRepository<Domain.Entities.MovieShow> movieShowRepository, IMapper mapper)
        {
            _MovieShowRepository = movieShowRepository;
            _Mapper = mapper;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<List<MovieShowDto>> Handle(MovieShowAllQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request object needed to handle this task");
            var response = await _MovieShowRepository.GetAsync().ConfigureAwait(false);
            Console.WriteLine(response.ToList());
            return _Mapper.Map<List<MovieShowDto>>(response.ToList());
        }

        protected virtual void Dispose(bool disposing)
        {
            this._MovieShowRepository.Dispose();
        }
    }
}
