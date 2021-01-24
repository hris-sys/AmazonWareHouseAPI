using AmazonWareHouse.Business.Models.Cities;
using AmazonWareHouse.Business.Models.Items;
using AmazonWareHouse.Business.Models.Order;
using AmazonWareHouse.Business.Models.Users;
using AmazonWareHouse.Business.Services.Interfaces;
using AutoMapper;
using Data.Models.Common;
using Data.Models.Models;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWareHouse.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            this._orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task AddItemToOrderAsyncAndSaveAsync(OrderModel order, ItemModel item, int quantity = 1)
        {
            var orderEntity = this._mapper.Map<Order>(order);
            var itemEntity = this._mapper.Map<Item>(item);

            await this._orderRepository.AddItemToOrderAsyncAndSaveAsync(orderEntity, itemEntity);
        }

        public async Task CreateAsync(UserModel user, string cityId, string remarks = "No remarks")
        {
            var userEntity = this._mapper.Map<User>(user);

            await this._orderRepository.CreateOrder(userEntity, cityId, remarks);
        }

        public async Task FinalyzeOrder(string orderId, string userId)
        {
            await this._orderRepository.FinalyzeOrder(orderId, userId);
        }

        public List<OrderModel> GetAll(Expression<Func<OrderModel, bool>> filter = null)
        {
            var repoFilter = _mapper.Map<Expression<Func<Order, bool>>>(filter);

            var result = _orderRepository.GetAll(repoFilter);

            return _mapper.Map<List<OrderModel>>(result);
        }

        public OrderModel GetById(string id)
        {
            var orderResult = _orderRepository.GetById(id);

            return _mapper.Map<OrderModel>(orderResult);
        }

        public async Task RemoveAsync(string orderId, string userId)
        {
            await this.FinalyzeOrder(orderId, userId);
        }

        public async Task RemoveItemFromOrderAsync(OrderModel order, ItemModel item, int quantity = 1)
        {
            var orderEntity = this._mapper.Map<Order>(order);
            var itemEntity = this._mapper.Map<Item>(item);

            await this._orderRepository.RemoveItemFromOrderAsync(orderEntity, itemEntity, quantity);
        }

        public async Task UpdateAsync(EditOrderModel model)
        {
            var orderEntity = _mapper.Map<Order>(model);

            await _orderRepository.UpdateAndSaveAsync(orderEntity);
        }

        public async Task UpdateStatus(string orderId, OrderStatus orderStatus)
        {
            await this._orderRepository.UpdateStatus(orderId, orderStatus);
        }
    }
}
