using System;
using System.Collections.Generic;
using System.Text;

namespace Card.Domain.Models
{
    public class UserCard
    {
        public string UserId { get; set; }
        public List<CardItem> CardItems { get; set; }

        public UserCard(string userId)
        {
            UserId = userId;
            CardItems = new List<CardItem>();
        }
    }
}
