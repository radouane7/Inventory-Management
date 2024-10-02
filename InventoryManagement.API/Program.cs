using FluentValidation;
using InventoryManagement.Application.Behaviour;
using InventoryManagement.Application.Feature;
using InventoryManagement.Application.Feature.Category.AddCategory;
using InventoryManagement.Application.Feature.Category.AddCategory.Commands;
using InventoryManagement.Application.Feature.Order;
using InventoryManagement.Application.Feature.Order.AddOrder;
using InventoryManagement.Application.Feature.Order.AddOrder.Commands;
using InventoryManagement.Application.Feature.Product.AddProduct.Commands;
using InventoryManagement.Domain.Abstractions;
using InventoryManagement.Infrastructure;
using InventoryManagement.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InventoryDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(AddCategoryCommandHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(AddProductCommandHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(AddOrderCommandHandler).Assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
}) ;
 
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssemblyContaining<AddCategoryCommandValidator>(); // register validators
builder.Services.AddValidatorsFromAssemblyContaining<AddOrderCommandValidator>(); // register validators


builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();
builder.Services.AddTransient<IProductRepo, ProductRepo>();
builder.Services.AddTransient<IOrderRepo,OrderRepo>();

builder.Services.AddTransient < IUnitOfWork, UnitOfWork>();

//new MapOrderDtoToOrder();
new MapsterConfig();

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

public partial class Program
{

}