using System;

namespace RemoveDuplicateCharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a String : ");
            string str = Console.ReadLine().ToLower();
            string stringWithoutDuplicate = string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                if (!stringWithoutDuplicate.Contains(str[i]))
                {
                    stringWithoutDuplicate += str[i];
                }
            }
            Console.WriteLine(stringWithoutDuplicate);

            Console.ReadKey();
        }
    }
}