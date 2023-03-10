using System.Diagnostics;
using System.Transactions;

namespace FileHandling
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //if (args.Length < 2)
            //{
            //    return;
            //}

            //string destFolder = args[0];
            //List<string> files = new List<string>();
            //for (int i = 1; i < args.Length; i++)
            //{
            //    files.Add(args[i]);
            //}
            try
            {
                string destFolder = "Uploads";

                Console.WriteLine("----Upload files----");

                Console.WriteLine("\nEnter number of files you want to uplaod");
                int? numOfFiles = int.Parse(Console.ReadLine());

                List<string> files = new List<string>();

                for (int i = 0; i < numOfFiles; i++)
                {
                    while (true)
                    {
                        Console.WriteLine("\nEnter file path");
                        string filePath = Console.ReadLine();
                        if (File.Exists(filePath))
                        {
                            files.Add(filePath);
                            break;
                        }
                        else
                            Console.WriteLine("\nFile not Found");
                    }
                }

                await CopyFilesAsync(files, destFolder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task CopyFilesAsync(List<string> files, string destFolder)
        {
            try
            {
                if (!Directory.Exists(destFolder))
                {
                    Directory.CreateDirectory(destFolder);
                }
                foreach (string file in files)
                {
                     CopyFile(file, destFolder);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task CopyFile(string file, string destFolder)
        {
            try
            {
                //string currentDateTime = DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss");
                //string fileName = Path.GetFileNameWithoutExtension(file) + currentDateTime + Path.GetExtension(file);
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destFolder, fileName);
                using (FileStream sourceStream = new(file, FileMode.Open))
                {
                    using (FileStream destinationStream = new(destFile, FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                        long totalBytesRead = 0;
                        long fileSize = sourceStream.Length;

                        while (true)
                        {
                            int byteRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length);
                            if (byteRead == 0)
                            {
                                break;
                            }
                            await destinationStream.WriteAsync(buffer, 0, byteRead);
                            totalBytesRead += byteRead;
                        }
                        Console.WriteLine($"File {file} uploaded");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}