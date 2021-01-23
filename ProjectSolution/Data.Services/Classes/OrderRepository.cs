using Data.Connection;
using Data.Models.Models;
using Data.Services.Interfaces;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.Models.Common;

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

        public async Task AddItemToOrderAsync(Order order, Item item, int quantity = 1)
        {

            var res = this.Context.OrdersItems.FirstOrDefault(x => x.OrderId == order.Id);

            if (!(res is null))
            {
                if (res.ItemId == item.Id)
                {
                    res.ItemQuantity += quantity;
                    order.TotalCost += item.Price * quantity;
                    await ItemRepository.UpdateQuantityAndSaveAsync(this.Context, item, Common.UpdateQuantityMeasure.Remove, quantity);
                    await this.Context.SaveChangesAsync();
                    return;
                }
                else
                {
                    var orderItem = new OrderItem()
                    {
                        Item = item,
                        Order = order,
                        ItemQuantity = quantity
                    };

                    order.TotalCost += item.Price * quantity;

                    await ItemRepository.UpdateQuantityAndSaveAsync(this.Context, item, Common.UpdateQuantityMeasure.Remove, quantity);

                    this.Context.OrdersItems.Add(orderItem);

                    await this.Context.SaveChangesAsync();
                }
            }
            else
            {
                var orderItem = new OrderItem()
                {
                    Item = item,
                    Order = order,
                    ItemQuantity = quantity
                };

                order.TotalCost += item.Price * quantity;

                await ItemRepository.UpdateQuantityAndSaveAsync(this.Context, item, Common.UpdateQuantityMeasure.Remove, quantity);

                this.Context.OrdersItems.Add(orderItem);

                await this.Context.SaveChangesAsync();
            }
        }

        public async Task RemoveItemFromOrderAsync(Order order, Item item, int quantity = 1)
        {
            var orderItemRes = this.Context.OrdersItems.FirstOrDefault(x => x.OrderId == order.Id);

            if (!(orderItemRes is null))
            {
                if (orderItemRes.ItemId == item.Id)
                {
                    orderItemRes.ItemQuantity -= quantity;
                    order.TotalCost -= item.Price * quantity;
                    await ItemRepository.UpdateQuantityAndSaveAsync(this.Context, item, Common.UpdateQuantityMeasure.Add, quantity);
                    await this.Context.SaveChangesAsync();
                    return;
                }
                else
                {
                    throw new ArgumentNullException("There is no such item in the order!");
                }
            }
            else
            {
                throw new ArgumentNullException("There is no such order!");
            }
        }

        public async Task FinalyzeOrder(Order order, User user)
        {
            var foundOrder = this.DbSet.FirstOrDefault(x => x.Id == order.Id);

            if (!(foundOrder is null))
            {
                if (foundOrder.UserId == user.Id)
                {
                    foundOrder.Status = Models.Common.OrderStatus.Received;
                    foundOrder.DeletedAt = DateTime.UtcNow;
                    foundOrder.IsDeleted = true;
                }
                else
                {
                    throw new NullReferenceException("This user doesn't have any orders!");
                }
            }
            else
            {
                throw new NullReferenceException("This order doesn't exist!");
            }

            await this.Context.SaveChangesAsync();
        }

        public async Task UpdateStatus(string orderId, OrderStatus orderStatus)
        {
            var foundOrder = this.DbSet.FirstOrDefault(x => x.Id == orderId);

            if (!(foundOrder is null))
            {
                foundOrder.Status = orderStatus;
            }
            else
            {
                throw new NullReferenceException("There is no such order!");
            }

            await this.Context.SaveChangesAsync();
        }
    }
}
