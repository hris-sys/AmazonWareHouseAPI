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
            this.OrderItems = new HashSet<OrderItem>();
            this.Name = this.User.Name + "'s order";
        }

        private string Name { get; set; }

        public City City { get; set; }
        public string CityId { get; set; }

        public string Remarks { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }


        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
