using Data.Connection;
using Data.Models.Models;
using Data.Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Seeder
{
    public class Program
    {
        public static async Task Main()
        {
            //var db = new AmazonDbContext();
            var items = new ItemSeeder().Items;

            
        }

        public static async Task FillItems(AmazonDbContext db)
        {
            var itemRepo = new ItemRepository(db);

            var items = new ItemSeeder().Items;

            foreach (var item in items)
            {
                await itemRepo.InsertAndSaveAsync(item);
            }
        }

        public static async Task FillCategories(AmazonDbContext db)
        {
            var categoryRepo = new CategoryRepository(db);

            var categories = new CategorySeeder().Categories;

            foreach (var category in categories)
            {
                categoryRepo.Insert(category);
            }

            await categoryRepo.SaveChangesAsync();
        }

        public static async Task FillCities(AmazonDbContext db, List<City> cities)
        {
            var cityRepo = new CityRepository(db);

            foreach (var city in cities)
            {
                cityRepo.Insert(city);
            }

            await cityRepo.SaveChangesAsync();
        }

        public static async Task FillUsers(AmazonDbContext db, List<City> cities)
        {
            var userRepo = new UserRepository(db);

            var users = new UserSeeder(cities).Users;

            foreach (var user in users)
            {
                userRepo.Insert(user);
            }

            await userRepo.SaveChangesAsync();
        }

        public static async Task FillItemCategories(AmazonDbContext db, List<Item> items)
        {
            var itemRepo = new ItemRepository(db);
            var categories = new CategorySeeder().Categories;
            var random = new Random();

            for (int i = 0; i < items.Count; i++)
            {
                await itemRepo.AddCategoryAndSaveAsync(items[i], categories[random.Next(categories.Count)]);
            }

            for (int i = 0; i < items.Count; i += 2)
            {
                await itemRepo.AddCategoryAndSaveAsync(items[i], categories[random.Next(categories.Count)]);
            }

            await itemRepo.SaveChangesAsync();
        }
    }
}
