using Api.AutoGlass.Domain.Models.Response;
using MediatR;

namespace Api.AutoGlass.Domain.Command
{
    public class DeleteProductCommand : IRequest<DeleteProductResponseModel>
    {
        public int Code { get; set; }
    }
}
