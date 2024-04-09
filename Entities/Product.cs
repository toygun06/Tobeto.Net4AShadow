namespace Entities
{
    public class Product
    {
        public Product(int id, string name, int unitPrice, int stock)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
            Stock = stock;
        }

        public Product()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public int Stock {  get; set; }

    }
}
