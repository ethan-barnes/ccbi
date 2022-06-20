using System;

namespace ccbiTest // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Country> countries = DataSetQuestion();
            LinkedListQuestion(countries);
        }

        public static List<Country> DataSetQuestion()
        {
            // Reading text from file and store each line as entry in array.
            string text = File.ReadAllText("..\\..\\..\\CountryData.txt");
            string[] splitText = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            // Converting each line of text into Country object and storing in array.
            List<Country> countries = new List<Country>();
            foreach (var newCountry in splitText)
            {
                countries.Add(new Country(newCountry));
            }

            /** Printing the value of each country object.
                Could be combined with above for loop but chosen not to for sake of exercise. */            
            foreach (var country in countries)
            {
                Console.WriteLine(country.GetOutput());
            }

            return countries;
        }

        public static void LinkedListQuestion(List<Country> countries)
        {
            LinkedList<Country> linkedList = new LinkedList<Country>(countries);
            Console.WriteLine(linkedList.Count());
            Country macau = new Country("(\"Macau(China)\",679600)");
            linkedList.Add(macau);
            Console.WriteLine(linkedList.Count());

            Country c = (Country)linkedList.DataAtIndex(10);
            Console.WriteLine(c.GetOutput());
            
            Country c1 = (Country)linkedList.DataAtIndex(10);
            Console.WriteLine(c1.GetOutput());
            linkedList.Add(macau, 3);
            Console.WriteLine(linkedList.Count());
            Country c2 = (Country)linkedList.DataAtIndex(3);
            Console.WriteLine(c2.GetOutput());
            Console.WriteLine(linkedList.Count());

            Country c3 = (Country)linkedList.DataAtIndex(5);
            Console.WriteLine(c3.GetOutput());
            linkedList.Remove(5);

            c3 = (Country)linkedList.DataAtIndex(5);
            Console.WriteLine(c3.GetOutput());
            Console.WriteLine(linkedList.Count());

            linkedList.Sort();
            for (int i = 0; i < linkedList.Count(); i++)
            {
                Console.WriteLine(((Country)linkedList.DataAtIndex(i)).GetOutput());
            }
        }
    }
}