using System;
using System.Collections.Generic;

namespace GroceryShoppingOOP
{
    public class GroceryStore
    {
        public string Name { get; }
        private List<Shopper> _shoppers = new List<Shopper>();

        private List<Product> _products = new List<Product>();
        private decimal _till = 0;


        public List<Product> Products { get { return _products; } }

        public GroceryStore(string name)
        {
            Name = name;

            _products = new List<Product>
            {
                new Product("Milk", 5, 4.99m),
                new Product("Royal Jelly", 3, 10.95m),
                new Product("Healing Crystal", 5, 66.6m),
                new Product("Cactus Jerkey", 10, 5.95m),
                new Product("Fruit Flavored Fruitless Chews", 5, 1.50m),
            };
        }

        public void ShopperEntering(Shopper shopper)
        {
            _shoppers.Add(shopper);
            DisplayShoppers();
        }

        public void ShopperExiting(Shopper shopper)
        {
            _shoppers.Remove(shopper);
            DisplayShoppers();
            Console.WriteLine($"Goodbye {shopper.Name}\n");
        }

        private void DisplayShoppers()
        {
            Console.WriteLine(string.Join(", ", _shoppers));
        }

        public void DisplayAvailableProducts()
        {
            Console.WriteLine($"{Name}'s inventory: {string.Join(", ", _products)}\n");
        }

        public decimal BillShopper(Shopper shopper)
        {
            decimal totalBill = 0;

            foreach (Product prod in shopper.ShoppingCart)
            {
                totalBill += prod.Price * prod.Quantity;
            }
            Console.WriteLine($"{Name} says, \"{shopper.Name}, your bill is: {totalBill}\"\n");
            return totalBill;
        }

        public void ReceivePayment(decimal shopperPayment)
        {
            _till += shopperPayment;
            Console.WriteLine($"{Name}'s till has ${_till}.\n");
        }
    }
}