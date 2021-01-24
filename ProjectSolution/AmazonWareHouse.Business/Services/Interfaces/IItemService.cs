using AmazonWareHouse.Business.Models.Categories;
using AmazonWareHouse.Business.Models.Items;
using Data.Connection;
using Data.Models.Models;
using Data.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWareHouse.Business.Services.Interfaces
{
    public interface IItemService
    {
        List<ItemModel> GetAll(Expression<Func<ItemModel, bool>> filter = null);

        ItemModel GetById(string id);

        Task InsertAsync(CreateItemModel model);

        Task RemoveAsync(string id);

        Task UpdateAsync(EditItemModel model);

        Task RemoveCategory(ItemModel item, string categoryId);

        Task UpdateQuantityAndSaveAsync(AmazonDbContext db, string itemId, UpdateQuantityMeasure way, int quantity = 1);

        void AddCategory(ItemModel item, CategoryModel category);

        ItemModel GetByIdWithCategory(string itemId);
    }
}
