using Business.Abstracts;
using Business.Concretes;
using Business.Features.Products.Commands.Create;
using Business.Features.Products.Commands.Delete;
using Business.Features.Products.Commands.Update;
using Business.Features.Products.Queries.GetById;
using Business.Features.Products.Queries.GetList;
using Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand command)
        {
            //await _productService.Add(product);
            await _mediator.Send(command);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteProductCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
