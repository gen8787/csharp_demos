using System;
using System.Collections.Generic;

namespace GroceryStoreOOP
{
    public class Shopper
    {
        public string Name { get; }
        private decimal wallet;
        private List<Product> shoppingList = new List<Product>();
        public List<Product> ShoppingCart { get; } = new List<Product>();
        private GroceryStore currentStore = null;

        // bring back the default 0 argument constructor to let us instantiate an empty shopper
        public Shopper() { }
        public Shopper(string name, List<Product> shoppingList, decimal wallet)
        {
            // this.Name = name;
            Name = name;
            this.shoppingList = shoppingList;
            this.wallet = wallet;
        }

        public void EnterStore(GroceryStore store)
        {
            // pass "this" shopper into the specified grocery store
            store.ShopperEntering(this);
            currentStore = store;
            Shop();
        }

        public void ExitStore()
        {
            if (currentStore != null)
            {
                currentStore.ShopperExiting(this);
                currentStore = null;
            }
        }

        public void Shop()
        {
            if (currentStore == null)
            {
                return;
            }

            foreach (Product desiredProduct in shoppingList)
            {
                foreach (Product availProduct in currentStore.Products)
                {
                    if (desiredProduct.Name == availProduct.Name)
                    {
                        // test cases:
                        // avail 5, desired 7
                        // avail 5, desired 5
                        // avail 0, desired 5
                        // avail 5, desired 2
                        int quantityTaken = 0;

                        if (desiredProduct.Quantity >= availProduct.Quantity)
                        {
                            quantityTaken = availProduct.Quantity;
                            availProduct.Quantity = 0;
                        }
                        // desired quantity is less than because it's not >=
                        else
                        {
                            quantityTaken = desiredProduct.Quantity;
                            availProduct.Quantity -= desiredProduct.Quantity;
                        }

                        if (quantityTaken > 0)
                        {
                            Product cartProd = new Product(availProduct.Name, quantityTaken, availProduct.Price);
                            ShoppingCart.Add(cartProd);
                        }
                        break;
                    }
                }
            }
            Console.WriteLine("Shopping List:");
            Console.WriteLine(string.Join(", ", ShoppingCart));

            Console.WriteLine("Inventory:");
            Console.WriteLine(string.Join(", ", currentStore.Products));
        }

        public void Checkout()
        {
            if (currentStore != null)
            {
                decimal bill = currentStore.BillShopper(this);

                if (bill > wallet)
                {
                    Console.WriteLine($"{Name} ran away in shame because they don't have enough $.");
                }
                else
                {
                    wallet -= bill;
                    currentStore.receivePayment(bill);
                }
            }
            Console.WriteLine($"{Name}'s wallet is now ${wallet}.");
            ExitStore();
        }

        public override string ToString()
        {
            return Name;
        }
    }

}