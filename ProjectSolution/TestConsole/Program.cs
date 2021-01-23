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

            //Should find by Id instead
            var order = db.Orders.Include(x => x.User).FirstOrDefault(u => u.User.Name == "Ivan");
            var item = db.Items.FirstOrDefault(u => u.Name == "Plant");

            await orderRepo.AddItemToOrderAsync(order, item, 2);
        }
    }
}
