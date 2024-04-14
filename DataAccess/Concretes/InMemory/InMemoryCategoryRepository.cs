using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.InMemory
{
    public class InMemoryCategoryRepository : ICategoryRepository
    {
        List<Category> _categories;

        public InMemoryCategoryRepository()
        {
            _categories = new List<Category>();
        }
        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public void Delete(Category category)
        {
            _categories.Remove(category);
        }

        public List<Category> GetAll()
        {
            return _categories;
        }

        public Category GetById(int id)
        {
            Category? category = _categories.FirstOrDefault(c => c.Id == id);
            return category;
        }

        public void Update(Category category)
        {
            //InMemory olduğundan atlandı.
        }
    }
}
