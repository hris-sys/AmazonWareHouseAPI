using Data.Models.Common;
using System.Collections.Generic;

namespace Data.Models.Models
{
    public class User : BaseModel
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        public string Email { get; set; }
        public UserRoles Role { get; set; }
        public string Password { get; set; }

        public uint Age { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
