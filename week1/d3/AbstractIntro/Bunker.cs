namespace AbstractIntro
{
    public class Bunker : Building, IDamageable
    {
        public int Health { get; set; }
        public override string Name { get; set; }
        public bool isShielded = true;

        public Bunker(string name)
        {
            Name = name;
            Health = 300;
        }

        public int TakeDamage(int dmg)
        {
            if (isShielded)
            {
                isShielded = false;
            }
            else
            {
                Health -= dmg;

                if (Health <= 100)
                {
                    isShielded = true;
                }
            }
            return Health;
        }
    }
}