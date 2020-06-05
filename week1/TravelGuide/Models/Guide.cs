using System.Collections.Generic;

namespace TravelGuide.Models
{
    public class Guide
    {
        // accessibility DataType PropName { get; set; }
        public Traveler Traveler { get; set; }
        public List<Destination> Destinations { get; set; } = TravelDestinations.Destinations;

        // can put any amount of other classes inside this Guide class
        // public SomeOtherClass PropName { get; set; }
    }
}