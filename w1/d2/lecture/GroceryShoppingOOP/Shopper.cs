using System;
using System.Collections.Generic;

namespace GroceryShoppingOOP
{
    public class Shopper
    {
        public Shopper(string name)
        {
            this.Name = name;

        }
        public string Name { get; set; }
        private decimal _budget;
        private GroceryStore _currentStore = null;
        // needs to be public so grocery store can access it for billing
        public List<Product> ShoppingCart { get; } = new List<Product>();

        public Dictionary<string, int> ShoppingList { get; }


        public Shopper(string name, decimal budget, Dictionary<string, int> shoppingList)
        {
            // this.Name = name;
            Name = name;
            _budget = budget;
            ShoppingList = shoppingList;
        }

        public void EnterStore(GroceryStore selectedStore)
        {
            selectedStore.ShopperEntering(this);
            _currentStore = selectedStore;
        }

        public void AddGroceriesToCart()
        {
            if (_currentStore != null)
            {
                foreach (KeyValuePair<string, int> entry in ShoppingList)
                {
                    string desiredProdName = entry.Key;
                    int desiredQuantity = entry.Value;

                    for (int i = 0; i < desiredQuantity; i++)
                    {
                        for (int j = 0; j < _currentStore.Products.Count; j++)
                        {
                            Product prod = _currentStore.Products[j];

                            if (prod.Name == desiredProdName)
                            {
                                ShoppingCart.Add(prod);
                                _currentStore.Products.RemoveAt(j);
                                // break out of j loop and go back to i loop
                                // to try to find another one of these products for our desiredQuantity
                                break;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"{Name}'s cart: {string.Join(", ", ShoppingCart)}");
        }

        public override string ToString()
        {
            return Name;
        }
    }
}