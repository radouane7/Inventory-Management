using InventoryManagement.Application.Feature.Category.AddCategory.Commands;
using InventoryManagement.Application.Feature.Category.AddCategory.Dto;
using InventoryManagement.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.Common;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using Testcontainers.MsSql;

namespace InventoryManagement.Tests.Integration.Docker
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithPassword("Strong_password_123!")
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var descriptorType = typeof(DbContextOptions<InventoryDBContext>);

                var descriptor = services
                    .SingleOrDefault(s => s.ServiceType == descriptorType);

                if (descriptor is not null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<InventoryDBContext>(options =>
                    options.UseSqlServer(_dbContainer.GetConnectionString()));

                // Apply pending migrations
                using (var scope = services.BuildServiceProvider().CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<InventoryDBContext>();
                    dbContext.Database.Migrate(); // Apply migrations
                }
            });
        }

        public Task InitializeAsync()
        {
            return _dbContainer.StartAsync();
        }

        public new Task DisposeAsync()
        {
            return _dbContainer.StopAsync();
        }
    }

    public abstract class BaseIntegrationTest
        : IClassFixture<IntegrationTestWebAppFactory>,
          IDisposable
    {
        private readonly IServiceScope _scope;
        protected readonly ISender Sender;
        protected readonly InventoryDBContext DbContext;

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();

            Sender = _scope.ServiceProvider.GetRequiredService<ISender>();

            DbContext = _scope.ServiceProvider
                .GetRequiredService<InventoryDBContext>();
        }

        public void Dispose()
        {
            _scope?.Dispose();
            DbContext?.Dispose();
        }
    }
}