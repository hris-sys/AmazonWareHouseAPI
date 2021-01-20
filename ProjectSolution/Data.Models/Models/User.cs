using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Data.Models.Models
{
    public class User : IdentityUser
    {

        public City City { get; set; }
        public int CityId { get; set; }
    }
}
