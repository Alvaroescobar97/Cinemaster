using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemaster.Application.MovieShow
{
    public class MovieShowDto
    {
        public MovieShowDto() {
            this.Tickets = new List<TicketsDto>();
        }

        public string Pelicula { get; set; }
        public int Sala { get; set; }
        public DateTime Hora { get; set; }
        public IEnumerable<TicketsDto> Tickets { get; set; }
    }
}
