using Business.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        List<Category> categories;

        public CategoryManager()
        {
            this.categories = new List<Category>();
        }

        public void Add(Category category)
        {;
            categories.Add(category);
        }

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return this.categories;
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
