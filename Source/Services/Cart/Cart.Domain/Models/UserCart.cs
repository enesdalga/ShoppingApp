using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.Domain.Models
{
    public class UserCart
    {
        public string UserId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public UserCart(string userId)
        {
            UserId = userId;
            CartItems = new List<CartItem>();
        }
    }
}
