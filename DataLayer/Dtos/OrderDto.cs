using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.DataLayer.Dtos
{
    public class OrderDto
    {
            public int UserId { get; set; } 
    }

}
