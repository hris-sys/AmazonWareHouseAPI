using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Seeder
{
    public class ItemSeeder
    {
        private string[] _names;
        private decimal[] _prices;
        private int[] _quantity;
        public ItemSeeder()
        {
            this.Items = new List<Item>();

            this._prices =new decimal[] 
            {
                1.2m,
                5m,
                12m,
                1400m,
                7.50m,
                4.5m,
                20m,
                210m,
                8m,
                50m,
                25m,
                2m,
                3m,
                2m,
                25m,
                500m,
                9.50m,
                14.5m,
                5.5m
            };

            this._names = new string[]
            {
                "Apple",
                "Baseball bat",
                "Cap",
                "iPhone 11",
                "Desktop lamp",
                "Coffee Mug",
                "Curtains",
                "Laptop Asus",
                "Microphone",
                "Bedside table",
                "JoJo Poster",
                "Fork",
                "Knife",
                "Spoon",
                "Mouse",
                "Monitor",
                "Plant",
                "1994 by George Orwell",
                "Metamorphosis of Prime Intellect by Roger Williams"
            };

            this._quantity = new int[]
            {
                20,
                3,
                7,
                10,
                3,
                2,
                2,
                8,
                3,
                5,
                10,
                5,
                20,
                5,
                9,
                25,
                40,
                20,
                10
            };

            FillNames();
            ;
        }
        public List<Item> Items { get; set; }

        private void FillNames()
        {
            for (int i = 0; i < this._names.Length; i++)
            {
                this.Items.Add(new Item()
                {
                    Name = _names[i],
                    Price = _prices[i],
                    Quantity = _quantity[i],
                    CreatedAt = DateTime.UtcNow
                });
            }
        }
    }
}
