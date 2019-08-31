using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Card.Domain.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Card.Infrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public CardRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeleteCardAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<UserCard> GetCardAsync(string userId)
        {
            var data = await _database.StringGetAsync(userId);

            if (data.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserCard>(data);
        }

        public async Task<UserCard> AddUpdateCardAsync(UserCard card)
        {
            if (await _database.KeyExistsAsync(card.UserId))
            {
                var existingItems = await GetCardAsync(card.UserId);
                card.CardItems.AddRange(existingItems.CardItems);
            }

            var createdUserCard = await _database.StringSetAsync(card.UserId, JsonConvert.SerializeObject(card));

            if (!createdUserCard)
            {
                //log
                return null;
            }

            return await GetCardAsync(card.UserId);
        }
    }
}
