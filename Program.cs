using System;
using System.IO;

namespace FileOperations
{
    class Program
    {
        public string? choice;
        public string? path;
        public static void Main(string[] args)
        {
            Program program = new Program();
            FileOperation fileOperation = new FileOperation();

            do
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("\t\tFile Operations");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1. Upload file");
                Console.WriteLine("2. Write data in the file");
                Console.WriteLine("3. Check available files to write");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("or enter exit to stop");

                program.choice = Console.ReadLine();

                switch(program.choice)
                {
                    case "1": Console.WriteLine("Enter the file name with path");
                        program.path = Console.ReadLine();
                        if (string.IsNullOrEmpty(program.path))
                        {
                            Console.WriteLine("File path should not be null");
                            break;
                        }
                        fileOperation.CheckFileExtension(program.path);
                        break;

                    case "2":
                        if (fileOperation.files.Count == 0)
                        {
                            Console.WriteLine("No files are avilable to write. Please add files first.");
                            break;
                        }

                        Console.WriteLine("Enter file that you want to write?");
                        program.path = Console.ReadLine();
                        fileOperation.WriteFile(program.path, Path.GetExtension(program.path));
                    break;

                    case "3":
                        if (fileOperation.files.Count == 0)
                        {
                            Console.WriteLine("No files are avilable to write.");
                            break;
                        }
                        Console.WriteLine("Available files: ");
                        foreach(string file in fileOperation.files)
                        {
                            Console.WriteLine(file);
                        }
                        break;
                }

                
            } while (program.choice.ToLower() != "exit");
        }
    }
}