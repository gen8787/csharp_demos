namespace AbstractIntro
{
    public interface IDamageable
    {
        // Any classes that inherit this interface MUST have a health prop / field
        int Health { get; set; }

        // Must have the take damage FUNCtionality
        // Method signature only, child classes must implement and define the the method body
        // int TakeDamage(int dmg);

        // Or, provide a default implementation
        int TakeDamage(int dmg)
        {
            Health -= dmg;
            return Health;
        }
    }
}