using Data.Connection;
using Data.Models.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Services.Classes
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AmazonDbContext context) : base(context)
        {

        }

        public IEnumerable<User> GetAllUsers(Expression<Func<User, bool>> filter = null)
        {
            if (filter != null)
            {
                return DbSet.Where(filter)
                    .Include(u => u.Orders)
                    .ThenInclude(o => o.City)
                    .Where(u => u.IsDeleted == false);
            }

            return DbSet.Where(filter)
                    .Include(u => u.Orders)
                    .ThenInclude(o => o.City)
                    .Where(u => u.IsDeleted == false);
        }

        public void CreateUser(User user, City city)
        {
            var entity = new User()
            {
                Name = user.Name,
                Age = user.Age,
                City = city,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };

            this.DbSet.Add(entity);
            this.Context.SaveChanges();
        }

        public ICollection<User> GetAllUsersFromCity(string cityId)
        {
            if (this.Context.Cities.FirstOrDefault(x => x.Id == cityId) is null)
            {
                throw new NullReferenceException("There is no such city!");
            }

            var results = DbSet.Include(x => x.City).Where(u => u.City.Id == cityId && u.IsDeleted == false).ToList();

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

        public void SetDeleted(string userId)
        {
            var user = this.DbSet.FirstOrDefault(x => x.Id == userId);

            if (user is null)
            {
                throw new NullReferenceException("The user does not exist!");
            }
            else
            {
                user.IsDeleted = true;
            }
        }

       
    }
}
