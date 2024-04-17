using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FoodDeliveryAPI.DataLayer.Entities
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }
        [NotNull]
        public string DeliveryAddress { get; set; } = "";
        public string? DeliveryInstructions { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public DeliveryStatus Status { get; set; }
        public ICollection<Order>? Orders {get;set;}
    }

    public enum DeliveryStatus
    {
        Pending,
        InProgress,
        Completed,
        Cancelled,
        OutForDelivery,
        Failed
    }
}