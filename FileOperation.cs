using FileHandling.Exceptions;

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
                    throw new InvalidFileTypeException("\nInvalid File Type");
            }
            catch (InvalidFileTypeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\nFile type should be png/txt/xls/jpg");
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

        public void CheckFilePath(string path, string fileExtention)
        {
            // This approach is for user trying to add file with filename only
            //if (!Path.IsPathFullyQualified(path))
            //{
            //    path = defaultPath + Path.GetFileName(path);
            //}

            if (File.Exists(path))
            {
                if (files.Contains(path))
                {
                    Console.WriteLine("\nFile is already added");
                }
                else
                {
                    files.Add(Path.GetFullPath(path));
                    Console.WriteLine("\nFile added successfully");
                }
            }
            else
            {
                Console.WriteLine("\nFile not found..");
                Console.WriteLine("\nDo you want to create new file?(yes/no)");
                string? newFile = Console.ReadLine();
                if (newFile.ToLower() is "yes" or "y")
                {
                    if (fileExtention.ToLower() is ".jpg" or ".png")
                        Console.WriteLine("\n{0} type file cannot be created", fileExtention);
                    else
                        CreateFile(path);
                }
            }
        }

        public void CreateFile(string path)
        {
            using (FileStream createFile = new FileStream(path, FileMode.CreateNew))
            {
                path = Path.GetFullPath(path);
                Console.WriteLine("\nNew file is created at {0}", path);
                files.Add(path);
            }
        }

        public void WriteFile(string path, string fileExtension)
        {
            string? writeMore;
            if (files.Contains(path))
            {
                if (fileExtension.ToLower() is ".jpg" or ".png" or ".xls")
                    Console.WriteLine("\nCannot write to {0} file, please select text(.txt) file", fileExtension);
                //else if (fileExtension.ToLower() is ".xls")
                //    writeExcel(path);
                else
                {
                    FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write);
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        do
                        {
                            Console.WriteLine("\nEnter data you want to add in the file {0}", Path.GetFileName(path));
                            string? writeToFile = Console.ReadLine();
                            streamWriter.WriteLine(writeToFile);
                            Console.WriteLine("\nDo you want to write more?(yes/no)");
                            writeMore = Console.ReadLine();
                            if (!(writeMore.ToLower() is "yes" or "no"))
                            {
                                Console.WriteLine("\nClosing file...");
                            }
                        } while (writeMore == "yes");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nFile is not added. Please select files from uploaded or add new file.");
            }
        }
        //Public void writeExcel(string path)
        //{
        //        Application excelApp = new();
        //            try
        //            {
        //                if (!File.Exists(path))
        //                {
        //                    excelApp.Workbooks.Add();
        //                    _Worksheet workSheet = (_Worksheet)excelApp.ActiveSheet;
        //                    Console.WriteLine("Enter number of columns");
        //                    int numOfColumns = int.Parse(Console.ReadLine());
        //                    for (int i = 0; i<numOfColumns; i++)
        //                    {
        //                        Console.WriteLine("Enter column {0} name: ", i + 1);
        //                        string? columnName = Console.ReadLine();
        //                        workSheet.Cells[1, i + 1] = columnName;
        //                    }

        //                    Console.WriteLine("Enter number of rows you want to enter data for");
        //                    int numOfRows = int.Parse(Console.ReadLine());
        //                    for (int i = 1; i <= numOfRows; i++)
        //                    {
        //                        for (int j = 1; j <= numOfColumns; j++)
        //                        {
        //                            Console.WriteLine("Enter data for {0}", workSheet.Cells[1, j]);
        //                            string? data = Console.ReadLine();
        //                             workSheet.Cells[i + 1, j] = data;
        //                        }
        //                    }
        //                    workSheet.SaveAs(path);
        //                }
        //                else
        //                {
        //                    var workbook = excelApp.Workbooks.Open(path);
        //                    _Worksheet workSheet = (_Worksheet)workbook.Sheets[1];
        //                    int row = workSheet.UsedRange.Rows.Count;
        //                    int col = workSheet.UsedRange.Columns.Count;

        //                    Console.WriteLine("Enter number of rows you want to enter data for");
        //                    int numOfRows = int.Parse(Console.ReadLine());
        //                    for (int i = row + 1; i <= numOfRows; i++)
        //                    {
        //                        for (int j = 1; j <= col; j++)
        //                        {
        //                           Console.WriteLine("Enter data for {0}", workSheet.Cells[1, j]);
        //                           string? data = Console.ReadLine();
        //                           workSheet.Cells[i + 1, j] = data;
        //                        }
        //                    }
        //                    workSheet.SaveAs(path);
        //}
        //                }
        //                catch (Exception ex)
        //                {
        //                    Console.WriteLine(ex.ToString());
        //                }
    }
}
