using System;
using System.IO;
using System.Text.RegularExpressions;

namespace EmailExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            
         //   System.IO.StreamReader (Data/sample.txt);
         string textInput = File.ReadAllText("Data/sample.txt");
         
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
         string pattern = "\\w(@softwire.com)";
         Regex rx=new Regex(pattern);
         Console.WriteLine("The Number of Softwire emails is " +rx.Matches(textInput).Count);
        }
    }
}