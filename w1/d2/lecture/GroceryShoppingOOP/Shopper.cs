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

        public List<Product> ShoppingList { get; }


        public Shopper(string name, decimal budget, List<Product> shoppingList)
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
                foreach (Product desiredProd in ShoppingList)
                {
                    foreach (Product availableProd in _currentStore.Products)
                    {
                        if (desiredProd.Name == availableProd.Name && availableProd.Quantity > 0)
                        {
                            // need to create a new product to use in our shopping cart so we can update it freely
                            // if we add one of the existing products, then update it, it will update it by "reference"
                            // meaning it will get updated in every list it's in, because it's the same object unless we create a new one
                            Product cartProduct = new Product(availableProd.Name, 0, availableProd.Price);

                            // at most, can buy the full available quantity
                            if (desiredProd.Quantity > availableProd.Quantity)
                            {
                                cartProduct.Quantity = availableProd.Quantity;
                                ShoppingCart.Add(cartProduct);

                                availableProd.Quantity = 0;
                            }
                            else
                            {
                                cartProduct.Quantity = desiredProd.Quantity;
                                ShoppingCart.Add(cartProduct);

                                availableProd.Quantity -= desiredProd.Quantity;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"{Name}'s cart: {string.Join(", ", ShoppingCart)}\n");
            _currentStore.DisplayAvailableProducts(); // to see quantities updated
        }

        public void GroceryCheckout()
        {
            decimal totalBill = _currentStore.BillShopper(this);
            Console.WriteLine($"Bill from {_currentStore.Name}: {totalBill} | {Name}'s Budget: {_budget}\n");

            if (totalBill > _budget)
            {
                Console.WriteLine($"I got too many groceries. -{Name}\n");
            }
            else
            {
                _budget -= totalBill;
                Console.WriteLine($"{Name}'s remaining Budget: {_budget}\n");
                _currentStore.ReceivePayment(totalBill);
                ExitStore();
            }
        }

        public void ExitStore()
        {
            _currentStore.ShopperExiting(this);
            _currentStore = null;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}