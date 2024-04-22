using Business.Abstracts;
using Business.Concretes;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public async Task<List<Product>> GetAll()
        {
            return await _productService.GetAll();
        }

        [HttpPost]
        public async void Task Add([FromBody] Product product)
        {
            await _productService.Add(product);
        }

        [HttpGet("Senkron")]
        public string Sync()
        {
            Thread.Sleep(5000); //5. saniye beklet.
            return "Sync endpoint";
        }

        [HttpGet("Senkron")]
        public async Task<string> Async()
        {
            await Task.Delay(5000);
            return "Async endpoint";
        }
    }
}
