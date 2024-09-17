using Api.AutoGlass.Domain.Types;

namespace Api.AutoGlass.Domain.Models.Response
{
    public class DeleteProductResponseModel
    {
        public int Code { get; set; }
        public StatusProduct Status { get; set; }
    }
}
