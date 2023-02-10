using Microsoft.EntityFrameworkCore;
using RobotsManagement.Data.Context;
using RobotsManagement.Data.Contracts;
using RobotsManagement.Data.Repositories;
using RobotsManagement.Service.Interfaces;
using RobotsManagement.Service.Services;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using RobotsManagement.Service.Models.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
var connectionString = configuration.GetConnectionString("DevConnection");
var corsOriginsValue = configuration["CorsOrigins"];
var corsOrigins = corsOriginsValue.Split(",");
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(corsOrigins).AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddDbContext<RobotsManagementDbContext>(option=>
option.UseSqlServer(connectionString));

// repositories
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IRobotRepository, RobotRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRobotTypeRepository, RobotTypeRepository>();

// services
builder.Services.AddTransient<IRobotService, RobotService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAuthService, AuthService>();

// libraries
var dataProtectionProvider = DataProtectionProvider.Create("RobotsManagement");
var protector = dataProtectionProvider.CreateProtector("RobotsManagement");
builder.Services.AddSingleton(protector);
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile(protector));
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();
