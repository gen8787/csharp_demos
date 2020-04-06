using System;
using System.Collections.Generic;

namespace IntroProj
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "my name";

            // List<int> nums = new List<int>();
            // nums.Add(5);
            // nums.Add(6);
            // nums.Add(6);

            // nums.RemoveAt(nums.Count - 1);

            // foreach (int num in nums)
            // {
            //     Console.WriteLine(num);
            // }

            // int[] nums = new int[5];
            // nums[0] = 20;


            // string[] pingPongChamps = new String[] { "Neil", "Eduardo", "Morley" };
            // List<string> names = new List<string> { "Neil", "Jimmy" };

            // Console.WriteLine(string.Join(", ", names));

            Dictionary<string, dynamic> person = new Dictionary<string, dynamic>
            {
                {"FirstName", "Neil"},
                {"LastName", "Mos" },
                {"Age", 30}
            };

            person["FirstName"] = "Edited";
            person.Add("HairColor", "Brown");
            // Console.WriteLine(person["FirstName"]);

            foreach (KeyValuePair<string, dynamic> entry in person)
            {
                // Console.WriteLine(entry.Key + " - " + entry.Value);
                Console.WriteLine($"{entry.Key} - {entry.Value}");
            }
        }
    }
}
