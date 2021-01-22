using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.Interfaces
{
    public interface IIdable
    {  
        [Required]
        public string Id { get; set; }
    }
}
