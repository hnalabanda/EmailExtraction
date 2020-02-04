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
            string textInput = File.ReadAllText("Data/sample.txt");
         
         //using array method
        //  string[]inputArray = textInput.Split(" ");
        // int counter = 0;
        //
        //  for (int i = 0; i < inputArray.Length; i++)
        //  {
        //      if (inputArray[i].Contains("@softwire.com"))
        //      {
        //          counter++;
        //          //Console.WriteLine(inputArray[i]);
        //      }
        //  }
        
        //creating a dictionary
        Dictionary<string,int> emailDictionary = new Dictionary<string,int>();
        // emailDictionary.Add("softwire.com", 1);
        
        
        //finding domains with regular expression
        string pattern = @"\w@(\w*\.\w+){1,3}"; //this regex expression looks for words after a letter@ combo and allows for 1-3 dot word combinations 
        Regex domainSearch=new Regex(pattern);
        
        //using domains for 
        Match firstMatch = domainSearch.Matches(textInput).First();
        //var domain = firstMatch.Groups[1];

        foreach (Match result in domainSearch.Matches(textInput))
        {
            var domain = result.Groups[1].Value;
            if (emailDictionary.ContainsKey(domain))
            {
                emailDictionary[domain]++;
            }
            else
            {
                emailDictionary.Add(domain,1);
            }
        }

        foreach (var entry in emailDictionary)
        {
            Console.WriteLine(entry.Key + " "  + entry.Value);
        }
        
     
      
        }
    }
}