using System;

namespace InterfaceAbstractDemo
{
    public abstract class Building
    {
        public int Health { get; set; }
        public abstract double SquareFootage { get; }
        public abstract string Name { get; set; }
        private bool _isShielded = true;

        public Building()
        {
            Health = 300;
        }

    }
}