namespace FileHandling
{
    class Program
    {
        private string? choice;
        public static void Main(string[] args)
        {
            Program program = new();
            FileOperation fileOperation = new FileOperation();

            do
            {
                Console.WriteLine("\n-------------------------------");
                Console.WriteLine("\t\tFile Operations");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1. Copy file");
                Console.WriteLine("2. Read data from a file and replace a word");
                Console.WriteLine("3. Read last line from a file");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("or enter exit to stop\n");

                program.choice = Console.ReadLine();

                switch (program.choice)
                {
                    case "1":
                        FileOperation.CopyFile();
                        break;


                    case "2":
                        FileOperation.ReadData();
                        break;

                    case "3":
                        FileOperation.ReadLastLine();
                        break;

                }
            } while (program.choice.ToLower() != "exit");
        }
    }
}