using System;

namespace StringMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get the length
            Console.Write("Enter a String to get length: ");
            string str = Console.ReadLine();
            Console.WriteLine($"String Length{str.Length}");

            //Join two string using Concat method
            Console.WriteLine("Enter two strings to join: ");
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            Console.WriteLine($"Join two strings: {string.Concat(firstName, lastName)}");

            //Join the string of array using separator
            string[] stringArray = {"Hi", "Hello", "How", "are", "You"}
            Console.WriteLine($"Array of string: {stringArray}");
            string joinedString = strin.Join(" ");
            Console.WriteLine($"Joined string from array: {joinedString}");

            //Compare two Strings using Equals methods
            Console.WriteLine("Enter two strings to compare: ");
            string string1 = Console.ReadLine();
            string string2 = Console.ReadLine();
            bool equalStrings = string1.Equals(string2);//case-sensitive
            if (equalStrings)
            {
                Console.WriteLine("String 1 and String 2 are same");
            }
            else
                Console.WriteLine("String 1 and String 2 are not same");
                
            //Compare two Strings using Compare methods
            Console.WriteLine("Enter two strings to compare: ");
            string1 = Console.ReadLine();
            string2 = Console.ReadLine();
            int compareString = Compare(string1, string2);//case-sensitive
            if (compareString == 0)
            {
                Console.WriteLine("String 1 and String 2 are same");
            }
            else
                Console.WriteLine("String 1 and String 2 are not same");

            //String interpolation by $
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}");

            //String Formatting 
            Console.WriteLine("Enter your age: ");
            string age = Console.ReadLine();
            Console.WriteLine(string.Format("You are {0} years old",age));

            //String Split
            Console.WriteLine("Enter a string to split: ");
            string stringToSplit = Console.ReadLine();
            string[] splittedString = stringToSplit.Split(" ");
            foreach(string sub in splittedString)
            {
                Console.WriteLine(sub);
            }

            //Get a substring of the string
            Console.WriteLine("Enter a string to get substring: ");
            string subStr = Console.ReadLine();
            Console.WriteLine(subStr.Substring(0,5)); //prints first 5 characters

            //Replace Specific character
            Console.WriteLine("Enter a string to demo replace: ");
            string replaceString = Console.ReadLine();
            Console.WriteLine("String with \',\' instead of spaces: {0}",replaceString.Replace(" ", ","));

            //Check whether the string contains substring
            Console.WriteLine("Enter a string to check whether it contains substring: ");
            string1 = Console.ReadLine();
            Console.WriteLine("Enter substring: ");
            subStr = Console.ReadLine();
            bool containString = string1.Contains(subStr);
            Console.WriteLine("{0} is in string: {1}", subStr, containString);

            //Trim characters from string
            Console.WriteLine("Enter a string to trim: ");
            string1 = Console.ReadLine();
            char[] charsToTrim = {' '};
            Console.WriteLine(string1.Trim(charsToTrim));

            //Trim characters from starting
            Console.WriteLine("Enter a string to trim: ");
            string1 = Console.ReadLine();
            char[] charsToTrimFromStart = {' '};
            Console.WriteLine("Trimmed from start" + string1.Trim(charsToTrimFromStart));

            //Trim characters from ending
            Console.WriteLine("Enter a string to trim: ");
            string1 = Console.ReadLine();
            char[] charsToTrimFromEnd = {'.', '!', '?'};
            Console.WriteLine("Trimmed from end" + string1.Trim(charsToTrimFromEnd));

            //Check whether string ends with character
            Console.WriteLine("Enter the string to check whether it ends with \'.\'");
            string2 = Console.ReadLine();
            Console.WriteLine("String ends with \'.\': {0}",string2.EndsWith('.'));

            //Check whether string starts with character
            Console.WriteLine("Enter the string to check whether it ends with \'.\'");
            string2 = Console.ReadLine();
            Console.WriteLine("String ends with \'S\': {0}",string2.StartsWith('S'));

            //Get the index of first occurence of specific  character
            Console.WriteLine("Enter the string to check index of the character:");
            string1 = Console.ReadLine();
            Console.WriteLine("Enter character to check its index in string:");
            char char1 = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("First occurence of {0} in string is {1}", char1, string1.IndexOf(char1));

            //Get the index of first occurence of charcters from list
            Console.WriteLine("Enter the string to check index of the character:");
            string1 = Console.ReadLine();
            char[] chars = {'a', 'e', 'i', 'o', 'u'}
            Console.WriteLine("First occurence of characters from {0} in string is {1}", chars, string1.IndexOfAny(chars));

            //Get the index of last occurence of specific specific character
            Console.WriteLine("Enter the string to check index of the character:");
            string1 = Console.ReadLine();
            Console.WriteLine("Enter character to check its index in string:");
            char1 = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Last occurence of {0} in string is {1}", char1, string1.LastIndexOf(char1));

            //Get the index of last occurence of charcters from list
            Console.WriteLine("Enter the string to check index of the character:");
            string1 = Console.ReadLine();
            chars = {'a', 'e', 'i', 'o', 'u'}
            Console.WriteLine("First occurence of characters from {0} in string is {1}", chars, string1.LastIndexOfAny(chars));

            //Remove character at index from a string
            Console.WriteLine("Enter a string to remove a character: ");
            string1 = Console.ReadLine();
            Console.WriteLine("Removing characters from 5-10: {0}", string1.Remove(4, 10));

            //Convert the string to uppercase & lowercase
            Console.WriteLine("Enter a string to change to uppercase or lowercase");
            string1 = Console.ReadLine();
            Console.WriteLine("String in uppercase: {0}", string1.ToUpper());
            Console.WriteLine("String in lowercase: {0}", string1.ToLower());

            //Convert a string to character array
            Console.WriteLine("Enter a string to convert into character array");
            string2 = Console.ReadLine();
            char[] stringToCharArray = string2.ToCharArray();
            Console.WriteLine("Array of characters:");
            foreach(char c in stringToCharArray)
            {
                Console.WriteLine(c);
            }

            //Clone the string
            Console.Write("Enter a String to clone: ");
            string1 = Console.ReadLine();
            stringClone = (String)string1.Clone();//Return object type 
            Console.WriteLine($"String: {string1}");
            Console.WriteLine($"Cloned string: {stringClone}");

            //Copy the string
            Console.Write("Enter a String to copy: ");
            string1 = Console.ReadLine();
            stringCopy = Copy(string1);//Return object type 
            Console.WriteLine($"Original string: {string1}");
            Console.WriteLine($"Cloned string: {stringCopy}");

            //Convert any data type to string
            Console.WriteLine("Enter any number to convert into string: ");
            int number = (int)Console.ReadLine();
            Console.WriteLine("{0} number to string {1}", number, number.ToString());

            //Check whether the string is null or empty
            string1 = "";
            string2 = null;
            if (IsNullOrEmpty(string1))
                Console.WriteLine("String 1 is empty");
            if (IsNullOrEmpty(string2))
                Console.WriteLine("String 2 is null");

            //Check whether the string is null or empty
            string1 = " ";
            string2 = null;
            if (IsNullOrWhiteSpace(string1))
                Console.WriteLine("String 1 contains whitespace");
            if (IsNullOrWhiteSpace(string2))
                Console.WriteLine("String 2 is null");

            //Padding to left and right
            Console.WriteLine("Enter the string to add padding to left and right");
            string1 = Console.ReadLine();
            Console.WriteLine($"Padding to left: {string1.PadLeft(15)}");
            Console.WriteLine($"Padding to Right: {string1.PadRight(15)}");


            Console.ReadKey();
        }
    }
}