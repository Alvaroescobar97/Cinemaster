using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemaster.Api.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionController : ControllerBase
    {

        private readonly IMediator _Mediator;

        public FuncionController(IMediator mediator) { 
            _Mediator = mediator;
        }

        [HttpGet]
        public async Task<Application.Funcion.FuncionDto> GetById(Guid id)
        {
            return await _Mediator.Send();
        }

        [HttpPost("sync")]
        public async Task CreateUser()
        {
            await _Mediator.Send();
        }

    }
}
