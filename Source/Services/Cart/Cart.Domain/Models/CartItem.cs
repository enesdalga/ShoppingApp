using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.Domain.Models
{
    public class CartItem
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
