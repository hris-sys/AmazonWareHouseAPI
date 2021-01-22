using Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Models
{
    public class OrderItem : IIdable
    {
        public OrderItem()
        {
            this.Id = Guid.NewGuid().ToString().Substring(0, 7);
        }
        public string Id { get; set; }

        public Order Order { get; set; }
        public string OrderId { get; set; }

        public Item Item { get; set; }
        public string ItemId { get; set; }

        public int ItemQuantity { get; set; }
    }
}
