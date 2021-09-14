using Cinemaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinemaster.Domain.Ports
{
    public interface IMovieShowService
    {
        Task<MovieShow> SaveMovieShowAsync(MovieShow movie);
    }
}
