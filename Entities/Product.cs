namespace Entities
{
    public class Product
    {
        public Product(int id, string name, int unitPrice)
        {
            this.id = id;
            Name = name;
            this.unitPrice = unitPrice;
        }

        public Product()
        {
        }

        public int id { get; set; }
        public string Name { get; set; }
        public int unitPrice { get; set; }

    }
}
