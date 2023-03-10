using System;
using System.IO;

namespace FileUpload
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                string? sourceFile;
                do
                {
                    Console.WriteLine("----Upload File----");
                    while (true)
                    {
                        Console.WriteLine("Enter source file:");
                        sourceFile = Console.ReadLine();
                        if (File.Exists(sourceFile))
                            break;
                        else
                            Console.WriteLine("\nFile not found to upload\n");
                    }

                    string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                    if (!Directory.Exists(destinationPath))
                        Directory.CreateDirectory(destinationPath);

                    //string currentDateTime = DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss");
                    //string fileName = Path.GetFileNameWithoutExtension(sourceFile) + currentDateTime + Path.GetExtension(sourceFile);
                    string fileName = Path.GetFileName(sourceFile);
                    string destinationFile = Path.Combine(destinationPath, fileName);

                    FileStream createDestinationFile = File.Create(destinationFile);
                    createDestinationFile.Close();

                    await CopyFileAsync(sourceFile, destinationFile);

                    Console.WriteLine("\nDo you want to upload another file?");
                    string? uploadAnotherFile = Console.ReadLine();
                    if (!(uploadAnotherFile.ToLower() is "yes" or "y"))
                        break;
                } while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task CopyFileAsync(string  sourceFile, string destFile)
        {
            try
            {
                using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open))
                {
                    using (FileStream destinationStream = new FileStream(destFile, FileMode.Create))
                    {
                        byte[] buffer = new byte[2048];
                        long totalBytesRead = 0;
                        long fileSize = sourceStream.Length;

                        while (true)
                        {
                            int byteRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length);
                            if (byteRead == 0)
                            {
                                Console.SetCursorPosition(0, Console.GetCursorPosition().Top + 1);
                                break;
                            }
                            await destinationStream.WriteAsync(buffer, 0, byteRead);
                            totalBytesRead += byteRead;
                            double percentage = (double)totalBytesRead / fileSize * 100;
                            Console.WriteLine($"Uploading...{percentage:F2}%");
                            Console.SetCursorPosition(0, Console.GetCursorPosition().Top - 1);
                        }
                    }
                }
                Console.WriteLine("File uploaded successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}