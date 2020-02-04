using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace EmailExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Importing our Data
            string fileName = "sample.txt";
            string filePath = "Data/" + fileName;
            string textInput = File.ReadAllText(filePath);

            //creating a dictionary
            Dictionary<string, int> emailDictionary = new Dictionary<string, int>();

            //finding domains with regular expression
            string pattern = @"\w@(\w*\.\w+){1,3}";
            Regex domainSearch = new Regex(pattern);

            //storing domains and counts in dictionary
            foreach (Match result in domainSearch.Matches(textInput))
            {
                var domain = result.Groups[1].Value;
                if (emailDictionary.ContainsKey(domain))
                {
                    emailDictionary[domain]++;
                }
                else
                {
                    emailDictionary.Add(domain, 1);
                }
            }

            // Prints the Dictionary with some padding
            foreach (var entry in emailDictionary)
            {
                Console.WriteLine("The domain " + entry.Key + " appears " + entry.Value + " times.");
            }
        }
    }
}