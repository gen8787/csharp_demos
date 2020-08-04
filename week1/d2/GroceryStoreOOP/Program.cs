﻿using System;
using System.Collections.Generic;

namespace GroceryStoreOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
                [x] Create a few grocery stores
                [x] Create a few shoppers
                [x] Have shoppers enter stores of their choosing
                    [x] when shopper enters store, store should print a greeting
                [x] Have store print list of shoppers
                [x] Shoppers have a shopping list
                [] Add items from their list to their cart
                    [] print shopping cart items
                [] Shopper checkout and pay
                    [] shopper must have enough money
                        [] shopper says they got too many items if not enough money
                    [] shopper exits store after checkout
                    [] store prints goodbye to shopper
                    [] store should print list of shopper names
            */

            // DataType varName = value of var
            GroceryStore albertsons = new GroceryStore("Albert And His Beautiful Sons");

            List<Product> shoppingList1 = new List<Product>() {
                new Product("Toilet Paper", 5),
                new Product("Healing Crystal", 30),
                new Product("How To Get Gud At LoL, For Dummies and Noobs", 1),
                new Product("Lysol", 3)
            };

            List<Product> shoppingList2 = new List<Product>() {
                new Product("Fruit Flavored Chews With 0% Fruit", 8),
                new Product("Wasabi Peas", 2),
                new Product("Meat", 4)
            };

            List<Product> shoppingList3 = new List<Product>() {
                new Product("Cactus Jerky", 2),
                new Product("Pineapple Pizza", 4),
                new Product("Egg", 4)
            };

            Shopper shopper1 = new Shopper("Dustin", shoppingList1);
            Shopper shopper2 = new Shopper("Dallas", shoppingList3);

            shopper1.EnterStore(albertsons);
            shopper2.EnterStore(albertsons);
        }
    }
}
