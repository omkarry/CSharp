using System;
using System.IO;
using System.Xml.Linq;

namespace FileHandling
{
	class FileOperation
	{
        public static void CopyFile()
        {
            string? name, fileLocation, filePath, overwriteFile;

            try
            {
                Console.WriteLine("\nEnter the location :");
                fileLocation = Console.ReadLine();

                Console.WriteLine("\nEnter file name: (Text file only)");
                name = Console.ReadLine();
                if (name is null or "" || fileLocation is null or "")
                    Console.WriteLine("\nName or Location is empty");
                else if (Path.GetExtension(name) is not ".txt")
                    Console.WriteLine("\nInvalid file type. Only text (.txt) file is allowed");
                else
                {
                    if (fileLocation.EndsWith("\\"))
                        filePath = fileLocation + name;
                    else
                        filePath = fileLocation + "\\" + name;
                    //If file exist then it will be overwrite
                    if (File.Exists(filePath))
                    {
                        Console.WriteLine("File is already exist at this location.");
                        Console.WriteLine("Do you want to overwrite this file?");
                        overwriteFile = Console.ReadLine() ?? throw new ArgumentException();
                        if (overwriteFile.ToLower() is "yes" or "y")
                        {
                            CreateFile(filePath);
                        }
                    }
                    else
                        CreateFile(filePath);

                    Console.WriteLine("\nEnter the file with location which you want to copy:");
                    string? copyPath = Console.ReadLine();
                    if (File.Exists(copyPath))
                        File.Copy(copyPath, filePath, true);
                    else
                        throw new FileNotFoundException("\nFile not found to copy");
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not Found");
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine(uae.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ReadData()
        {
            try
            {
                string? path;
                Console.WriteLine("\nEnter the file name with path:");
                path = Console.ReadLine();
                if (path is null or "")
                    Console.WriteLine("\nPath is empty");
                else if (Path.GetExtension(path) is not ".txt")
                    Console.WriteLine("\nInvalid file type. Only text (.txt) file is allowed");
                else
                {
                    string text = File.ReadAllText(path);
                    Console.WriteLine("\nText in the file {0}: \n{1}", Path.GetFileName(path), text);

                    Console.WriteLine("\nWhich word you want to replace?");
                    string? wordToReplace = Console.ReadLine() ?? throw new ArgumentNullException();

                    Console.WriteLine("{0} replace this word with: ", wordToReplace);
                    string? replaceWordWith = Console.ReadLine();
                    text = text.Replace(wordToReplace, replaceWordWith);
                    File.WriteAllText(path, text);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found");
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine(uae.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ReadLastLine()
		{
            try
            {
                string? path;
                Console.WriteLine("\nEnter the file name with:");
                path = Console.ReadLine();
                //FileNotFoundException can be handled with
                //if(!File.Exists(path)
                //    Console.WriteLine("File not found");
                if (path is null or "") 
                    Console.WriteLine("\nPath is empty");
                else if (Path.GetExtension(path) is not ".txt")
                    Console.WriteLine("\nInvalid file type. Only text (.txt) file is allowed");
                else
                {
                    string lastLine = File.ReadLines(path).Last();
                    Console.WriteLine("\nLast line of the file {0}: \n{1}", Path.GetFileName(path), lastLine);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found");
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine(uae.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
		}

        public static void CreateFile(string path)
        {
            var file = File.CreateText(path);
            Console.WriteLine("\nFile is created at {0}", path);
            file.Close();
        }
    }
}
