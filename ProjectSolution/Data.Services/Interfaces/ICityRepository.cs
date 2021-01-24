using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface ICityRepository : IBaseRepository<City>
    {
        Task RemoveById(string cityId);

        City FindByName(string cityName);
    }

}
