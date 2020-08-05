namespace AbstractIntro
{
    public abstract class Building
    {
        public int Health { get; set; }
        public abstract double SquareFootage { get; }
        public abstract string Name { get; set; }

        public Building()
        {
            Health = 300;
        }
    }
}