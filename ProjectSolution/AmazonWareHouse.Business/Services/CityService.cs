using AmazonWareHouse.Business.Models.Cities;
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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            this._cityRepository = cityRepository;
            this._mapper = mapper;
        }

        public async Task CreateAsync(CreateCityModel model)
        {
            var entity = _mapper.Map<City>(model);

            await this._cityRepository.InsertAndSaveAsync(entity);
        }

        public List<CityModel> GetAll(Expression<Func<CityModel, bool>> filter = null)
        {
            var repoFilter = _mapper.Map<Expression<Func<City, bool>>>(filter);

            var result = _cityRepository.GetAll(repoFilter);

            return _mapper.Map<List<CityModel>>(result);
        }

        public CityModel GetById(string id)
        {
            var result = _cityRepository.GetById(id);

            return _mapper.Map<CityModel>(result);
        }

        public City GetByIdAndReturnCityObject(string cityId)
        {
            var result = this._cityRepository.GetById(cityId);

            if (result is null)
            {
                throw new NullReferenceException("No such city!");
            }

            return result;
        }

        public void RemoveById(string cityId)
        {
            _cityRepository.RemoveById(cityId);
        }

        public async Task UpdateAsync(EditCityModel model)
        {
            var orderEntity = _mapper.Map<City>(model);

            await _cityRepository.UpdateAndSaveAsync(orderEntity);
        }
    }
}
