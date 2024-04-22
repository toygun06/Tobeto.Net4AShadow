using Business.Abstracts;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Add(Product product)
        {
            //ürün ismini kontrol et
            //fiyatını kontrol et
            if (product.UnitPrice < 0)
                throw new BusinessException("Ürün fiyatı 0'dan küçük olamaz.");
            //aynı isimde 2. ürün eklenemez

            Product productWithSameName = await _productRepository.GetAsync(p=>p.Name == product.Name);
            if (productWithSameName == null)
                throw new System.Exception("Aynı isimde 2. ürün eklenemez.");
            await _productRepository.AddAsync(product);
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetListAsync();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
