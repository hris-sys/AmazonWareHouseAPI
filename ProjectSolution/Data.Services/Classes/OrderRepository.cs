using Data.Connection;
using Data.Models.Models;
using Data.Services.Interfaces;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Classes
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AmazonDbContext context) : base(context)
        {

        }

        public async Task CreateOrder(User user, City city, string remarks = "No remarks")
        {
            var order = new Order()
            {
                Name = user.Name + "'s order",
                User = user,
                CityId = city.Id,
                Remarks = remarks,
                Status = Models.Common.OrderStatus.AwaitingApproval
            };

            await this.InsertAndSaveAsync(order);
        }

        public async Task AddItemToOrder(Order order, Item item, int quantity = 1)
        {
            //ToDo: Add When another same item is added on the same order to just update the quantity

            var orderItem = new OrderItem()
            {
                Item = item,
                Order = order,
                ItemQuantity = quantity
            };

            order.TotalCost += item.Price * quantity;

            await ItemRepository.UpdateQuantity(this.Context, item, quantity);

            this.Context.OrdersItems.Add(orderItem);

            await this.Context.SaveChangesAsync();
        }

    }
}
