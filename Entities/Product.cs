﻿using Core.DataAccess;

namespace Entities
{
    public class Product : Entity
    {


        public Product()
        {
        }

        public Product(int id,string name, double unitPrice, int stock, int categoryId)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
            Stock = stock;
            CategoryId = categoryId;
        }

        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Stock {  get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
