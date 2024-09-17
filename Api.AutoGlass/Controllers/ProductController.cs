using Api.AutoGlass.Domain.Command;
using Api.AutoGlass.Domain.Models.Request;
using Api.AutoGlass.Domain.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.AutoGlass.Controllers
{
    [Route("api/autoglass/product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Recuperar por código.
        /// </summary>
        [HttpGet]
        [Route("v2/product/code")]
        [ProducesResponseType(typeof(ProductSearchResponseModel), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> GetByCode([FromQuery] ProductKeyRequest request)
        {
            try
            {
                return Ok(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Listar registros
        /// </summary>
        [HttpGet]
        [Route("v2/product/list")]
        [ProducesResponseType(typeof(ProductSearchResponseModel), 202)]
        [Produces("application/json")]
        public async Task<IActionResult> ProductsSearch([FromServices] IMediator mediator, [FromQuery] ProductSearchModel request)
        {
            try
            {
                return Ok(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Incluir novo produto.
        /// </summary>
        [HttpPost]
        [Route("v2/create-product")]
        [ProducesResponseType(typeof(SuccessProcessingModel), 201)]
        [Produces("application/json")]
        public async Task<IActionResult> ProductCreate([FromServices] IMediator mediator, [FromBody] InsertProductCommand request)
        {
            try
            {
                return Ok(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Editar dados de produto
        /// </summary>
        [HttpPut]
        [Route("v2/update-product")]
        [ProducesResponseType(typeof(ProductResponseModel), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> ProductUpdate([FromServices] IMediator mediator, [FromBody] UpdateProductCommand request)
        {
            try
            {
                return Ok(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Excluir produto.
        /// </summary>
        [HttpDelete]
        [Route("v2/remove-product")]
        [ProducesResponseType(typeof(SuccessProcessingModel), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> ProductRemove([FromServices] IMediator mediator, [FromQuery] DeleteProductCommand id)
        {
            try
            {
                return Ok(await _mediator.Send(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
