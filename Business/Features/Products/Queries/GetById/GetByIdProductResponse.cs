using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Products.Queries.GetById
{
    public class GetByIdProductResponse
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int UnitPrice { get; set; }
        public int Stock { get; set; }
    }
}
