using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure;
using InventoryManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.MsSql;

namespace InventoryManagement.Tests.Integration.Docker
{
    public class CategoryDockerTests
    {
        [Fact]
        async void Testing()
        {
            var container = new MsSqlBuilder().
                WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                .Build();
            await container.StartAsync();
            var context = new InventoryDBContext(new DbContextOptionsBuilder<InventoryDBContext>()
                .UseSqlServer(container.GetConnectionString()).Options
                );
            await context.Database.EnsureCreatedAsync();

            //var cr = new CategoryRepo(context);
            //cr.AddCategory(new Domain.Entities.Category(1) { CategoryName = "aaa" });
            var jsonContent = new StringContent(
                                "{\"id\":0,\"categoryName\":\"strinaag\"}",
                                 Encoding.UTF8,
                               "application/json"
                            );
            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.PostAsync("https://localhost:7290/api/Category", jsonContent);
            //string result = await response.Content.ReadAsStringAsync();
            //Console.WriteLine("Response: " + result);
            ////  context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT  categories  ON");

            if (!context.categories.Any())
            {
                context.categories.Add(new Category() { CategoryName = "Electronics" });
                context.SaveChanges();
            }

            CategoryRepo cr = new CategoryRepo(context);
            cr.AddCategory(new Domain.Entities.Category() { CategoryName = "ee" });
            context.SaveChanges();
            //var res = cr.GetCategory(1);


        }
    }
}
