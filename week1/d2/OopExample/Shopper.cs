using System;
using System.Collections.Generic;

namespace OopExample
{
    public class Shopper
    {
        // auto implemented property
        public string Name { get; set; }
        private GroceryStore currentStore = null;

        private List<Product> shoppingList = new List<Product>();
        public List<Product> ShoppingCart { get; set; } = new List<Product>();
        private decimal wallet;

        // default parameterless constructor, if you have no constructor, this will be used even if you don't write it
        // if you create your own constructor, the default parameterless constructor will no longer be available
        // unless you add it back in
        public Shopper() { }
        public Shopper(string name)
        {
            // this.Name = name;
            Name = name;
        }

        public Shopper(string name, decimal wallet, List<Product> shoppingList)
        {
            Name = name;
            this.wallet = wallet;
            this.shoppingList = shoppingList;
        }

        public void EnterStore(GroceryStore selectedStore)
        {
            currentStore = selectedStore;
            selectedStore.ShopperEntering(this);
        }

        public void ExitStore()
        {
            if (currentStore != null)
            {
                currentStore.ShopperExiting(this);
                currentStore = null;
            }
        }

        public void PrintShoppingCart()
        {
            Console.WriteLine(string.Join(", ", ShoppingCart));
        }

        public void AddGroceriesToCart()
        {
            if (currentStore != null)
            {
                foreach (Product desiredProd in shoppingList)
                {
                    foreach (Product availableProd in currentStore.Products)
                    {
                        if (desiredProd.Name == availableProd.Name && availableProd.Quantity > 0)
                        {
                            Product cartProduct = new Product(availableProd.Name, 0, availableProd.Price);

                            if (desiredProd.Quantity > availableProd.Quantity)
                            {
                                cartProduct.Quantity = availableProd.Quantity;
                                availableProd.Quantity = 0;
                            }
                            else
                            {
                                cartProduct.Quantity = desiredProd.Quantity;
                                availableProd.Quantity -= desiredProd.Quantity;
                            }

                            ShoppingCart.Add(cartProduct);
                            // we found the product we are looking for, cancel the rest of this loop, go to next desiredProd
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"{Name}'s cart: {string.Join(", ", ShoppingCart)}");
        }

        public void Checkout()
        {
            decimal totalBill = currentStore.BillShopper(this);

            if (wallet >= totalBill)
            {
                wallet -= totalBill;
                currentStore.ReceivePayment(totalBill, this.Name);
                Console.WriteLine($"{Name} now has ${wallet} left.");
            }
            else
            {
                Console.WriteLine($"{Name}: Oops, I got too many items, I will now exit the store in shame.");
                ShoppingCart = new List<Product>();
            }
            ExitStore();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}