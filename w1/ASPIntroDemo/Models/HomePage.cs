namespace ASPIntroDemo.Models
{
    public class HomePage
    {
        public User Tourist { get; set; }
        public Destination[] TravelDestinations { get; set; }
        public HomePage(User tourist, Destination[] travelDestinations)
        {
            Tourist = tourist;
            TravelDestinations = travelDestinations;
        }
    }

}