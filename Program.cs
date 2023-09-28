using System.Diagnostics;

namespace DACM
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] directoryFiles;
            if (Directory.Exists("Source"))
            {
                directoryFiles = Directory.GetFiles("Source");

            }
            else if (Directory.Exists("source"))
            {
                directoryFiles = Directory.GetFiles("source");
            }
            else if (Directory.Exists("src"))
            {
                directoryFiles = Directory.GetFiles("src");
            }
            else if (Directory.Exists("Src"))
            {
                directoryFiles = Directory.GetFiles("Src");
            }
            else
            {
                Console.WriteLine("There is no source (or src) directory!");
                Console.ReadLine();
                return;
            }
            List<string> sourceFilesNames = new List<string>();
            foreach (string fiesPaths in directoryFiles)
            {
                fiesPaths.Split('\\');
                if (fiesPaths.EndsWith(".d"))
                {
                    sourceFilesNames.Add(fiesPaths);
                }
            }

            if (sourceFilesNames.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("████████████████████████████████████");
                Console.WriteLine("There is no.d files in source or src directory!");
                Console.WriteLine("████████████████████████████████████");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {

                string dmdFilesArguments = string.Empty;
                for (int i = 0; i < sourceFilesNames.Count; i++)
                {
                    dmdFilesArguments += sourceFilesNames[i] += ' ';
                }



                //Создаём и стартуем процесс dmd
                Process dmd = new Process();
                dmd.StartInfo.FileName = "dmd";
                dmd.StartInfo.Arguments = dmdFilesArguments + ' ' + string.Concat<string>(args);
                dmd.Start();
                dmd.Close();
                Console.WriteLine("All is done!");
            }
            Console.ReadLine();
        }

    }
}