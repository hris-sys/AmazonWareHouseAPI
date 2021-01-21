using Data.Connection;
using Data.Models.Models;
using Data.Services.Classes;
using System;
using System.Threading.Tasks;

namespace TestConsole
{
    public class Program
    {
        static async Task Main(string[] args) {

            var db = new AmazonDbContext();

            var itemCatService = new ItemCategoryService(db);

            var category = new Category()
            {
                Name = "Fruits",
            };


            var item = new Item()
            {
                Name = "Apple",
                CreatedAt = DateTime.UtcNow,
                Price = 1.5m,
            };

            

            await itemCatService.InsertAndSaveAsync(item, category);

            await db.SaveChangesAsync();
        }
    }
}
