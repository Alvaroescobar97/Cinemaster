﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinemaster.Application.Person
{
    public class PersonQuery : IRequest<PersonDto>
    {

        public PersonQuery(Guid id)
        {
            Id = id;
        }

        [Required]
        public Guid Id { get; set; }
    }
}
