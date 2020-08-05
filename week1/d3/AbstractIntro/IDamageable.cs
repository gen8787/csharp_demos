namespace AbstractIntro
{
    public interface IDamageable
    {
        // Any classes that inherit this interface MUST have a health prop / field
        int Health { get; set; }
        // Must have the take damage FUNCtionality
        int TakeDamage(int dmg);
    }
}