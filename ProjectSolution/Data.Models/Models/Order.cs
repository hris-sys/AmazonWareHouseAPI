using Data.Models.Common;
using Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.Models
{
    public class Order : IIdable, IAuditInfo
    {
        public int Id { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [MaxLength(50)]
        public string Remarks { get; set; }

        public decimal? TotalCost { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
