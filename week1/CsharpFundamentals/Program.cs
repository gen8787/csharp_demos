
using System;
using System.Collections.Generic;

namespace CsharpFundamentals
{
    class Program
    {
        public static string QuoteMaker(string author, string quote, string dialogueVerb = "says")
        {
            string formattedQuote = $"{author} {dialogueVerb}, \"{quote}\"";
            Console.WriteLine(formattedQuote);
            return formattedQuote;
        }
        static void Main(string[] args)
        {
            // Datatype nameOfVar = assigned value
            int x = 5;

            // instantiate empty list of int
            // List<int> numbers = new List<int>();

            // instantiate list filled with some ints
            List<int> numbers = new List<int>() { 1, 2, 3, 4 };
            numbers.Add(x);
            numbers.Remove(1);
            numbers.RemoveAt(numbers.Count - 1);

            //      (Datatype varName in nameOfIteratable)
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            // arrays must have length specified and length cannot change
            int[] nums = new int[5];
            string[] pingPongChamps = new string[] { "Neil", "Eduardo", "Morley" };


            Dictionary<string, string> person1 = new Dictionary<string, string>() {
                {"FirstName", "Neil"},
                {"LastName", "Mos"}
            };

            Dictionary<string, dynamic> person2 = new Dictionary<string, dynamic>() {
                {"FirstName", "Ali"},
                {"LastName", "G"},
                {"Age", 1337}
            };

            // Add new key
            person2["HairColor"] = "Brown";
            // dot does not work
            // person2.HairColor = "Brown";

            Console.WriteLine($"{string.Join(", ", person2)}");

            // loop over dictionary
            foreach (KeyValuePair<string, dynamic> entry in person2)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }

            QuoteMaker("Ali G", "Techmology, is it good, or is it whack?", "shouted");
        }
    }
}
