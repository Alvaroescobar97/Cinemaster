using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemaster.Domain.Services
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DomainServiceAttribute : Attribute
    {
    }
}
