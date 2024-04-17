using FoodDeliveryAPI.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;


namespace FoodDeliveryAPI.DataLayer
{
    public class FoodDeliveryDb : DbContext
    {
        public DbSet<User> Users {get;set;}
        public DbSet<Order> Orders {get;set;}
        public DbSet<MenuItem> MenuItems {get;set;}
        public DbSet<OrderItem> OrderItems {get;set;}
        public DbSet<Restaurant> Restaurants {get;set;}
        public DbSet<Delivery> Deliveries {get;set;}


    public FoodDeliveryDb(DbContextOptions<FoodDeliveryDb> options)
            : base(options)
        {
        }

    }
}