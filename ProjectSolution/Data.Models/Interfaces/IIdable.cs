using System.ComponentModel.DataAnnotations;

namespace Data.Models.Interfaces
{
    public interface IIdable
    {  
        [Required]
        public int Id { get; set; }
    }
}
