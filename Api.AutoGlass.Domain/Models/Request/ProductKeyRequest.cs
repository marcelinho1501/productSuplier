using Api.AutoGlass.Domain.Models.Response;
using MediatR;

namespace Api.AutoGlass.Domain.Models.Request
{
    public class ProductKeyRequest : IRequest<ProductSearchResponseModel>
    {
        public int? Code { get; set; }
    }
}
