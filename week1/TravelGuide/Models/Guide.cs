using System.Collections.Generic;

namespace TravelGuide.Models
{
    public class Guide
    {
        public Traveler Traveler { get; set; }
        public List<Destination> Destinations { get; set; } = TravelDestinations.Destinations;

        // can put any amount of other classes or properties that this Guide class needs to use on the page that displays it
    }
}