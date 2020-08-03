using System;
using System.Collections.Generic;

namespace LanguageIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(args[0]);
            // Console.WriteLine(args[1]);

            /******************************** ARRAYS ********************************/

            // dataType varName = value for var
            int[] nums = new int[5];
            // Console.WriteLine(string.Join(", ", nums));
            nums[0] = 10;
            // Console.WriteLine(string.Join(", ", nums));

            string[] pingPongChamps = new string[]
            {
                "Neil", "Eduardo", "Morley"
            };

            // Console.WriteLine(string.Join(", ", pingPongChamps));

            /******************************** LISTS ********************************/

            // List<dataTypeInsideList> varName = new List<dataTypeInsideList>();
            List<string> names = new List<string>();
            names.Add("Neil");
            // Console.WriteLine(string.Join(", ", names));

            names = new List<string>()
            {
                "Morley", "Eduardo", "Neil"
            };
            // Console.WriteLine(string.Join(", ", names));


            /******************************** DICTS ********************************/

            // Dictonary<keyDataType, valDataType> varName = new Dictonary<keyDataType, valDataType>();
            Dictionary<string, string> person = new Dictionary<string, string>()
            {
                {"FirstName", "Neil"},
                {"LastName", "M"},
            };

            // dynamic needed for val data type because val is either string or int
            Dictionary<string, dynamic> person2 = new Dictionary<string, dynamic>()
            {
                {"FirstName", "Olgy"},
                {"LastName", "Jeangilles"},
                {"Age", 26}
            };

            // like python, dicts must use bracket notation, but classes can use dot notation
            person2["HairColor"] = "Black";
            person2.Remove("LastName");
            // Console.WriteLine(string.Join(", ", person2));

            /******************************** LOOPS ********************************/

            // foreach (itemDataType itemVarName in collection)
            foreach (KeyValuePair<string, dynamic> entry in person2)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }

            Console.WriteLine("\nindex loop over list");
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }

            Console.WriteLine("\nforeach loop over list");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            string quote = DialogueQuoteMaker("Olgy", "How did Neil know my hair color?!", "exclaimed");
            Console.WriteLine(quote);
            Console.WriteLine(DialogueQuoteMaker("Dustin", "I love string interpolation."));
        }

        /******************************** METHODS ********************************/
        public static string DialogueQuoteMaker(string speaker, string quote, string dialogueVerb = "said")
        {
            return $"{speaker} {dialogueVerb}, \"{quote}\"";
        }
    }
}
