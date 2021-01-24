using Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonWareHouse.Business.Models.Order
{
    public class OrderModel : BaseModel
    {
        public OrderStatus Status { get; set; }

        public string Remarks { get; set; }

        public decimal TotalCost { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
