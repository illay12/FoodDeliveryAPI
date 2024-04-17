using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.DataLayer.Entities
{
    public class Restaurant 
    { 
        public int RestaurantId { get; set; }
        [NotNull,MaxLength(40)]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        [Required]
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string OpeningHours { get; set; } = "";
        [Precision(18, 2)]
        public decimal DeliveryFee {get;set;}
        public ICollection<MenuItem>? MenuItems { get; set; } 
        }
}