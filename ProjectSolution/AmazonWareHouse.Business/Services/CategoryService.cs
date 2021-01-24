using AmazonWareHouse.Business.Models.Categories;
using AmazonWareHouse.Business.Services.Interfaces;
using AutoMapper;
using Data.Models.Models;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWareHouse.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }
        public async Task CreateAsync(CreateCategoryModel model)
        {
            var entity = _mapper.Map<Category>(model);

            await _categoryRepository.InsertAndSaveAsync(entity);
        }

        public List<CategoryModel> GetAll(Expression<Func<CategoryModel, bool>> filter = null)
        {
            var repoFilter = _mapper.Map<Expression<Func<Category, bool>>>(filter);

            var result = _categoryRepository.GetAll(repoFilter);

            return _mapper.Map<List<CategoryModel>>(result);
        }

        public CategoryModel GetById(string id)
        {
            var result = _categoryRepository.GetById(id);

            return _mapper.Map<CategoryModel>(result);
        }

        public async Task RemoveAsync(string id)
        {
            //Ask what will happen when deleted
            await _categoryRepository.RemoveAndSaveAsync(id);
        }

        public async Task UpdateAsync(EditCategoryModel model)
        {
            var entity = _mapper.Map<Category>(model);

            await _categoryRepository.UpdateAndSaveAsync(entity);
        }
    }
}
