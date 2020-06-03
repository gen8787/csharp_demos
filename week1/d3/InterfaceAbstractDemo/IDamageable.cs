namespace InterfaceAbstractDemo
{
    public interface IDamageable
    {
        // Any classes that implement this interface are contractually bound to have Health
        int Health { get; set; } // get set needed b/c interface can't have fields but can have props
        // Must have takeDamage FUNCTIONality, the class that implements this interface will define what the takeDamage method does
        int TakeDamage(int amnt);
    }
}