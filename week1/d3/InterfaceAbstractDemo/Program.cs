using System;
using System.Collections.Generic;

namespace InterfaceAbstractDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bunker bunker = new Bunker("Man Cave");
            // Hero man = new Hero("Man", bunker);

            // Bunker pineapplePalace = new Bunker("Pineapple Palace");
            // Hero spongeBoyRoundPants = new Hero("Sponge Boy Round Pants", pineapplePalace);

            // spongeBoyRoundPants.Attack(bunker);
            // spongeBoyRoundPants.Attack(man.HomeBase);

            // man.Attack(spongeBoyRoundPants.HomeBase);
            // man.Attack(spongeBoyRoundPants.HomeBase);

            Food food = new Food()
            {
                IsYummy = true,
                Message = "Dinner's ready.",
            };

            Console.WriteLine(food.Message);
            food.IsYummy = false;
            Console.WriteLine(food.Message);

        }
    }
}
