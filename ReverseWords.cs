using System;
using System.Linq;

namespace ReverseWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a String : ");
            string str = Console.ReadLine();
            
            string reverseString = string.Join(" ", str.Split(' ').Select(x => new String(x.Reverse().ToArray())));

            Console.WriteLine($"Reverse Word String : {reverseString}");
            Console.ReadKey();
        }      
    }
}