using Data.Connection;
using Data.Models.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Classes
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(AmazonDbContext context) : base(context)
        {

        }

        public void AddCategory(Item item, Category category)
        {
            var itemCategory = new ItemCategory()
            {
                Item = item,
                Category = category
            };

            this.Context.ItemsCategories.Add(itemCategory);

            item.ItemCategories.Add(itemCategory);
            //category.ItemCategories.Add(itemCategory);
        }

        public async Task RemoveCategory(Item item, Category category)
        {
            var itemCater = item.ItemCategories.FirstOrDefault(c => c.CategoryId == category.Id);

            this.Context.ItemsCategories.Remove(itemCater);

            await this.SaveChangesAsync();
        }

        public static async Task UpdateQuantity(AmazonDbContext db, Item item, int quantity = 1)
        {
            Item itemToChangeQuantity = db.Items.FirstOrDefault(x => x.Id == item.Id);

            ;
            itemToChangeQuantity.Quantity -= quantity;

            await db.SaveChangesAsync();
        }
    }
}
