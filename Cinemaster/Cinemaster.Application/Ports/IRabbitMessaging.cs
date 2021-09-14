using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinemaster.Application.Ports
{
    public interface IRabbitMessaging
    {
        Task SendMessageAsync(object o, string queue);
    }
}
