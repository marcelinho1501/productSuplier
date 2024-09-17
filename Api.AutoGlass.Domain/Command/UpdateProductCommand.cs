﻿using Api.AutoGlass.Domain.Models.Response;
using Api.AutoGlass.Domain.Types;
using MediatR;

namespace Api.AutoGlass.Domain.Command
{
    public class UpdateProductCommand : IRequest<ProductResponseModel>
    {
        public int Code { get; set; }
        public string? Description { get; set; }
        public StatusProduct Status { get; set; }
        public DateTime? DateManufacturing { get; set; }
        public DateTime? DateValidate { get; set; }
        public int? SupplierCode { get; set; }
        public string? SupplierDescription { get; set; }
        public string? Cnpj { get; set; }
    }
}