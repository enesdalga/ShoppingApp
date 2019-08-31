using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Card.Domain.Models;

namespace Card.Infrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        public Task<UserCard> AddUpdateCardAsync(UserCard card)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCardAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UserCard> GetCardAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
