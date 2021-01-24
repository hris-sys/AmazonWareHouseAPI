using Data.Connection;
using Data.Models.Models;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Classes
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(AmazonDbContext context) : base (context)
        {

        }

        public City FindByName(string cityName)
        {
            var entity = this.DbSet.FirstOrDefault(x => x.Name.ToLower() == cityName.ToLower());

            if (entity is null)
            {
                throw new NullReferenceException("There is no such city!");
            }

            return entity;
        }

        public async Task RemoveById(string cityId)
        {
            var entity = this.DbSet.FirstOrDefault(x => x.Id == cityId);

            if (entity is null)
            {
                throw new NullReferenceException("There is no such city!");
            }

            entity.IsDeleted = true;

            await this.Context.SaveChangesAsync();
        }
    }
}
