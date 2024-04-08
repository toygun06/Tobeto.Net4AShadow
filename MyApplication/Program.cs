using MyApplication.Entities;
using MyApplication.Services;

Product product = new Product();
product.Name = "Monitor";
product.UnitPrice = 50;
product.Id = 1;

BaseProductService productService = new ProductService();
productService.AddProductWithLogging(product);

BaseProductService productService2 = new ProductServiceMySql();
productService2.AddProductWithLogging(product);

  


