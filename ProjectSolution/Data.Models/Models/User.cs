using Data.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.Models
{
    public class User : BaseModel
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public UserRoles Role { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public uint Age { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
