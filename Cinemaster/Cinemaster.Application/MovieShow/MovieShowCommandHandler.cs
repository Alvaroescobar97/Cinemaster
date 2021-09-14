using Cinemaster.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cinemaster.Application.MovieShow
{
    public class MovieShowCommandHandler : AsyncRequestHandler<CreateMovieShowCommand>
    {
        private readonly IMovieShowService _MovieShowService;

        public MovieShowCommandHandler(IMovieShowService movieShowService)
        {
            _MovieShowService = movieShowService;
        }

        protected override async Task Handle(CreateMovieShowCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request object needed to handle this task");
            await _MovieShowService.SaveMovieShowAsync(new Domain.Entities.MovieShow
            {
                Pelicula = request.Pelicula,
                Sala = request.Sala,
                Hora = request.Hora
            }).ConfigureAwait(false);
        }
    }
}
