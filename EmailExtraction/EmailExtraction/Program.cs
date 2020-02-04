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
         Console.Write(textInput);
        }
    }
}