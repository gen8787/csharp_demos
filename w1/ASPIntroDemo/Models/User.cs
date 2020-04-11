namespace ASPIntroDemo.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Destination ChosenDestination { get; set; } = new Destination();

        // PARAMETERLESS CONSTRUCTOR NEEDED IF YOU WROTE YOUR OWN CONSTRUCTOR
        public User() { }
        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}