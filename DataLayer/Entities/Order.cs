using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.DataLayer.Entities
{
    public class Order
    {
        [Key]
        public int OrderId {get;set;}
        [ForeignKey("User")]
        public int UserId { get; set; }
        [NotNull]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Precision(18, 2)]
        public decimal TotalAmount { get; set; } = 0;
        [NotNull]
        public User User {get;set;}
        [NotNull]
        public ICollection<OrderItem>? OrderItems { get; set; }
        public Delivery? Delivery {get;set;}
        

    }


}