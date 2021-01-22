using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Seeder
{
    public class CategorySeeder
    {
        private string[] _names;
        public CategorySeeder()
        {
            this.Categories = new List<Category>();
            this._names = new string[]
            {
                "Home",
                "Garden",
                "Lamps",
                "Tech",
                "Kitchen",
                "Toys",
                "Smartphones",
                "Laptops",
                "Clothes",
                "Plants",
                "Storage",
                "Furniture",
                "Sports",
                "Outdoors",
                "Books",
                "Fruits",
                "Vegetables"
            };

            FillNames();
        }

        public List<Category> Categories { get; set; }
        private void FillNames()
        {
            for (int i = 0; i < this._names.Length; i++)
            {
                this.Categories.Add(new Category()
                {
                    Name = _names[i]
                });
            }
        }
    }
}
