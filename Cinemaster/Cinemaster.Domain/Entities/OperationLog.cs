using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemaster.Domain.Entities
{
    public class OperationLog : EntityBase<Guid>
    {
        public string LogContent { get; set; }
    }
}
