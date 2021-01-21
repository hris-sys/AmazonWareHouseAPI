using Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Models
{
    public class OrderItem : IIdable
    {
        public Guid Id { get; set; }

        public Order Order { get; set; }
        public Guid OrderId { get; set; }

        public Item Item { get; set; }
        public Guid ItemId { get; set; }
    }
}
