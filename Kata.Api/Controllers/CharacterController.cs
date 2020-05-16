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

        [HttpPost]
        public Character Post()
        {
            return service.CreateCharacter();
        }

        [HttpPut("damage/{characterId}")]
        public bool PutDamage([FromRoute]string characterId, [FromBody]int amount)
        {
            return service.DamageCharacter(characterId, amount);
        }

        [HttpPut("heal/{characterId}")]
        public bool PutHealing([FromRoute]string characterId, [FromBody]int amount)
        {
            return service.HealCharacter(characterId, amount);
        }
    }
}