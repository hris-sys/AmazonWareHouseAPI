using Data.Connection;
using Data.Models.Models;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Classes
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(AmazonDbContext context) : base (context)
        {

        }
    }
}
