namespace InterfaceAbstractDemo
{
    public class Bunker : Building, IDamageable
    {
        public override int Health { get; set; }
        public override string Name { get; set; }
        private bool isShielded { get; set; }

        public Bunker(string name)
        {
            Health = 400;
            Name = name;
            isShielded = true;
        }

        public int TakeDamage(int amnt)
        {
            if (isShielded)
            {
                // take no dmg but shield is broken
                isShielded = false;
            }
            else
            {
                Health -= amnt;

                if (Health <= 100)
                {
                    isShielded = true;
                }
            }
            System.Console.WriteLine($"{Name}'s health is: {Health}.");

            return Health;
        }
    }
}