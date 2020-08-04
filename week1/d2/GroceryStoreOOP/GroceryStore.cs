using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryStoreOOP
{
    public class GroceryStore
    {
        // auto-implemented property with no set, cannot be assinged from outside this class file
        public string Name { get; }
        private decimal till = 0m;
        private List<Shopper> shoppers = new List<Shopper>();
        public List<Product> Products { get; } = new List<Product>();

        public GroceryStore(string name)
        {
            Name = name;

            Products = new List<Product>
            {
                new Product("Toilet Paper", 3, 7.99m),
                new Product("Milk", 5, 4.99m),
                new Product("Royal Jelly", 3, 10.95m),
                new Product("Healing Crystal", 5, 66.6m),
                new Product("Cactus Jerkey", 10, 5.95m),
                new Product("Meat", 10, 5.95m),
                new Product("Fruit Flavored Chews With 0% Fruit", 5, 1.50m),
                new Product("Egg", 60, 0.99m),
                new Product("Lysol", 0, 19.99m),
            };
        }

        public void ShopperEntering(Shopper shopper)
        {
            shoppers.Add(shopper);
            GreetShopper(shopper);
            PrintCurrentShoppers();
        }

        public void ShopperExiting(Shopper shopper)
        {
            int idx = shoppers.IndexOf(shopper);

            if (idx > -1)
            {
                shoppers.RemoveAt(idx);
            }
            Console.WriteLine($"Goodbye {shopper.Name}, thank you for shopping at {Name}.");
            PrintCurrentShoppers();
        }

        private void GreetShopper(Shopper shopper)
        {
            Console.WriteLine($"Welcome {shopper.Name} to {Name}");
        }

        private void PrintCurrentShoppers()
        {
            Console.WriteLine("--------Current Shoppers--------");
            Console.WriteLine(string.Join(", ", shoppers));
        }

        // another constructor with it's own signature (method name, and params make up the signature)
        public GroceryStore(string name, decimal till)
        {
            Name = name;
            this.till = till;
        }

        public decimal BillShopper(Shopper shopper)
        {
            // LINQ, we will learn more of this later
            // arrow function: param => some logic
            // .Sum runs a loop over the list that is to the left of .Sum and executes the arrow function for each item, passing the item to the arrow function's parameter
            decimal totalBill = shopper.ShoppingCart.Sum(prod => prod.Price * prod.Quantity);
            Console.WriteLine($"{Name} has billed ${shopper.Name} ${totalBill}.");
            return totalBill;
        }

        public void receivePayment(decimal bill)
        {
            till += bill;
            Console.WriteLine($"{Name}'s till is now ${till}.");
        }
    }
}