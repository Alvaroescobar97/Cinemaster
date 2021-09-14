using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemaster.Domain.Entities
{
    public class Tickets : EntityBase<Guid>
    {
        public Tickets()
        {
        }
        public Tickets(string silla)
        {
            this.Silla = silla;
        }
        public string Silla { get; set; }

        public virtual MovieShow MovieShow { get; set; }
        public Guid MovieShowId { get; set; }
    }
}
