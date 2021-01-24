using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonWareHouse.Business.Models.Items
{
    public class EditItemModel : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        //UTC now in ctor
        public DateTime? ModifiedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
