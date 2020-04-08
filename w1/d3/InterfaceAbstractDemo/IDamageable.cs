namespace InterfaceAbstractDemo
{
    public interface IDamageable
    {
        // classes that implement this interface MUST have Health
        int Health { get; set; }

        // classes that implement this interface MUST have a method with with this signature (name, return type, params)
        int TakeDamage(int amnt);

    }
}