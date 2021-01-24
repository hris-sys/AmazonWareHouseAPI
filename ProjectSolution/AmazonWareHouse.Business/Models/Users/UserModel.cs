using AmazonWareHouse.Business.Models.Cities;
using AmazonWareHouse.Business.Models.Order;
using Data.Models.Common;
using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonWareHouse.Business.Models.Users
{
    public class UserModel : BaseModel
    {
        public UserModel()
        {
            this.Orders = new HashSet<OrderModel>();
        }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public UserRoles Role { get; set; }

        public ICollection<OrderModel> Orders { get; set; }

        public CityModel City { get; set; }

        public string CityId { get; set; }
    }
}
