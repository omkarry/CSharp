using System;
using System.Collections.Generic;

namespace longestPrefix
{
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Enter the string");
            string input = Console.ReadLine().ToLower();
            // List<string> prefixes = new List<string>();
            IDictionary<string, int> prefixes = new Dictionary<string, int>();
            string longestPrefix = "";
            int longestPrefixCount = 0;

            // Split the string into words
            string[] words = input.Split();

            foreach (string word in words) 
            {
                // Iterate over each possible prefix
                for (int i = 1; i <= word.Length; i++) 
                {
                    string prefix = word.Substring(0, i);
                    int count = 0;
                    foreach (string w in words) 
                    {
                        if (w.StartsWith(prefix)) 
                        {
                            count++;
                        }
                    }
                    if (longestPrefix.Length <= prefix.Length && count >= 2)
                    {
                        if (!(prefixes.Keys.Contains(prefix)))
                             prefixes.Add(new KeyValuePair<string, int>(prefix, count));
                    }
                       
                }
            }
            foreach(var prefix in prefixes.Keys)
            {
                if ((longestPrefix.Length < prefix.Length) || longestPrefixCount < prefixes[prefix]){
                    longestPrefix = prefix;
                    longestPrefixCount = prefixes[prefix];
                }
            }
            
            Console.WriteLine($"Longest common prefix: {longestPrefix}");
        }
    }

}