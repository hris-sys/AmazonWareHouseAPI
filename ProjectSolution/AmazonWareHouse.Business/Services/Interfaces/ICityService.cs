using AmazonWareHouse.Business.Models.Cities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWareHouse.Business.Services.Interfaces
{
    public interface ICityService
    {
        List<CityModel> GetAll(Expression<Func<CityModel, bool>> filter = null);

        CityModel GetById(string id);

        Task CreateAsync(CreateCityModel model);

        void RemoveById(string cityId);

        Task UpdateAsync(EditCityModel model);
    }
}
