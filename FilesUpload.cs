using System.IO;
namespace FileHandling
{
    class FilesUpload
    {
        public static void UploadFiles(string[] filePaths)
        {
            foreach (string filePath in filePaths)
            {
                CopyFile(filePath);
            }
        }

        public static async Task CopyFile(string filePathToRead)
        {
            if (File.Exists(filePathToRead))
            {
                await Task.Run(() =>
                {
                    string newFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", Path.GetFileName(filePathToRead));

                    using (FileStream fileStreamToWrite = new FileStream(newFilePath, FileMode.Create, FileAccess.Write))
                    {
                        using (FileStream fileStreamToRead = new FileStream(filePathToRead, FileMode.Open, FileAccess.Read))
                        {
                            fileStreamToRead.CopyTo(fileStreamToWrite);
                        }
                    }
                });
                Console.WriteLine("File upload Complete: {0}", Path.GetFileName(filePathToRead));
            }
            else
                Console.WriteLine("Fle not found");
        }
    }
}
