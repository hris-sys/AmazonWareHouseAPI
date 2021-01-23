using AmazonWareHouse.Business.Models.Order;
using AmazonWareHouse.Business.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWareHouse.Business.Services.Interfaces
{
    public interface IUserService
    {
        List<UserModel> GetAll(Expression<Func<UserModel, bool>> filter = null);

        UserModel GetById(string id);

        Task InsertAsync(CreateUserModel model);

        Task RemoveAsync(string id);

        Task UpdateAsync(EditUserModel model);

        List<OrderModel> GetUserOrders(string id);

        List<UserModel> GetAllUsersFromCity(string city);

        UserAuthModel GetUserByEmail(string email);

        bool DoesEmailExist(string email);
    }
}
