using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cart.Domain.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Cart.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public CartRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeleteCartAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<UserCart> GetCartAsync(string userId)
        {
            var data = await _database.StringGetAsync(userId);

            if (data.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserCart>(data);
        }

        public async Task<UserCart> AddUpdateCartAsync(UserCart cart)
        {
            if (await _database.KeyExistsAsync(cart.UserId))
            {
                var existingItems = await GetCartAsync(cart.UserId);
                cart.CartItems.AddRange(existingItems.CartItems);
            }

            var createdUserCart = await _database.StringSetAsync(cart.UserId, JsonConvert.SerializeObject(cart));

            if (!createdUserCart)
            {
                //log
                return null;
            }

            return await GetCartAsync(cart.UserId);
        }
    }
}
