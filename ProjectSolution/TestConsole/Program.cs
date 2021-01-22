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
            var city = db.Cities.FirstOrDefault(n => n.Name == "Sofia");
            var user = db.Users.FirstOrDefault(n => n.Name == "Ivan");

            await orderRepo.CreateOrder(user, city, "Please ship it fast!");
        }
    }
}
