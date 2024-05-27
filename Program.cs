using System.Text;
using FoodDeliveryAPI.DataLayer;
using FoodDeliveryAPI.DataLayer.Repos;
using FoodDeliveryAPI.DataLayer.ReposInterfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<FoodDeliveryDb>(opts => 
    opts.UseSqlServer(builder.Configuration.GetConnectionString("FoodDeliveryDb")));

builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<IRestaurantRepository,RestaurantRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IMenuItemRepository,MenuItemRepository>();
builder.Services.AddScoped<AuthHelper>();

builder.Services.AddCors((options) =>
    {
        options.AddPolicy("DevCors",(corsbuilder) =>
            {
                corsbuilder.WithOrigins("http://localhost:4200","http://localhost:3000", "http://localhost:8000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        options.AddPolicy("ProdCors",(corsbuilder) =>
            {
                corsbuilder.WithOrigins("https://myProductionSite.com")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
    }
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:TokenKey").Value
            )),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevCors");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
