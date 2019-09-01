using Cart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Infrastructure.Repositories
{
    public interface ICartRepository
    {
        Task<UserCart> GetCartAsync(string userId);
        Task<UserCart> AddUpdateCartAsync(UserCart cart);
        Task<bool> DeleteCartAsync(string id);
    }
}
