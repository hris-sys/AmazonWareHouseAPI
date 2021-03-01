using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonWareHouse.Business.Models.Categories
{
    public class EditCategoryModel : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
