using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Card.Domain.Models;
using Card.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Card.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;

        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserCard>> Get(string id)
        {
            var card = await _cardRepository.GetCardAsync(id);

            return Ok(card ?? new UserCard(id));
        }

        [HttpPost]
        public async Task<ActionResult<UserCard>> Post([FromBody]UserCard card)
        {
            return Ok(await _cardRepository.AddUpdateCardAsync(card));
        }
    }
}
