using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        IEnumerable<User> GetAllUsers(Expression<Func<User, bool>> filter = null);

        User GetUserByEmail(string email);

        void CreateUser(User user, City city);

        void SetDeleted(string userId);

        ICollection<User> GetUserOrders(string userId);

        ICollection<User> GetAllUsersFromCity(string cityId);
    }
}
