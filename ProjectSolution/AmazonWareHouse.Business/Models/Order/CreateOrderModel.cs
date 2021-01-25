using AmazonWareHouse.Business.Models.Cities;
using AmazonWareHouse.Business.Models.Users;
using Data.Models.Common;
using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonWareHouse.Business.Models.Order
{
    public class CreateOrderModel
    {
        public CreateOrderModel()
        {
            this.OrderItemsIds = new List<string>();
            //this.Name = this.User.Name + "'s order";
        }

        private string Name { get; set; }

        public OrderCityModel City { get; set; }

        public string Remarks { get; set; }

        public UserOrderModel User { get; set; }

        public DateTime CreatedAt { get; set; }

        public OrderStatus Status { get; set; }


        public List<string> OrderItemsIds { get; set; }

    }
}
