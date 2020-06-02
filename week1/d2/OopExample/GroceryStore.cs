using System;
using System.Collections.Generic;

namespace OopExample
{
    public class GroceryStore
    {
        // property with no set, cannot be assigned from outside class
        public string Name { get; }
        private List<Shopper> shoppers = new List<Shopper>();

        public GroceryStore() { }
        private List<Shopper> bannedShoppers = new List<Shopper>();
        public List<Product> Products { get; set; }
        private decimal till = 0m;
        public GroceryStore(string name, List<Shopper> bannedShoppers)
        {
            Name = name;
            this.bannedShoppers.AddRange(bannedShoppers);
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
        private void DisplayShoppers()
        {
            Console.WriteLine(string.Join(", ", shoppers));
        }

        public void ShopperEntering(Shopper shopper)
        {
            if (bannedShoppers.Contains(shopper))
            {
                Console.WriteLine($"You are not welcome in my store {shopper.Name}.");
            }
            else
            {
                shoppers.Add(shopper);
                Console.WriteLine($"Welcome {shopper.Name} to {Name}");
            }
            DisplayShoppers();
        }

        public void ShopperExiting(Shopper shopper)
        {
            shoppers.Remove(shopper);
            DisplayShoppers();
            Console.WriteLine($"Goodbye {shopper.Name}, thank you for shopping at {Name}.");
        }

        public decimal BillShopper(Shopper shopper)
        {
            decimal customersBill = 0m;

            foreach (Product cartItem in shopper.ShoppingCart)
            {
                customersBill += cartItem.Price;
            }
            Console.WriteLine($"{shopper.Name}, your bill is ${customersBill}.");
            return customersBill;
        }

        public void ReceivePayment(decimal totalBill, string customerName)
        {
            till += totalBill;
            Console.WriteLine($"{Name} received payment from {customerName} in the amount of ${totalBill}.");
        }
    }
}