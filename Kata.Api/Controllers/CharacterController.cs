using Microsoft.AspNetCore.Mvc;
using System;
using Kata.Domain;
using Kata.Application;

namespace Kata.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService service;

        public CharacterController(ICharacterService service)
        {
            this.service = service;
        }

        public Character Post()
        {
            return service.CreateCharacter();
        }
    }
}