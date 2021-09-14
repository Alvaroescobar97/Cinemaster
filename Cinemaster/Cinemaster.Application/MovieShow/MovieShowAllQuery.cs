using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemaster.Application.MovieShow
{
    public class MovieShowAllQuery : IRequest<List<MovieShowDto>>
    {
        public MovieShowAllQuery() { }
    }
}
