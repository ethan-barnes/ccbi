using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccbiTest
{
    internal class Country
    {
        private string Name;
        private int Population;

        // Processes raw string input and stores in attributes.
        public Country(string unparsedText)
        {
            string[] splitString = unparsedText.Split("\",", StringSplitOptions.None);

            Name = splitString[0].Substring(2);
            Population = GetNumbers(splitString[1]);
        }

        // Returns human-readable string designed to be used as text output.
        public string GetOutput()
        {
            return $"Name: {Name}, Population: {Population}";
        }

        // Strips any non-numbers character from input string and returns as an integer.
        private static int GetNumbers(string input)
        {
            return int.Parse((input.Where(c => char.IsDigit(c)).ToArray()));
        }

        public int GetPopulation()
        {
            return Population;
        }
    }
}
