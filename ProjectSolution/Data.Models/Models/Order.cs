﻿using Data.Models.Common;
using Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.Models
{
    public class Order : BaseModel, IAuditInfo
    {
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
            this.CreatedAt = DateTime.UtcNow;

        }

        [Required]
        public OrderStatus Status { get; set; }

        [MaxLength(50)]
        public string Remarks { get; set; }

        public decimal TotalCost { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public City City { get; set; }
        public string CityId { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
