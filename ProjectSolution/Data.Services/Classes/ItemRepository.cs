using Data.Connection;
using Data.Models.Models;
using Data.Services.Common;
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

        public async Task AddCategoryAndSaveAsync(Item item, Category category)
        {
            var itemCategory = new ItemCategory()
            {
                Item = item,
                Category = category
            };

            this.Context.ItemsCategories.Add(itemCategory);
            await this.Context.SaveChangesAsync();
        }

        public async Task RemoveCategory(Item item, string categoryId)
        {
            if (this.Context.Items.FirstOrDefault(x => x.Id == item.Id) is null)
            {
                throw new NullReferenceException("Such item doesn't exist!");
            }
            else
            {
                var itemCater = item.ItemCategories.FirstOrDefault(c => c.CategoryId == categoryId);
                if (itemCater is null)
                {
                    throw new NullReferenceException("Such combination of item and category doesn't exist!");
                }
                else
                {
                    this.Context.ItemsCategories.Remove(itemCater);

                    await this.SaveChangesAsync();
                }
            }
        }

        public static async Task UpdateQuantityAndSaveAsync(AmazonDbContext db, string itemId, UpdateQuantityMeasure way, int quantity = 1)
        {
            Item itemToChangeQuantity = db.Items.FirstOrDefault(x => x.Id == itemId);

            if (itemToChangeQuantity is null)
            {
                throw new NullReferenceException("Such item doesn't exist!");
            }
            else
            {
                if (way == 0)
                {
                    itemToChangeQuantity.Quantity += quantity;
                }
                else
                {
                    itemToChangeQuantity.Quantity -= quantity;
                }

                await db.SaveChangesAsync();
            }
        }
    }
}
