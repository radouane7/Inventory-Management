using InventoryManagement.Application.Feature.Category.AddCategory.Commands;
using InventoryManagement.Application.Feature.Category.AddCategory.Dto;
using InventoryManagement.Application.Feature.Category.GetCategory.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Tests.Integration.Docker
{
    public class CategoryTests : BaseIntegrationTest
    {
        public CategoryTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Testing()
        {

            // Arrange

            AddCategoryCommand command = new AddCategoryCommand { CategoryDto = new CategoryDto(0, "IT") };

            GetCategoryQuery query = new GetCategoryQuery(1); 

            // Act
            var productId = await Sender.Send(command);


            //// Assert
            ///
            var res = await Sender.Send(query);
            Assert.Equal("IT", res.CategoryName);

        }
    }
}
