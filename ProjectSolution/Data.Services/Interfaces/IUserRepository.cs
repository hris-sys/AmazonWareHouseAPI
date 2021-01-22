using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        //Add new functionality
        //IEnumerable<User> GetAllUsersWithBooks(Expression<Func<User, bool>> filter = null);

        //
        User GetUserByEmail(string email);

        ICollection<User> GetUserOrders();

        ICollection<User> GetAllUsersFromCity(string city);
    }
}
