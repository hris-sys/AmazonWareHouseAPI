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
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "The name is required!")]
        public string Name { get; set; }
    }
}
