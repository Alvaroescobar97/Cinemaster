using Cinemaster.Domain.Entities;
using Cinemaster.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinemaster.Domain.Services
{
    [DomainService]
    public class MovieShowService : IMovieShowService, IDisposable
    {

        private readonly IGenericRepository<MovieShow> _MovieShowRepository;

        public MovieShowService(IGenericRepository<MovieShow> movieShowRepository) {
            _MovieShowRepository = movieShowRepository;
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

        public async Task<MovieShow> SaveMovieShowAsync(MovieShow movie)
        {
            return await _MovieShowRepository.AddAsync(movie).ConfigureAwait(false);
        }
    }
}
