using Api.AutoGlass.Domain.Command;
using Api.AutoGlass.Domain.Types;
using Mapster;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.AutoGlass.Domain.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cd_produto")]
        public int Code { get; set; }

        [Column("ds_produto")]
        public string Description { get; set; }

        [Column("tp_situacao")]
        public StatusProduct Status { get; set; }

        [Column("dt_fabricacao")]
        public DateTime? DateManufacturing { get; set; }

        [Column("dt_validade")]
        public DateTime? DateValidate { get; set; }

        [Column("cd_fornecedor")]
        public int? SupplierCode { get; set; }

        [Column("ds_fornecedor")]
        public string? SupplierDescription { get; set; }

        [Column("ds_cnpj")]
        public string? Cnpj { get; set; }

        public static Product New(InsertProductCommand request)
        {
            var product = new Product();
            request.Adapt(product);

            return product;
        }

        public void Update(UpdateProductCommand request)
        {
            if (!string.IsNullOrEmpty(request.Description))
                Description = request.Description;

            if (request.Status != null)
                Status = request.Status;

            if (request.Description != null)
                Description = request.Description;

            if (request.DateManufacturing != null)
                DateManufacturing = request.DateManufacturing;

            if (request.DateValidate != null)
                DateValidate = request.DateValidate;

            if (request.SupplierCode != null)
                SupplierCode = request.SupplierCode;

            if (!string.IsNullOrEmpty(request.SupplierDescription))
                SupplierDescription = request.SupplierDescription;

            if (request.Cnpj != null)
                Cnpj = request.Cnpj;
        }

        public void SetInactive()
        {
            Status = (StatusProduct)1; //Situação inativo
        }
    }
}
