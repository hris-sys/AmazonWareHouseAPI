using Data.Models.Models;
using System.Collections.Generic;

namespace Data.Seeder
{
    public class CitySeeder
    {
        private string[] _names;
        private string[] _postalCodes;

        public CitySeeder()
        {
            this.Cities = new List<City>();
            this._names = new string[]
            {
                "Sofia",
                "Varna",
                "Burgas",
                "Veliko Tarnovo",
                "New York",
                "London",
                "Svishtov",
                "Tokyo"
            };

            this._postalCodes = new string[]
            {
                "1000",
                "9000",
                "8000",
                "5000",
                "10000",
                "N0L 1E0",
                "5250",
                "10000"
            };

            FillList();
        }

        public List<City> Cities { get; set; }

        private void FillList()
        {
            for (int i = 0; i < _names.Length; i++)
            {
                var currCity = _names[i];
                var currPostCode = _postalCodes[i];

                this.Cities.Add(new City()
                {
                    Name = currCity,
                    PostalCode = currPostCode,
                });
            }
        }
    }
}
