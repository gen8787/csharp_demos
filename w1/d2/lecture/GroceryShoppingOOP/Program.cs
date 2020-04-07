using System;
using System.Collections.Generic;

namespace GroceryShoppingOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
                - Create a few grocery stores
                - Create a few shoppers with a shopping list
                - Have shoppers enter stores of their choosing
                    - when shopper enters store, store should print a greeting
                - Have store print list of shoppers
                - Add items from their list to their cart
                    - print shopping cart items
                - Shopper checkout and pay
                    - shopper must have enough money
                        - shopper says they got too many items if not enough money
                    - shopper exits store after checkout
                    - store prints goodbye to shopper
                    - store should print list of shopper names
            */

            GroceryStore albertAndHisSons = new GroceryStore("Albertsons");

            Shopper shopper1 = new Shopper("Scott", 10000m, new Dictionary<string, int>() {
                {"Toilet Paper", 20},
                { "Healing Crystal", 5 },
                { "Meat", 3 }
            });

            Shopper shopper2 = new Shopper("dennis", 1000m, new Dictionary<string, int>() {
                {"Milk", 2},
                {"Fruit Flavored Fruitless Chews", 5 },
                { "Healing Crystal", 5 },
            });


            shopper1.EnterStore(albertAndHisSons);
            shopper2.EnterStore(albertAndHisSons);

            shopper1.AddGroceriesToCart();
            shopper2.AddGroceriesToCart();

        }
    }
}
