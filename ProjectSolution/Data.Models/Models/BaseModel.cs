using Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.Models
{
    public class BaseModel : IBaseModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "The name is required!")]
        public string Name { get; set; }
    }
}
