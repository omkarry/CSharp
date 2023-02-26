using FileHandling.Exceptions;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace FileOperations
{
    class FileOperation
    {
        public List<string> files = new();
        // This approach is for user trying to add file with filename only
        // public readonly string defaultPath = @"C:\Users\Lenovo\source\repos\FileHandling\FileHandling\Files\";
        private readonly List<string> ListOfExtenstions = new List<string> { ".png", ".txt", ".xls", ".jpg" };
        public void CheckFileExtension(string path)
        {
            try
            {
                string fileExtension = Path.GetExtension(path);
                if (ListOfExtenstions.Contains(fileExtension.ToLower()))
                {
                    CheckFilePath(path, fileExtension);
                }
                else
                    throw new InvalidFileTypeException("Invalid File Type");
            }
            catch (InvalidFileTypeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("File type should be png/txt/xls/jpg");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CheckFilePath(string path, string fileExtention)
        {
            // This approach is for user trying to add file with filename only
            //if (!Path.IsPathFullyQualified(path))
            //{
            //    path = defaultPath + Path.GetFileName(path);
            //}

            if (File.Exists(path))
            {
                Console.WriteLine("File added successfully");
                files.Add(path);
            }
            else
            {
                Console.WriteLine("File not found..");
                Console.WriteLine("Do you want to create new file?(yes/no)");
                string? newFile = Console.ReadLine();
                if (newFile.ToLower() is "yes" or "y")
                {
                    if (fileExtention.ToLower() is ".jpg" or ".png")
                        Console.WriteLine("{0} type file cannot be created", fileExtention);
                    else
                        CreateFile(path);
                }
            }
        }

        public void CreateFile(string path)
        {
            using (FileStream createFile = new FileStream(path, FileMode.CreateNew))
            {
                Console.WriteLine("New file is created at {0}", path);
                files.Add(path);
            }
        }

        public void WriteFile(string path, string fileExtension)
        {
            string? writeMore;
            if (files.Contains(path))
            {
                if (fileExtension.ToLower() is ".jpg" or ".png" or ".xls")
                    Console.WriteLine("Unable to write {0} file", fileExtension);
                else
                {
                    FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write);
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        do
                        {
                            Console.WriteLine("Enter data you want to add in the file {0}", Path.GetFileName(path));
                            string? writeToFile = Console.ReadLine();
                            streamWriter.WriteLine(writeToFile);
                            Console.WriteLine("Do you want to write more?(yes/no)");
                            writeMore = Console.ReadLine();
                            if (!(writeMore.ToLower() is "yes" or "no"))
                            {
                                Console.WriteLine("Closing file...");
                            }
                        } while (writeMore == "yes");
                    }
                }
            }
            else
            {
                Console.WriteLine("File is not added. Please select files from uploaded or add new file.");
            }
        }
    }
}
