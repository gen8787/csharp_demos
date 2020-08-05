namespace AbstractIntro
{
    // Not all buildings are Damageable in our game
    public abstract class Building
    {
        // abstract prop means it must implement / be overriden 
        public abstract string Name { get; set; }
        // virtual means it CAN be overriden but doens't need to be
        public virtual int Floors { get; set; }

        public Building()
        {
            Floors = 1;
        }
    }
}