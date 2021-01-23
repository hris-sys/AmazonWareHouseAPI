using AmazonWareHouse.Business.Models.Order;
using AmazonWareHouse.Business.Models.Users;
using AmazonWareHouse.Business.Services.Interfaces;
using AutoMapper;
using Data.Models.Models;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWareHouse.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public bool DoesEmailExist(string email)
        {
            var result = _userRepository.GetUserByEmail(email);

            return result != null;
        }

        public List<UserModel> GetAll(Expression<Func<UserModel, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetAllUsersFromCity(string city)
        {
            throw new NotImplementedException();
        }


        public UserModel GetById(string id)
        {
            var result = _userRepository.GetById(id);

            return _mapper.Map<UserModel>(result);
        }


        public UserAuthModel GetUserByEmail(string email)
        {
            var result = _userRepository.GetUserByEmail(email);

            return _mapper.Map<UserAuthModel>(result);
        }

        public List<OrderModel> GetUserOrders(string id)
        {
            var dbResults = this._userRepository.GetUserOrders(id);
            var resultList = new List<OrderModel>();

            foreach (var result in dbResults)
            {
                resultList.Add(_mapper.Map<OrderModel>(result));
            }

            return resultList;
        }

        public async Task InsertAsync(CreateUserModel model)
        {
            var entity = _mapper.Map<User>(model);

            //entity.Password = AuthService.HashPassword(entity.Password);

            await _userRepository.InsertAndSaveAsync(entity);
        }

        public async Task RemoveAsync(string id)
        {
            await _userRepository.RemoveAndSaveAsync(id);
        }

        public async Task UpdateAsync(EditUserModel model)
        {
            var entity = _mapper.Map<User>(model);

            //entity.Password = AuthService.HashPassword(entity.Password);

            await _userRepository.UpdateAndSaveAsync(entity);
        }
    }
}
