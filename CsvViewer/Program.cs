using System;
using System.Collections.Generic;

namespace CsvViewer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string path = GetFilePathFromArgsOrCommandLine(args);

            try
            {
                var interactor = new CsvInteractor(path);

                var commands = new Dictionary<ConsoleKey, Func<IList<string>>>()
                {
                    { ConsoleKey.N, () => interactor.GoToNextPage() },
                    { ConsoleKey.P, () => interactor.GoToPreviousPage() },
                    { ConsoleKey.L, () => interactor.GoToLastPage() },
                    { ConsoleKey.X, () => Exit() }
                };

                foreach (string line in interactor.GotToFirstPage())
                {
                    Console.WriteLine(line);
                }

                while (true)
                {
                    Console.WriteLine("N(ext page, P(revious page, F(irst page, L(ast page, eX(it");
                    ConsoleKey consoleKey = Console.ReadKey().Key;

                    if (!commands.TryGetValue(consoleKey, out Func<IList<string>> command))
                    {
                        throw new NotSupportedException($"Key {consoleKey} is not supported");
                    }

                    foreach (string line in command.Invoke())
                    {
                        Console.WriteLine(line);
                    }
                }
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

        private static IList<string> Exit()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
