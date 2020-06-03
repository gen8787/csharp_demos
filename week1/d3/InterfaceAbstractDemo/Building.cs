using System;

namespace InterfaceAbstractDemo
{
    public abstract class Building
    {
        public abstract string Name { get; set; }
        public abstract int Health { get; set; }

        public Building()
        {
            Health = 300;
        }
    }
}