namespace GroceryShoppingOOP
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}