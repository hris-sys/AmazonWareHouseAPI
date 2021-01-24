using AmazonWareHouse.Business.Models.Cities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonWareHouse.Business.Models.Users
{
    public class CreateUserModel
    {
        public CreateUserModel()
        {
            this.IsAdmin = true;
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Age { get; set; }

        public bool IsAdmin { get; set; }

        public CityModel City { get; set; }
    }
}
