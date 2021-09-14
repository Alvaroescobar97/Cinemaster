using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemaster.Domain.Entities
{
    public class MovieShow : EntityBase<Guid>
    {
        public MovieShow()
        {
        }

        public MovieShow(string pelicula, int sala, DateTime hora, IEnumerable<Tickets> tickets)
        {
            this.Pelicula = pelicula;
            this.Sala = sala;
            this.Hora = hora;
            this.Tickets = tickets;
        }

        public string Pelicula { get; set; }
        public int Sala { get; set; }
        public DateTime Hora { get; set; }
        public IEnumerable<Tickets> Tickets { get; set; }
    }
}
