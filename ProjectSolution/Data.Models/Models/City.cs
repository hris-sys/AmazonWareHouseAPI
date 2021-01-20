using Data.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.Models
{
    public class City : BaseModel
    {
        public City()
        {
            this.Users = new HashSet<User>();
        }

        [MaxLength(10)]
        public string PostalCode { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
