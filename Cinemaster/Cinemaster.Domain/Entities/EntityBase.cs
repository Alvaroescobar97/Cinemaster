using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemaster.Domain.Entities
{
    public class EntityBase<T> : DomainEntity, IEntityBase<T>
    {
        public virtual T Id { get; set; }
    }
}
