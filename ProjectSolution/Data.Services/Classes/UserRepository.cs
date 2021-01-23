using Data.Connection;
using Data.Models.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data.Services.Classes
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AmazonDbContext context) : base (context)
        {

        }

        public ICollection<User> GetAllUsersFromCity(string city)
        {
            var results = DbSet.Include(x => x.City).Where(u => u.City.Name.ToLower() == city.ToLower()).ToList();

            return results;
        }

        public User GetUserByEmail(string email)
        {
            var result = DbSet.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            return result;
        }

        public ICollection<Order> GetUserOrders(User user)
        {
            return this.Context.Orders.Include(x => x.User).Where(x => x.UserId == user.Id && x.IsDeleted == false).ToList();

            //Include -> from-to
            //Then Include -> inner from-to
        }
    }
}
