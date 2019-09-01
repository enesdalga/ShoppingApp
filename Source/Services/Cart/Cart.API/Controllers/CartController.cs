using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cart.Domain.Models;
using Cart.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserCart>> Get(string id)
        {
            var cart = await _cartRepository.GetCartAsync(id);

            return Ok(cart ?? new UserCart(id));
        }

        [HttpPost]
        public async Task<ActionResult<UserCart>> Post([FromBody]UserCart cart)
        {
            return Ok(await _cartRepository.AddUpdateCartAsync(cart));
        }
    }
}
