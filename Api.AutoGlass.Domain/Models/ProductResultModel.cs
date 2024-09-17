using Api.AutoGlass.Domain.Types;

namespace Api.AutoGlass.Domain.Models
{
    public class ProductResultModel
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public StatusProduct Status { get; set; }
        public DateTime? DateManufacturing { get; set; }
        public DateTime? DateValidate { get; set; }
        public int? SupplierCode { get; set; }
        public string? SupplierDescription { get; set; }
        public string? Cnpj { get; set; }
    }
}
