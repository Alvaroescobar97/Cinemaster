using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinemaster.Application.MovieShow
{
    public class CreateMovieShowCommand : IRequest
    {
        public CreateMovieShowCommand() {

        }

        public CreateMovieShowCommand(string pelicula, int sala, DateTime hora)
        {
            Pelicula = pelicula;
            Sala = sala;
            Hora = hora;
        }

        [Required]
        public string Pelicula { get; set; }
        [Required]
        public int Sala { get; set; }
        [Required]
        public DateTime Hora { get; set; }
    }
}
