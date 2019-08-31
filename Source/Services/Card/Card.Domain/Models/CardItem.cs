using System;
using System.Collections.Generic;
using System.Text;

namespace Card.Domain.Models
{
    public class CardItem
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
