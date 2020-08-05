namespace AbstractIntro
{
    public class Hero : IDamageable
    {
        public int Health { get; set; }
        public string Name;
        public IDamageable HomeBase;

        public Hero(string name, IDamageable homeBase)
        {
            Name = name;
            Health = 100;
            HomeBase = homeBase;
        }

        public int TakeDamage(int dmg)
        {
            Health -= dmg;
            return Health;
        }

        public int Attack(IDamageable target)
        {
            return target.TakeDamage(10);
        }
    }
}