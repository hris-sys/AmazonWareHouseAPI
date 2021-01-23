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
            this.Orders = new HashSet<Order>();
        }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public bool IsAdmin { get; set; }

        public ICollection<Order> Orders { get; set; }

        public City City { get; set; }

        public string CityId { get; set; }
    }
}
