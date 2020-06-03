using System;

namespace InterfaceAbstractDemo
{
    public class Hero : IDamageable
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public IDamageable HomeBase { get; set; }

        public Hero() { }

        public Hero(string name, IDamageable homeBase)
        {
            Name = name;
            Health = 100;
            HomeBase = homeBase;
        }

        public void Attack(IDamageable target)
        {
            target.TakeDamage(10);
        }

        public int TakeDamage(int amnt)
        {
            Health -= amnt;
            return Health;
        }

        // public void Attack(Building target)
        // {
        //     target.TakeDamage(10);
        // }

        // public void Attack(Hero target)
        // {
        //     target.TakeDamage(10);
        // }

    }
}