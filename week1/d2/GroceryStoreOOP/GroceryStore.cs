using System;
using System.Collections.Generic;

namespace GroceryStoreOOP
{
    public class GroceryStore
    {
        // auto-implemented property with no set, cannot be assinged from outside this class file
        public string Name { get; }
        private decimal till = 0m;
        private List<Shopper> shoppers = new List<Shopper>();

        public GroceryStore(string name)
        {
            Name = name;
        }

        public void ShopperEntering(Shopper shopper)
        {
            shoppers.Add(shopper);
            GreetShopper(shopper);
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
    }
}