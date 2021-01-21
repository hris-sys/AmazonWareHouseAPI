using Data.Connection;
using Data.Models.Models;
using System;

namespace TestConsole
{
    public class Program
    {
        static void Main(string[] args) {

            var db = new AmazonDbContext();

            db.Add(new Item()
            {
                Name = "Apple",
                Price = 1.5m,
                CreatedAt = DateTime.UtcNow
            });

            db.SaveChangesAsync();
        }
    }
}
