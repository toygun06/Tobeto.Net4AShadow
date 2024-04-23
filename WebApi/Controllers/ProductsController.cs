using Business.Abstracts;
using Business.Concretes;
using Business.Features.Products.Commands.Create;
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
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public ProductsController(IProductService productService, IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }

        [HttpPost]
        public async void Add([FromBody] CreateProductCommand command)
        {
            //await _productService.Add(product);
            await _mediator.Send(command);
        }
    }
}
