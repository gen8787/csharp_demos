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
        public GroceryStore(string name, List<Shopper> bannedShoppers)
        {
            Name = name;
            this.bannedShoppers.AddRange(bannedShoppers);
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
    }
}