using AmazonWareHouse.Business.Models.Categories;
using AmazonWareHouse.Business.Models.Items;
using AmazonWareHouse.Business.Services.Interfaces;
using AutoMapper;
using Data.Connection;
using Data.Models.Models;
using Data.Services.Classes;
using Data.Services.Common;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWareHouse.Business.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            this._itemRepository = itemRepository;
            this._mapper = mapper;
        }
        public void AddCategory(ItemModel item, CategoryModel category)
        {
            var itemEntity = this._mapper.Map<Item>(item);
            var categoryEntity = this._mapper.Map<Category>(category);

            this._itemRepository.AddCategoryAndSaveAsync(itemEntity, categoryEntity);
        }

        public List<ItemModel> GetAll(Expression<Func<ItemModel, bool>> filter = null)
        {
            var repoFilter = _mapper.Map<Expression<Func<Item, bool>>>(filter);

            var result = _itemRepository.GetAll(repoFilter);

            return _mapper.Map<List<ItemModel>>(result);
        }

        public ItemModel GetById(string id)
        {
            var result = _itemRepository.GetById(id);

            return _mapper.Map<ItemModel>(result);
        }

        public ItemModel GetByIdWithCategory(string itemId)
        {
            var result = _itemRepository.GetByIdWithCategory(itemId);

            return _mapper.Map<ItemModel>(result);
        }

        public async Task InsertAsync(CreateItemModel model)
        {
            var entity = _mapper.Map<Item>(model);

            await _itemRepository.InsertAndSaveAsync(entity);
        }

        public async Task RemoveAsync(string id)
        {
            await RemoveById(id);
        }

        public async Task RemoveById(string itemId)
        {
            await this._itemRepository.RemoveById(itemId);
        }

        public async Task RemoveCategory(ItemModel item, string categoryId)
        {
            var itemEntity = this._mapper.Map<Item>(item);

            await this._itemRepository.RemoveCategory(itemEntity, categoryId);
        }

        public async Task UpdateAsync(EditItemModel model)
        {
            var itemEntity = _mapper.Map<Item>(model);

            await _itemRepository.UpdateAndSaveAsync(itemEntity);
        }

        public async Task UpdateQuantityAndSaveAsync(AmazonDbContext db, string itemId, UpdateQuantityMeasure way, int quantity = 1)
        {
            //Ask if this is good practise?
            await ItemRepository.UpdateQuantityAndSaveAsync(db, itemId, way, quantity);
        }
    }
}
