using Data.Models.Common;
using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task CreateOrder(User user, string cityId, string remarks = "No remarks");

        Task AddItemToOrderAsyncAndSaveAsync(Order order, Item item, int quantity = 1);

        Task RemoveItemFromOrderAsync(Order order, Item item, int quantity = 1);

        Task FinalyzeOrder(string orderId, string userId);

        Task UpdateStatus(string orderId, OrderStatus orderStatus);
    }
}
