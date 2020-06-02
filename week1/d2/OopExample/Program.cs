using System;
using System.Collections.Generic;

namespace OopExample
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
                [x] Create a few grocery stores
                [x] Create a few shoppers [ ] with a shopping list
                [x] Have shoppers enter stores of their choosing
                    [x] when shopper enters store, store should print a greeting
                [x] Have store print list of shoppers
                [x] Shoppers have a shopping list
                [x] Add items from their list to their cart
                    [x] print shopping cart items
                [x] Shopper checkout and pay
                    [x] shopper must have enough money
                        [x] shopper says they got too many items if not enough money
                    [x] shopper exits store after checkout
                    [x] store prints goodbye to shopper
                    [x] store should print list of shopper names
            */

            // using the parameterless constructor we added back in
            // Shopper shopper = new Shopper();
            // shopper2.Name = "shopper";

            // Datatype varName = assigned value
            Shopper shopper1 = new Shopper("Patrick");

            Shopper shopper2 = new Shopper("Levi", 80m, new List<Product>() {
                new Product("Toilet Paper", 5),
                new Product("Healing Crystal", 30),
                new Product("How To Get Gud At LoL, For Dummies and Noobs", 1),
                new Product("Lysol", 3)
            });
            Shopper shopper3 = new Shopper("Monica", 30m, new List<Product>() {
                new Product("Fruit Flavored Chews With 0% Fruit", 8),
                new Product("Wasabi Peas", 2),
                new Product("Meat", 4)
            });
            Shopper shopper4 = new Shopper("Soey", 15m, new List<Product>() {
                new Product("Cactus Jerky", 2),
                new Product("Pineapple Pizza", 4),
                new Product("Egg", 4)
            });

            GroceryStore albertAndHisSons = new GroceryStore(
                "Albertsons",
                new List<Shopper>() { shopper1 }
            );


            shopper1.EnterStore(albertAndHisSons);
            shopper2.EnterStore(albertAndHisSons);
            shopper2.AddGroceriesToCart();
            shopper2.Checkout();
            shopper3.EnterStore(albertAndHisSons);
            shopper4.EnterStore(albertAndHisSons);


            // using the parameterless constructor
            // Product prod = new Product()
            // {
            //     Name = "Almond Flavored Water",
            //     Price = 3.95m,
            //     Quantity = 10
            // };
        }
    }
}
