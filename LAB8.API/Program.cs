using LAB8.DATA.Models;
using LAB8.DATA.Repositories.IRepositories;
using LAB8.DATA.Repositories.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppAPIDbContext>(options =>
{

});
builder.Services.AddScoped<IRepositoriesAppAPI<People>,PeopleRepositories>();
builder.Services.AddScoped<IRepositoriesAppAPI<Car>,CarRepositories>();
builder.Services.AddScoped<IRepositoriesAppAPI<Laptop>,LaptopRepositories>();
builder.Services.AddScoped<IRepositoriesJoinTable<Laptop_People>,Laptop_People_Repositories>();
builder.Services.AddScoped<IRepositoriesJoinTable<Car_People>,Car_People_Repositories>();
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

app.Run();
