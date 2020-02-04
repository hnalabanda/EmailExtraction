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
            //string domainRegExPattern = @"\w@(?<domain>\w*)(?<tld>.\w*\b)";
            string domainRegExPattern = @"\S+@(?<domain>\S+)\b";
            Regex domainSearch = new Regex(domainRegExPattern);

            //storing domains and counts in dictionary
            foreach (Match result in domainSearch.Matches(textInput))
            {
                var domain = result.Groups["domain"].Value;
                if (emailDictionary.ContainsKey(domain))
                {
                    emailDictionary[domain]++;
                }
                else
                {
                    emailDictionary.Add(domain, 1);
                }
            }

            // Sort the domains by the X most common
            List<KeyValuePair<string, int>> domainList = emailDictionary.ToList();
            domainList.Sort((left, right) => right.Value.CompareTo(left.Value));
            
            //Print the top X domains
            int numberOfDomainsToPrint = 10;
            Console.WriteLine($"These are the top {numberOfDomainsToPrint} domains in the file {fileName}");
            for (var i = 0; i < numberOfDomainsToPrint; i++)
            {
                Console.WriteLine($"The domain {domainList[i].Key} appears {domainList[i].Value} Times");
            }
        }
    }
}