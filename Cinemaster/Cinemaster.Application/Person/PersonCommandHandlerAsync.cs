using Cinemaster.Application.Ports;
using Cinemaster.Domain.Ports;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cinemaster.Application.Person
{
    public class PersonCommandHandlerAsync : AsyncRequestHandler<CreatePersonCommandAsync>
    {

        private readonly IRabbitMessaging _SystemEvent;

        public PersonCommandHandlerAsync(IRabbitMessaging systemEvent)
        {
            _SystemEvent = systemEvent;
        }

        protected override async Task Handle(CreatePersonCommandAsync request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request object needed to handle this task");
            await _SystemEvent.SendMessageAsync(request, "create-person").ConfigureAwait(false);
        }

    }
}
