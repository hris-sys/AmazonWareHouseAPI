using Data.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Models
{
    [Table("Roles")]
    public class Role : IdentityRole<string>, IAuditInfo
    {

        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string RoleName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
