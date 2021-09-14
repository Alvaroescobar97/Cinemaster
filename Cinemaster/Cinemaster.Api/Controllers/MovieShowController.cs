using Cinemaster.Application.MovieShow;
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
    public class MovieShowController : ControllerBase
    {

        private readonly IMediator _Mediator;

        public MovieShowController(IMediator mediator) { 
            _Mediator = mediator;
        }

        [HttpGet]
        public async Task<List<MovieShowDto>> GetAll()
        {
            return await _Mediator.Send(new MovieShowAllQuery());
        }

        [HttpGet("{id}")]
        public async Task<MovieShowDto> GetById(Guid id)
        {
            return await _Mediator.Send(new MovieShowQuery(id));
        }

        [HttpPost("createSync")]
        public async Task CreateMovieShow(CreateMovieShowCommand movieShow)
        {
            await _Mediator.Send(movieShow);
        }

    }
}
