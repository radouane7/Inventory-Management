using InventoryManagement.Application.Feature;
using InventoryManagement.Application.Feature.Category.AddCategory;
using InventoryManagement.Application.Feature.Category.AddCategory.Commands;
using InventoryManagement.Application.Feature.Category.AddCategory.Dto;
using InventoryManagement.Domain.Abstractions;
using InventoryManagement.Domain.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Tests
{
    public class AddCategoryCommandHandlerTests_Substitute
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AddCategoryCommandHandler _handler;

        public AddCategoryCommandHandlerTests_Substitute()
        {
            // Initialize Mapster configuration
             new MapsterConfig();
            // Arrange: Create mocks for the dependencies
            _categoryRepo = Substitute.For<ICategoryRepo>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _handler = new AddCategoryCommandHandler(_categoryRepo, _unitOfWork);

        }

        [Fact]
        public async Task Handle_ShouldAddCategoryAndCommit_WhenValidRequest()
        { 
            // Arrange
            var categoryDto = new CategoryDto(1, "Electronics");
            var command = new AddCategoryCommand { CategoryDto = categoryDto };
            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _categoryRepo.Received(1).AddCategory(Arg.Is<Category>(c => c.Id == 1 && c.CategoryName == "Electronics"));
            _unitOfWork.Received(1).commit();
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task Handle_ShouldNotCommit_WhenAddCategoryFails()
        {
            // Arrange
            var categoryDto = new CategoryDto(2, "Books");
            var command = new AddCategoryCommand { CategoryDto = categoryDto };

            // Simulate an exception being thrown when adding a category
            _categoryRepo.When(repo => repo.AddCategory(Arg.Any<Category>()))
                         .Do(call => { throw new System.Exception("Error adding category"); });

            // Act & Assert
            await Assert.ThrowsAsync<System.Exception>(() => _handler.Handle(command, CancellationToken.None));

            // Ensure commit was not called
            _unitOfWork.DidNotReceive().commit();
        }
    }
}
