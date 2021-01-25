using Data.Connection;
using Data.Models.Models;
using Data.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        public Task AddCategoryAndSaveAsync(Item item, Category category);

        public Task RemoveCategory(Item item, string categoryId);

        public Item GetByIdWithCategory(string itemId);
        Task RemoveById(string itemId);

    }
}
