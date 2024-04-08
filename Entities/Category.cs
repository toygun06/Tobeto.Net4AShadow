using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category
    {
        public Category(int ıd, string name)
        {
            Id = ıd;
            Name = name;
        }

        public Category()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
