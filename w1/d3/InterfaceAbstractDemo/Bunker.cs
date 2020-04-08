namespace InterfaceAbstractDemo
{
    public class Bunker : Building, IDamageable
    {
        // public override int Health { get; set; }
        public override string Name { get; set; }
        public override double SquareFootage { get; }
        private bool _isShielded = true;

        public Bunker(string name)
        {
            _isShielded = true;
            Health = 400;
            Name = name;
        }
        public int TakeDamage(int amnt)
        {
            if (_isShielded == true)
            {
                _isShielded = false;
            }
            else
            {
                Health -= amnt;
            }
            if (Health <= 100)
            {
                _isShielded = true;
            }
            return Health;
        }
    }
}