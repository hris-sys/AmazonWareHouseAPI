using AmazonWareHouse.Business.Models.Order;
using AmazonWareHouse.Business.Models.Users;
using Data.Models.Models;
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

        void SetDeleted(string userId);

        void Insert(CreateUserModel model);

        Task UpdateAsync(EditUserModel model);

        List<UserModel> GetUserOrders(string userId);

        List<UserModel> GetAllUsersFromCity(string cityId);

        UserAuthModel GetUserByEmail(string email);

        bool DoesEmailExist(string email);

        User GetUserAndReturnUserModel(string userId);
    }
}
