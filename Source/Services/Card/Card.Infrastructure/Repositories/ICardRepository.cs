using Card.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Card.Infrastructure.Repositories
{
    public interface ICardRepository
    {
        Task<UserCard> GetCardAsync(string userId);
        Task<UserCard> AddUpdateCardAsync(UserCard card);
        Task<bool> DeleteCardAsync(string id);
    }
}
