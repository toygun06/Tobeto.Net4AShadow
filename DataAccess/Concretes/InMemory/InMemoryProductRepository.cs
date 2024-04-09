using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.InMemory
{
    public class InMemoryProductRepository : IProductRepository
    {
        List<Product> products;

        public InMemoryProductRepository()
        {
            products = new List<Product>();
        }
        public void Add(Product product)
        {
            products.Add(product);
        }
        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            //LINQ => SQL'in C# hali
            //Bütün product'ları gez. id'si gelen id değerine eşit olanları filtrele.
            Product? product = products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public void Delete(Product product)
        {
            products.Remove(product);
        }

        public void Update(Product product)
        {
            //InMemory olduğundan atlandı.
        }
    }
}
