using System;

namespace CountLine
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the String: ");
            string str = Console.ReadLine();

            string[] spearator = { "!", "?", "." };
            
            int count = 0;
            string[] strlist = str.Split(spearator,StringSplitOptions.RemoveEmptyEntries);

            //With spaces between two separators considered as line
            //Console.WriteLine("Number of lines: {strlist.Length});

            foreach(string s in strlist)
            {
                if(s == " ")
                    continue;
                count++;
            }
            Console.WriteLine($"Number of lines: {count}");
        }
    }
}