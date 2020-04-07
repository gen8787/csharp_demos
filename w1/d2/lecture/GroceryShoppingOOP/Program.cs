using System;

namespace GroceryShoppingOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
                1. Create a few grocery stores
                2. Create a few shoppers with a shopping list
                3. Have shoppers enter stores of their choosing
                    - when shopper enters store, store should print a greeting
                4. Have store print list of shoppers
                5. Add items from their list to their cart
                    - print shopping cart items
                6. Shopper checkout and pay
                    - shopper must have enough money
                        - shopper says they got too many items if not enough money
                    - shopper exits store after checkout
                    - store prints goodbye to shopper
                    - store should print list of shopper names
            */

            GroceryStore albertAndHisSons = new GroceryStore("Albertsons");

            Shopper shopper1 = new Shopper("Scott", 10000);
            Shopper shopper2 = new Shopper("dennis", 1000);

            albertAndHisSons.ShopperEntering(shopper1);
            albertAndHisSons.ShopperEntering(shopper2);
        }
    }
}
