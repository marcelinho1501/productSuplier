using Api.AutoGlass.Domain.Models.Response;
using Api.AutoGlass.Domain.Types;
using MediatR;

namespace Api.AutoGlass.Domain.Models.Request
{
    public class ProductSearchModel : ProductKeyRequest, IRequest<ProductSearchResponseModel>
    {
        public string Description { get; set; }
        public StatusProduct Status { get; set; }
        public DateTime? DateManufacturing { get; set; }
        public DateTime? DateValidate { get; set; }
        public int? SupplierCode { get; set; }
        public string? SupplierDescription { get; set; }
        public string? Cnpj { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 100;
    }
}
