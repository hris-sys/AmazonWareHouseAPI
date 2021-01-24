using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonWareHouse.Business.Models.Cities
{
    public class CityModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
