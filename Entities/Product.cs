namespace Entities
{
    public class Product
    {


        public Product()
        {
        }

        public Product(int ıd, string name, int unitPrice, int stock, int categoryId)
        {
            Id = ıd;
            Name = name;
            UnitPrice = unitPrice;
            Stock = stock;
            CategoryId = categoryId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public int Stock {  get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
