using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.DataLayer.Entities
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; } 
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        [Precision(18, 2)]
        public decimal PriceAtOrder{ get; set; }
        public Order? Order { get; set; }
        public MenuItem? MenuItem { get; set; }
    }
}