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
                Console.WriteLine("\n-------------------------------");
                Console.WriteLine("\t\tFile Operations");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1. Upload file");
                Console.WriteLine("2. Write data in the file");
                Console.WriteLine("3. Show uploaded files");
                Console.WriteLine("4. Check available files to write");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("or enter exit to stop\n");

                program.choice = Console.ReadLine();

                switch(program.choice)
                {
                    case "1": Console.WriteLine("\nEnter the file name with path");
                        program.path = Console.ReadLine();
                        if (string.IsNullOrEmpty(program.path))
                        {
                            Console.WriteLine("\nFile path should not be null");
                            break;
                        }
                        fileOperation.CheckFileExtension(program.path);
                        break;

                    case "2":
                        if (fileOperation.files.Count == 0)
                        {
                            Console.WriteLine("\nNo files are avilable to write. Please add files first.");
                            break;
                        }

                        Console.WriteLine("\nEnter file that you want to write?");
                        program.path = Console.ReadLine();
                        if (Path.IsPathFullyQualified(program.path))
                            fileOperation.WriteFile(program.path, Path.GetExtension(program.path));
                        else
                            Console.WriteLine("Enter complete path...");
                    break;

                    case "3":
                        if (fileOperation.files.Count == 0)
                        {
                            Console.WriteLine("\nNo files are uploaded.");
                            break;
                        }
                        Console.WriteLine("\nUploaded files: ");
                        foreach(string file in fileOperation.files)
                        {
                            Console.WriteLine(file);
                        }
                        break;
                    case "4":
                        if (fileOperation.files.Count == 0)
                        {
                            Console.WriteLine("\nNo files are available to write.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nAvailable files to write : ");
                            foreach (string file in fileOperation.files)
                            {
                                if (Path.GetExtension(file) is ".txt")
                                    Console.WriteLine(file);
                            }
                            break;
                        }
                }
            } while (program.choice.ToLower() != "exit");
        }
    }
}