using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IProductService
    {
        Product GetById(int id);
        Task<List<Product>> GetAll();
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
