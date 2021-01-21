using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.Interfaces
{
    public interface IIdable
    {  
        [Required]
        public Guid Id { get; set; }
    }
}
