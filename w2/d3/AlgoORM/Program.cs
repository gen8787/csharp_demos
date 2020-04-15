using System;

namespace AlgoORM
{
    // create a dotnet new console project and copy this code into it
    public class ForumPost
    {
        public string Topic { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // convert this List of dictionaries into a List<ForumPost> like a good ORM boy would
            List<Dictionary<string, object>> forumPostsFromDb = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>{
                    { "Topic", "Today I learned something cool."},
                    { "Body", "ORMs are very cool."},
                    { "Rating", 10}
                },
                // https://store.steampowered.com/app/821320/SPAGHET/
                new Dictionary<string, object>{
                    { "Topic", "Somebody toucha my spaghet "},
                    { "Body", "Spaghet is a video game on steam for those who cannot resist slapping spaghet."},
                    { "Rating", 9}
                },
                new Dictionary<string, object>{
                    { "Topic", "I'm a huge fan."},
                    { "Body", "Whirl, whirl, whirl."},
                    { "Rating", 4}
                }
            };


        }
    }
}
