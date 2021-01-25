using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonWareHouse.Business.Models.Cities
{
    public class OrderCityModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string CityId { get; set; }
    }
}
