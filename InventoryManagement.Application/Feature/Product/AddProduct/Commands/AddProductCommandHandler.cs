using InventoryManagement.Domain.Abstractions;
using InventoryManagement.Domain.ValuesObjects;
using Mapster;
using MediatR;

namespace InventoryManagement.Application.Feature.Product.AddProduct.Commands
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        readonly IProductRepo _ProductRepo;
        readonly IUnitOfWork _UnitOfWork;

        public AddProductCommandHandler(IProductRepo productRepo, IUnitOfWork unitOfWork)
        {
            _ProductRepo = productRepo;
            _UnitOfWork = unitOfWork;
        }

        public Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
           

            InventoryManagement.Domain.Entities.Product product = 
                request.ProductDto.Adapt<InventoryManagement.Domain.Entities.Product>();
         
            _ProductRepo.AddProduct(product);
            _UnitOfWork.commit();
            return Task.FromResult(0);

        }
    }
}
