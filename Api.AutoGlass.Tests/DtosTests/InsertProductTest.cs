using Api.AutoGlass.Domain.Command;
using Api.AutoGlass.Domain.Validators;

namespace Api.AutoGlass.Tests.DtosTests
{
    public class InsertProductTest
    {
        private readonly ProductRequestValidator _validator;
        public InsertProductTest()
        {
            _validator = new ProductRequestValidator();
        }

        private readonly InsertProductCommand _insertProductCommand = new InsertProductCommand
        {
            Code = 1,
            Description = "Teste",
            Status = 0,
            DateManufacturing = DateTime.Now,
            DateValidate = DateTime.Now.AddDays(+1),
            SupplierCode = 1,
            SupplierDescription = "Fornecedor",
            Cnpj = "123456789",
        };

        [Fact]
        public void ProductSearch_InvalidDates_ShouldFailValidation()
        {
            _insertProductCommand.DateManufacturing = DateTime.Now;
            _insertProductCommand.DateValidate = DateTime.Now.AddSeconds(-1);


            var result = _validator.Validate(_insertProductCommand);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ProductSearch_ValidDates_ShouldPassValidation()
        {
            _insertProductCommand.DateManufacturing = DateTime.Now.AddDays(-1);
            _insertProductCommand.DateValidate = DateTime.Now;

            var result = _validator.Validate(_insertProductCommand);
            Assert.True(result.IsValid);
        }
    }
}
