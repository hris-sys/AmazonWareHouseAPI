using Data.Models.Common;
using Data.Models.Models;
using System.Collections.Generic;

namespace Data.Seeder
{
    public class UserSeeder
    {
        private string[] _names;
        private string[] _emails;
        private UserRoles[] _roles;
        private string[] _password;
        private uint[] _age;


        public UserSeeder(List<City> cities)
        {
            this.Users = new List<User>();
            this.Cities = cities;

            this._names = new string[]
            {
                "Ivan",
                "Petar",
                "Gosho",
                "Admin"
            };
            this._emails = new string[]
            {
                "ivan123@abv.bg",
                "petar456@gmail.com",
                "goshkata992@yahoo.com",
                "admin@admin.com"
            };
            this._roles = new UserRoles[] 
            {
                UserRoles.User,
                UserRoles.User,
                UserRoles.User,
                UserRoles.Admin

            };
            this._password = new string[]
            {
                "ivanevelik123",
                "petarthebest",
                "goshoisgoodatleague",
                "admin123toor",
            };
            this._age = new uint[]
            {
                15,
                34,
                26,
                31
            };

            FillUsers();
        } 
        public List<User> Users { get; set; }

        public List<City> Cities { get; set; }

        private void FillUsers()
        {
            for (int i = 0; i < _names.Length; i++)
            {
                this.Users.Add(new User
                {
                    Name = _names[i],
                    Email = _emails[i],
                    Role = _roles[i],
                    Password = _password[i],
                    Age = _age[i],
                    City = this.Cities[i]
                });
            }
        }
    }
}
