using System.Collections.Generic;

namespace TravelGuide.Models
{
    static public class TravelDestinations
    {
        static public List<Destination> Destinations { get; set; } = new List<Destination>()
        {
            new Destination("Longyearbyen", "https://en.visitsvalbard.com/imageresizer/?image=%2Fdmsimgs%2FE600D47425B2C241EB591A284DDE5C21ECC31B67.jpg&action=ProductDetailProFullWidth&crop=4D037D0DBBC22CD55D8AF767F9"),
            new Destination("Solovetsky Islands", "https://i.dailymail.co.uk/i/pix/2013/11/04/article-2487290-192FC96800000578-337_964x610.jpg"),
            new Destination("Socotra", "https://www.nationalgeographic.com/content/dam/environment/2018/10/socotra/01_socotra_nationalgeographic_2708459.jpg"),
            new Destination("Bhutan", "https://www.adventurewomen.com/wp-content/uploads/2018/04/1.-Tigers-Nest-800x533.jpg"),
            new Destination("Hell", "https://i.pinimg.com/originals/7d/8d/9e/7d8d9e7b0f2496c2ca1ac2c7ab7c78c0.jpg")
        };

        static public Destination GetDestination(string destinationName)
        {
            foreach (Destination dest in Destinations)
            {
                if (dest.Name == destinationName)
                {
                    return dest;
                }
            }
            return new Destination();
        }
    }
}