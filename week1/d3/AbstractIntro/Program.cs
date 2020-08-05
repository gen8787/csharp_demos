using System;
using System.Collections.Generic;

namespace AbstractIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero("Heroic Dude", new Bunker("Dude Bunker"));
            Hero hero2 = new Hero("Heroic Princess", new Bunker("Princess Bunker"));
            Bunker bunker = new Bunker("Solid Boi");

            Console.WriteLine(hero2.Attack(hero.HomeBase));
            Console.WriteLine(hero2.Attack(hero.HomeBase));
        }
    }
}
