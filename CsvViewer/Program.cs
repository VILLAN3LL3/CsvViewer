using System;

namespace CsvViewer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string path = GetFilePathFromArgsOrCommandLine(args);

            try
            {
                var interactor = new CsvInteractor();
                foreach (string line in interactor.GetRenderedCsvTableByPath(path))
                {
                    Console.WriteLine(line);
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }

        private static string GetFilePathFromArgsOrCommandLine(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter the path to the csv file you want to display");
                return Console.ReadLine();
            }
            else
            {
                return args[0];
            }
        }
    }
}
