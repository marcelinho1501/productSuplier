using Api.AutoGlass.Domain.Command;
using Api.AutoGlass.Domain.Entities;
using Api.AutoGlass.Domain.Interfaces;
using Api.AutoGlass.Domain.Models.Response;
using MediatR;

namespace Api.AutoGlass.Domain.Queries
{
    public class ProductCommandHandler : IRequestHandler<InsertProductCommand, BaseProductResponseModel>,
                                         IRequestHandler<UpdateProductCommand, ProductResponseModel>,
                                         IRequestHandler<DeleteProductCommand, DeleteProductResponseModel>
    {
        private readonly IMainUnitOfWork _mainUnitOfWork;
        public ProductCommandHandler(IMediator mediator, IMainUnitOfWork mainUnitOfWork)
        {
            _mainUnitOfWork = mainUnitOfWork;
        }
        public async Task<BaseProductResponseModel> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.New(request);

            await _mainUnitOfWork.ProductRepository.AddAsync(product);
            await _mainUnitOfWork.CommitAsync();

            return new BaseProductResponseModel
            {
                Code = product.Code
            };
        }

        public async Task<ProductResponseModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _mainUnitOfWork.ProductRepository.GetById(request.Code);
            if (product is null)
                throw new Exception($"Produto não encontrado!");

            product.Update(request);
            _mainUnitOfWork.ProductRepository.Update(product);

            await _mainUnitOfWork.CommitAsync();
            return new ProductResponseModel
            {
                Code = product.Code,
                Description = product.Description,
                DateManufacturing = product.DateManufacturing,
                DateValidate = product.DateValidate,
                Status = product.Status,
                SupplierCode = product.SupplierCode,
                SupplierDescription = product.SupplierDescription,
                Cnpj = product.Cnpj,
            };
        }

        public async Task<DeleteProductResponseModel> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _mainUnitOfWork.ProductRepository.GetById(request.Code);

            if (product is null)
                throw new Exception($"Produto não encontrado!");

            product.SetInactive();

            _mainUnitOfWork.ProductRepository.Update(product);
            await _mainUnitOfWork.CommitAsync();
            return new DeleteProductResponseModel
            {
                Code = product.Code,
                Status = product.Status
            };
        }
    }
}
