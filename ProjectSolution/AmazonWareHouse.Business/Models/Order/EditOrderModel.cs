using Data.Models.Common;
using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonWareHouse.Business.Models.Order
{
    public class EditOrderModel
    {
        public OrderStatus Status { get; set; }

        [MaxLength(50)]
        public string Remarks { get; set; }

        public decimal TotalCost { get; set; }

        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public City City { get; set; }

        public string CityId { get; set; }
    }
}
