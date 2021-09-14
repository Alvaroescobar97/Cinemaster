using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinemaster.Application.MovieShow
{
    public class MovieShowQuery : IRequest<MovieShowDto>
    {
        public MovieShowQuery(Guid id) {
            Id = id;
        }

        [Required]
        public Guid Id { get; set; }
    }
}
