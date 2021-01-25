using AmazonWareHouse.Business.Models.Cities;
using AmazonWareHouse.Business.Models.Items;
using AmazonWareHouse.Business.Models.Order;
using AmazonWareHouse.Business.Models.Users;
using Data.Models.Common;
using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWareHouse.Business.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderModel> GetAll(Expression<Func<OrderModel, bool>> filter = null);

        OrderModel GetById(string id);

        Task CreateAsync(User user, string cityId, string remarks = "No remarks");

        Task RemoveAsync(string orderId, string userId);

        Task UpdateAsync(EditOrderModel model);

        Task UpdateStatus(string orderId, OrderStatus orderStatus);

        Task FinalyzeOrder(string orderId, string userId);

        Task RemoveItemFromOrderAsync(OrderModel order, ItemModel item, int quantity = 1);

        Task AddItemToOrderAsyncAndSaveAsync(OrderModel order, ItemModel item, int quantity = 1);

    }
}
