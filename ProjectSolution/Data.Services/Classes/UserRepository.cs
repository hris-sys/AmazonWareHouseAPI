using Data.Connection;
using Data.Models.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Services.Classes
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AmazonDbContext context) : base(context)
        {

        }

        public ICollection<User> GetAllUsersFromCity(string cityId)
        {
            if (this.Context.Cities.FirstOrDefault(x => x.Id == cityId) is null)
            {
                throw new NullReferenceException("There is no such city!");
            }

            var results = DbSet.Include(x => x.City).Where(u => u.City.Name.ToLower() == cityId.ToLower() && u.IsDeleted == false).ToList();

            return results;
        }

        public User GetUserByEmail(string email)
        {
            var result = DbSet.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            return result;
        }

        public ICollection<User> GetUserOrders(string userId)
        {
            //The list will return 0 if there are no such users or orders.
            return this.Context.Users.Include(x => x.Orders).Include(x => x.City).Where(x => x.Id == userId && x.IsDeleted == false).ToList();
        }
    }
}
