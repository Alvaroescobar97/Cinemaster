using Cinemaster.Domain.Ports;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cinemaster.Application.Person
{
    public class PersonCommandHandler : AsyncRequestHandler<CreatePersonCommand>
    {

        private readonly IPersonService _PersonService;

        public PersonCommandHandler(IPersonService personService)
        {
            _PersonService = personService;
        }

        protected override async Task Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request object needed to handle this task");
            await _PersonService.SavePersonAsync(new Domain.Entities.Person
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            }).ConfigureAwait(false);
        }

    }
}
