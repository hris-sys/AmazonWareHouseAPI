using AmazonWareHouse.Business.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWareHouse.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryModel> GetAll(Expression<Func<CategoryModel, bool>> filter = null);

        CategoryModel GetById(string id);

        Task CreateAsync(CreateCategoryModel model);

        Task RemoveAsync(string id);

        Task UpdateAsync(EditCategoryModel model);
    }
}
