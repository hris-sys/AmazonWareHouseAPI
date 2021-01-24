using Data.Models.Interfaces;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.Models
{
    public class BaseModel : IBaseModel
    {
        public BaseModel()
        {
            this.Id = Guid.NewGuid().ToString().Substring(0, 7);
        }

        public string Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "The name is required!")]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
