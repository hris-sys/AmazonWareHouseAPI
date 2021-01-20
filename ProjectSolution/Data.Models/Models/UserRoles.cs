using Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Models
{
    public class UserRoles : IIdable
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public string RoleId { get; set; }
        public Role Role { get; set; }

        
    }
}
