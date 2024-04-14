using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category
    {
        public Category(int id, string name)
        {
            Id = id;
            Name = name;

        }

        public Category()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
