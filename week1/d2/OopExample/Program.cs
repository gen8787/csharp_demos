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
                [ ] Create a few shoppers with a shopping list
                [x] Have shoppers enter stores of their choosing
                    [x] when shopper enters store, store should print a greeting
                [x] Have store print list of shoppers
                [ ] Add items from their list to their cart
                    [ ] print shopping cart items
                [ ] Shopper checkout and pay
                    [ ] shopper must have enough money
                        [ ] shopper says they got too many items if not enough money
                    [ ] shopper exits store after checkout
                    [x] store prints goodbye to shopper
                    [ ] store should print list of shopper names
            */

            // using the parameterless constructor we added back in
            // Shopper shopper = new Shopper();
            // shopper2.Name = "shopper";

            // Datatype varName = assigned value
            Shopper shopper1 = new Shopper("Patrick");
            Shopper shopper2 = new Shopper("Levi");
            Shopper shopper3 = new Shopper("Monica");
            Shopper shopper4 = new Shopper("Soey");
            GroceryStore albertAndHisSons = new GroceryStore(
                "Albertsons",
                new List<Shopper>() { shopper1 }
            );


            shopper1.EnterStore(albertAndHisSons);
            shopper2.EnterStore(albertAndHisSons);
            shopper3.EnterStore(albertAndHisSons);
            shopper4.EnterStore(albertAndHisSons);

            shopper4.ExitStore();
        }
    }
}
