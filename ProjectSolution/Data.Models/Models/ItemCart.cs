using Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Models
{
    public class ItemCart : IIdable
    {
        public int Id { get; set; }

        public Cart Cart { get; set; }
        public int CartId { get; set; }

        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
