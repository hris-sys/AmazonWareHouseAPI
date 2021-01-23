using Data.Connection;
using Data.Models.Models;
using Data.Services.Classes;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestConsole
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            var db = new AmazonDbContext();
            //var itemRepo = new ItemRepository(db);
            //var list = db.Items.Include(x => x.ItemCategories).ToList();
            

            var orderRepo = new OrderRepository(db);

            string orderId = "267824c";

            await orderRepo.UpdateStatus(orderId, Data.Models.Common.OrderStatus.Confirmed);
        }
    }
}
