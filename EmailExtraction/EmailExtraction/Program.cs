using System;
using System.IO;

namespace EmailExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
         //   System.IO.StreamReader (Data/sample.txt);
         string textInput = File.ReadAllText("Data/sample.txt");
         string[]inputArray = textInput.Split(" ");
         // Console.Write(inputArray[1]);
         int counter = 0;
         for (int i = 0; i < inputArray.Length; i++)
         {
             if (inputArray[i].Contains("@softwire.com"))
             {
                 counter++;
                 //Console.WriteLine(inputArray[i]);
             }
         }
         Console.WriteLine("The Number of Softwire emails is " +counter);
        }
    }
}