using System.ComponentModel.DataAnnotations;

namespace Data.Models.Interfaces
{
    public interface IBaseModel : IIdable
    {
        [Required]
        public string Name { get; set; }
    }
}
