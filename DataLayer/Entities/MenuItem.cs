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
    public class MenuItem
    {
    [Key]
    public int Id { get; set; }
    [ForeignKey("Restaurant")]
    public int RestaurantId { get; set; } 
    [Required]
    public string Name { get; set; } = "";
    [NotNull]
    public string Description { get; set; } = "";
    [Precision(18, 2)]
    public decimal Price { get; set; }
    [NotNull]
    public string Category { get; set; } = "";
    public Restaurant? Restaurant {get;set;}
    }
}