namespace InterfaceAbstractDemo
{
    public class Hero : IDamageable
    {
        public int Health { get; set; }
        public string Name;

        public Hero(string name)
        {
            Name = name;
            Health = 100;
        }

        public int TakeDamage(int amnt)
        {
            if (Health - amnt < 0)
            {
                Health = 0;
            }
            else
            {
                Health -= amnt;
            }

            return Health;
        }

        public int Attack(IDamageable target)
        {
            int targetsNewHealth = target.TakeDamage(10);
            return targetsNewHealth;
        }
    }
}