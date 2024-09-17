using Api.AutoGlass.Domain.Entities;
using Api.AutoGlass.Domain.Interfaces;
using Api.AutoGlass.Domain.Models;
using Api.AutoGlass.Domain.Models.Request;
using Api.AutoGlass.Domain.Models.Response;
using MediatR;

namespace Api.AutoGlass.Domain.QueryHandler
{
    public class ProductQueryHandler : IRequestHandler<ProductKeyRequest, ProductSearchResponseModel>,
                                       IRequestHandler<ProductSearchModel, ProductSearchResponseModel>
    {
        private readonly IMainUnitOfWork _mainUnitOfWork;
        public ProductQueryHandler(IMediator mediator, IMainUnitOfWork mainUnitOfWork)
        {
            _mainUnitOfWork = mainUnitOfWork;
        }
        public async Task<ProductSearchResponseModel> Handle(ProductKeyRequest request, CancellationToken cancellationToken)
        {
            ProductSearchResponseModel result = new ProductSearchResponseModel();
            var product = await _mainUnitOfWork.ProductRepository.GetById(request.Code);

            if (product != null)
            {
                result.Items = new List<ProductResultModel>
                {
                    new ProductResultModel
                    {
                        Code = product.Code,
                        Description = product.Description,
                        DateManufacturing = product.DateManufacturing,
                        DateValidate = product.DateValidate,
                        Status = product.Status,
                        SupplierCode = product.SupplierCode,
                        SupplierDescription = product.SupplierDescription,
                        Cnpj = product.Cnpj
                    }
                };
                result.TotalItems = 1;
                result.Count = 1;
                result.TotalPages = 1;
                result.HasNext = false;
            }
            return result;
        }

        public async Task<ProductSearchResponseModel> Handle(ProductSearchModel request, CancellationToken cancellationToken)
        {
            var productQuery = _mainUnitOfWork.ProductRepository.Query();
            productQuery = ApplyFilters(productQuery, request);

            var result = productQuery.Select(t => new ProductResultModel
            {
                Code = t.Code,
                Description = t.Description,
                Status = t.Status,
                DateManufacturing = t.DateManufacturing,
                DateValidate = t.DateValidate,
                SupplierCode = t.SupplierCode,
                SupplierDescription = t.SupplierDescription,
                Cnpj = t.Cnpj
            }).ToList();

            var response = new ProductSearchResponseModel
            {
                Items = result
            };

            if (!response.TryPage(request.PageSize, request.Page))
                throw new Exception($"Pagina não encontrado!");

            return response;
        }

        private IQueryable<Product> ApplyFilters(IQueryable<Product> query, ProductSearchModel request)
        {
            if (request.Code != null)
                query = query.Where(t => t.Code == request.Code);

            if (!string.IsNullOrEmpty(request.Description))
                query = query.Where(t => t.Description.Contains(request.Description));

            if (request.Status != null)
                query = query.Where(t => t.Status == request.Status);

            if (request.DateManufacturing.HasValue)
                query = query.Where(t => t.DateManufacturing == request.DateManufacturing.Value);

            if (request.DateValidate.HasValue)
                query = query.Where(t => t.DateValidate == request.DateValidate.Value);

            if (request.SupplierCode != null)
                query = query.Where(t => t.SupplierCode == request.SupplierCode);

            if (!string.IsNullOrEmpty(request.SupplierDescription))
                query = query.Where(t => t.SupplierDescription.Contains(request.SupplierDescription));

            if (!string.IsNullOrEmpty(request.Cnpj))
                query = query.Where(t => t.Cnpj.Contains(request.Cnpj));

            return query;
        }
    }
}
