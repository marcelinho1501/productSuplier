using Api.AutoGlass.Domain.Models.Request;
using Api.AutoGlass.Domain.Validators;

namespace Api.AutoGlass.Tests.DtosTests
{
    public class ProductSearchDtoTest
    {
        private readonly ProductSearchValidator _validator;
        public ProductSearchDtoTest()
        {
            _validator = new ProductSearchValidator();
        }
        private readonly ProductSearchModel _productSearchModel = new ProductSearchModel
        {
            Code = 1,
            Description = "Teste",
            Status = 0,
            DateManufacturing = DateTime.Now,
            DateValidate = DateTime.Now.AddDays(+1),
            SupplierCode = 1,
            SupplierDescription = "Fornecedor",
            Cnpj = "123456789",
            Page = 1,
            PageSize = 100
        };

        [Theory]
        [InlineData(0)]
        [InlineData(101)]
        public void OrderSearch_PageSizeInvalid(int pageSize)
        {
            _productSearchModel.PageSize = pageSize;
            var result = _validator.Validate(_productSearchModel);
            Assert.False(result.IsValid);
        }

    }
}
