using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace EmailExtraction
{
    class Program
    {
        static string textInput = File.ReadAllText("Data/sample.txt");
        static void Main(string[] args)
        {
            
         //   System.IO.StreamReader (Data/sample.txt);
      
         
         //using array method
      /*   string[]inputArray = textInput.Split(" ");
        int counter = 0;
        
         for (int i = 0; i < inputArray.Length; i++)
         {
             if (inputArray[i].Contains("@softwire.com"))
             {
                 counter++;
                 //Console.WriteLine(inputArray[i]);
             }
         }
        */
         
         //using reg expression
      /*   string pattern = "\\w(@softwire.com)";
         Regex rx=new Regex(pattern);
         Console.WriteLine("The Number of Softwire emails is " +rx.Matches(textInput).Count);
        */ 
         
         //using dictionary
         Dictionary<string,int> emailDictionary=new Dictionary<string, int>();
        
      
         string pattern = @"@\w*(\.\w+){1,3}";
      
         Regex rx=new Regex(pattern);
         MatchCollection matches = rx.Matches(textInput);
         foreach (Match match in matches)
         {
             Group domain = match.Groups[0];

             if (!emailDictionary.ContainsKey(domain.Value))
             {
                 emailDictionary.Add(domain.Value,1);
             }
             else
             {
                 emailDictionary[domain.Value] += 1;
             }

         }
         
         //ordering the dictionary
        int cnt = 1;
         //retrieving from dictionary 
        foreach (var VARIABLE in emailDictionary.OrderByDescending(key=>key.Value))
         {
             Console.WriteLine(VARIABLE.Key + VARIABLE.Value);
             if (cnt == 10)
             {
                 break;
             }

             cnt += 1;
         }

        string strFrequency = Console.ReadLine();
        foreach (KeyValuePair<String,int> domain in emailDictionary ){
            if (domain.Value > Int32.Parse(strFrequency))
            {
                Console.WriteLine(domain.Key + domain.Value);
            }
            
        }
        
        }

     
    }
}