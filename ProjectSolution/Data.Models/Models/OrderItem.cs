using Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Models
{
    public class OrderItem : IIdable
    {
        public int Id { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }

        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
